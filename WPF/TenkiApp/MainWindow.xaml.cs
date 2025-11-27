using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Windows.Devices.Geolocation;

namespace WeatherApp {
    public partial class MainWindow : Window {

        private readonly HttpClient _client = new HttpClient();

        public MainWindow() {
            InitializeComponent();
            LoadPrefectures();
            LoadCurrentLocationWeather();  // 起動時に現在地取得
        }

        // -------------------------
        // GPS 位置情報を取得
        // -------------------------
        private async Task<(double lat, double lon)> GetGPSLocation() {
            var access = await Geolocator.RequestAccessAsync();
            if (access != GeolocationAccessStatus.Allowed)
                throw new Exception("GPSの使用が許可されていません");

            var locator = new Geolocator { DesiredAccuracyInMeters = 100 };
            var pos = await locator.GetGeopositionAsync();

            return (
                pos.Coordinate.Point.Position.Latitude,
                pos.Coordinate.Point.Position.Longitude
            );
        }

        // -------------------------
        // 起動時: GPS → IP → 東京
        // -------------------------
        private async void LoadCurrentLocationWeather() {

            // ① GPS
            try {
                var (lat, lon) = await GetGPSLocation();
                var pref = new Prefecture("現在地", lat, lon);
                PrefCombo.SelectedItem = pref;
                await LoadWeather(pref);
                return;
            }
            catch {
                // 無視して次へ
            }

            // ② IP ベース
            try {
                string geoUrl = "https://ipapi.co/json/";
                var geoJson = await _client.GetStringAsync(geoUrl);
                var geo = JsonDocument.Parse(geoJson);

                double lat = geo.RootElement.GetProperty("latitude").GetDouble();
                double lon = geo.RootElement.GetProperty("longitude").GetDouble();
                string city = geo.RootElement.GetProperty("city").GetString();

                var pref = new Prefecture(city, lat, lon);
                PrefCombo.SelectedItem = pref;
                await LoadWeather(pref);
                return;
            }
            catch {
            }

            // ③ 東京
            var tokyo = new Prefecture("東京都", 35.6895, 139.6917);
            PrefCombo.SelectedItem = tokyo;
            await LoadWeather(tokyo);
        }

        private void LoadPrefectures() {
            PrefCombo.ItemsSource = new List<Prefecture>() {
                new Prefecture("北海道", 43.0642, 141.3469),
                new Prefecture("青森県", 40.8244, 140.74),
                new Prefecture("岩手県", 39.7036, 141.1527),
                new Prefecture("宮城県", 38.2689, 140.8719),
                new Prefecture("秋田県", 39.7186, 140.1025),
                new Prefecture("山形県", 38.2404, 140.3633),
                new Prefecture("福島県", 37.75, 140.4678),
                new Prefecture("茨城県", 36.3414, 140.4467),
                new Prefecture("栃木県", 36.5658, 139.8836),
                new Prefecture("群馬県", 36.3911, 139.0609),
                new Prefecture("埼玉県", 35.8569, 139.6489),
                new Prefecture("千葉県", 35.6047, 140.1233),
                new Prefecture("東京都", 35.6895, 139.6917),
                new Prefecture("神奈川県", 35.4478, 139.6425),
                new Prefecture("新潟県", 37.9022, 139.0236),
                new Prefecture("富山県", 36.6953, 137.2113),
                new Prefecture("石川県", 36.5947, 136.6256),
                new Prefecture("福井県", 36.0652, 136.2216),
                new Prefecture("山梨県", 35.6639, 138.5684),
                new Prefecture("長野県", 36.6514, 138.1811),
                new Prefecture("岐阜県", 35.3912, 136.7223),
                new Prefecture("静岡県", 34.9769, 138.3831),
                new Prefecture("愛知県", 35.1803, 136.9066),
                new Prefecture("三重県", 34.7303, 136.5086),
                new Prefecture("滋賀県", 35.0045, 135.8686),
                new Prefecture("京都府", 35.0214, 135.7556),
                new Prefecture("大阪府", 34.6937, 135.5023),
                new Prefecture("兵庫県", 34.6913, 135.183),
                new Prefecture("奈良県", 34.6853, 135.8328),
                new Prefecture("和歌山県", 34.226, 135.1675),
                new Prefecture("鳥取県", 35.5036, 134.2383),
                new Prefecture("島根県", 35.4723, 133.0505),
                new Prefecture("岡山県", 34.6618, 133.935),
                new Prefecture("広島県", 34.3963, 132.4594),
                new Prefecture("山口県", 34.1859, 131.4714),
                new Prefecture("徳島県", 34.0703, 134.5548),
                new Prefecture("香川県", 34.3401, 134.0434),
                new Prefecture("愛媛県", 33.8417, 132.7656),
                new Prefecture("高知県", 33.5597, 133.5311),
                new Prefecture("福岡県", 33.5904, 130.4017),
                new Prefecture("佐賀県", 33.2494, 130.2988),
                new Prefecture("長崎県", 32.7448, 129.8736),
                new Prefecture("熊本県", 32.7898, 130.7417),
                new Prefecture("大分県", 33.2382, 131.6126),
                new Prefecture("宮崎県", 31.9111, 131.4239),
                new Prefecture("鹿児島県", 31.5601, 130.5571),
                new Prefecture("沖縄県", 26.2124, 127.6811)
            };
            PrefCombo.DisplayMemberPath = "Name";
        }

