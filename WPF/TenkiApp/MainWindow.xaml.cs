using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherApp {
    public partial class MainWindow : Window {
        private Dictionary<string, (double lat, double lon)> Prefectures = new()
        {
            { "北海道", (43.06417, 141.34694) }, { "青森県", (40.82444, 140.74) },
            { "岩手県", (39.70361, 141.1525) }, { "宮城県", (38.26889, 140.87194) },
            { "秋田県", (39.71861, 140.1025) }, { "山形県", (38.24056, 140.36333) },
            { "福島県", (37.75, 140.46778) }, { "茨城県", (36.34139, 140.44667) },
            { "栃木県", (36.56583, 139.88361) }, { "群馬県", (36.39111, 139.06083) },
            { "埼玉県", (35.85694, 139.64889) }, { "千葉県", (35.60472, 140.12333) },
            { "東京都", (35.68944, 139.69167) }, { "神奈川県", (35.44778, 139.6425) },
            { "新潟県", (37.90222, 139.02361) }, { "富山県", (36.69528, 137.21139) },
            { "石川県", (36.59444, 136.62556) }, { "福井県", (36.06528, 136.22194) },
            { "山梨県", (35.66389, 138.56833) }, { "長野県", (36.65139, 138.18111) },
            { "岐阜県", (35.39111, 136.72222) }, { "静岡県", (34.97556, 138.38278) },
            { "愛知県", (35.18028, 136.90667) }, { "三重県", (34.73028, 136.50861) },
            { "滋賀県", (35.00444, 135.86833) }, { "京都府", (35.02139, 135.75556) },
            { "大阪府", (34.68639, 135.52) }, { "兵庫県", (34.69139, 135.18306) },
            { "奈良県", (34.68528, 135.83278) }, { "和歌山県", (34.22611, 135.1675) },
            { "鳥取県", (35.50361, 134.23833) }, { "島根県", (35.47222, 133.05056) },
            { "岡山県", (34.66167, 133.935) }, { "広島県", (34.39639, 132.45944) },
            { "山口県", (34.18583, 131.47139) }, { "徳島県", (34.06583, 134.55944) },
            { "香川県", (34.34028, 134.04333) }, { "愛媛県", (33.84167, 132.76611) },
            { "高知県", (33.55972, 133.53111) }, { "福岡県", (33.60639, 130.41806) },
            { "佐賀県", (33.24944, 130.29889) }, { "長崎県", (32.74472, 129.87361) },
            { "熊本県", (32.78972, 130.74167) }, { "大分県", (33.23806, 131.6125) },
            { "宮崎県", (31.91111, 131.42389) }, { "鹿児島県", (31.56028, 130.55806) },
            { "沖縄県", (26.2125, 127.68111) }
        };

        private string currentRegion = "東京都";

        public MainWindow() {
            InitializeComponent();
            RegionComboBox.ItemsSource = Prefectures.Keys;
            RegionComboBox.SelectedItem = currentRegion;
            _ = RefreshWeatherAsync(currentRegion);
        }

        private void RegionComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (RegionComboBox.SelectedItem != null) {
                currentRegion = RegionComboBox.SelectedItem.ToString();
                _ = RefreshWeatherAsync(currentRegion);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e) {
            _ = RefreshWeatherAsync(currentRegion);
        }

        private async Task RefreshWeatherAsync(string regionName) {
            var (lat, lon) = Prefectures[regionName];
            try {
                using HttpClient client = new();
                string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current_weather=true&hourly=relativehumidity_2m";
                var response = await client.GetStringAsync(url);

                using JsonDocument doc = JsonDocument.Parse(response);
                var root = doc.RootElement;

                double temperature = 0;
                double windSpeed = 0;
                double humidity = 0;
                int weatherCode = -1;

                if (root.TryGetProperty("current_weather", out JsonElement cw)) {
                    if (cw.TryGetProperty("temperature", out JsonElement tempEl))
                        temperature = tempEl.GetDouble();

                    if (cw.TryGetProperty("windspeed", out JsonElement windEl))
                        windSpeed = windEl.GetDouble();

                    if (cw.TryGetProperty("weathercode", out JsonElement codeEl))
                        weatherCode = codeEl.GetInt32();
                }

                if (root.TryGetProperty("hourly", out JsonElement hourly)) {
                    if (hourly.TryGetProperty("relativehumidity_2m", out JsonElement rh) && rh.GetArrayLength() > 0)
                        humidity = rh[0].GetDouble();
                }

                RegionNameText.Text = regionName;
                TemperatureText.Text = $"{temperature:0.0} °C";
                WindText.Text = $"{windSpeed:0.0} m/s";
                HumidityText.Text = $"{humidity:0} %";
                WeatherIconText.Text = WeatherIconHelper.GetIcon(weatherCode);
            }
            catch (Exception ex) {
                MessageBox.Show("天気情報の取得に失敗しました:\n" + ex.Message);
            }
        }
    }
}