        private async void PrefCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (PrefCombo.SelectedItem is Prefecture pref)
                await LoadWeather(pref);
        }

        // -------------------------
        // 天気取得
        // -------------------------
        private async Task LoadWeather(Prefecture pref) {
            try {
                string url =
                    $"https://api.open-meteo.com/v1/forecast?" +
                    $"latitude={pref.Lat}&longitude={pref.Lon}&" +
                    $"current_weather=true&hourly=temperature_2m,relativehumidity_2m,windspeed_10m&" +
                    $"daily=temperature_2m_max,temperature_2m_min,weathercode&timezone=Asia/Tokyo";

                var response = await _client.GetStringAsync(url);
                var json = JsonDocument.Parse(response);

                var current = json.RootElement.GetProperty("current_weather");

                CurrentLocation.Text = pref.Name;
                CurrentDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                TempText.Text = $"{current.GetProperty("temperature").GetDouble():0}°C";
                WindText.Text = $"風速: {current.GetProperty("windspeed").GetDouble():0.0} m/s";

                // 湿度
                var hourly = json.RootElement.GetProperty("hourly");
                var times = hourly.GetProperty("time").EnumerateArray();
                var hum = hourly.GetProperty("relativehumidity_2m").EnumerateArray();

                DateTime now = DateTime.Now;
                double humidity = hum.First().GetDouble();

                foreach (var (t, i) in times.Select((t, i) => (t, i))) {
                    DateTime dt = DateTime.Parse(t.GetString());
                    if (dt.Hour == now.Hour && dt.Date == now.Date) {
                        humidity = hum.ElementAt(i).GetDouble();
                        break;
                    }
                }

                HumidityText.Text = $"湿度: {humidity:0}%";

                // 時間別
                var temps = hourly.GetProperty("temperature_2m").EnumerateArray();
                var hourlyList = new List<HourlyWeather>();

                int k = 0;
                foreach (var t in times) {
                    hourlyList.Add(new HourlyWeather {
                        Time = DateTime.Parse(t.GetString()).ToString("HH:mm"),
                        Temp = $"{temps.ElementAt(k).GetDouble():0}°C",
                        Icon = "☀️"
                    });
                    if (++k > 23) break;
                }

                HourlyPanel.ItemsSource = hourlyList;

                // 週間
                var daily = json.RootElement.GetProperty("daily");
                var days = daily.GetProperty("time").EnumerateArray()
                    .Select(x => DateTime.Parse(x.GetString()).ToString("ddd"))
                    .ToList();

                var tmax = daily.GetProperty("temperature_2m_max").EnumerateArray()
                    .Select(x => $"{x.GetDouble():0}°C").ToList();

                var tmin = daily.GetProperty("temperature_2m_min").EnumerateArray()
                    .Select(x => $"{x.GetDouble():0}°C").ToList();

                var codes = daily.GetProperty("weathercode").EnumerateArray()
                    .Select(x => x.GetInt32()).ToList();

                var weekList = new List<DailyWeather>();
                for (int j = 0; j < days.Count; j++) {
                    weekList.Add(new DailyWeather {
                        Day = days[j],
                        TempMax = tmax[j],
                        TempMin = tmin[j],
                        Icon = GetWeatherIcon(codes[j])
                    });
                }

                WeeklyPanel.ItemsSource = weekList;

            }
            catch (Exception ex) {
                MessageBox.Show("天気情報の取得に失敗しました\n" + ex.Message);
            }
        }

        private string GetWeatherIcon(int code) =>
            code switch {
                0 => "☀️",
                1 => "🌤️",
                2 => "⛅",
                3 => "☁️",
                45 => "🌫️",
                48 => "🌫️",
                51 => "🌦️",
                53 => "🌦️",
                55 => "🌦️",
                61 => "🌧️",
                63 => "🌧️",
                65 => "🌧️",
                71 => "❄️",
                73 => "❄️",
                75 => "❄️",
                80 => "🌦️",
                81 => "🌧️",
                82 => "🌧️",
                _ => "☀️"
            };
    }

    // データクラス
    public class Prefecture {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public Prefecture(string name, double lat, double lon) {
            Name = name; Lat = lat; Lon = lon;
        }
    }

    public class HourlyWeather {
        public string Time { get; set; }
        public string Temp { get; set; }
        public string Icon { get; set; }
    }

    public class DailyWeather {
        public string Day { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        public string Icon { get; set; }
    }
}
