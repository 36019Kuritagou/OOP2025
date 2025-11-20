using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp {
    public static class WeatherIconHelper {
        public static string GetIcon(int weatherCode) {
            // Open-Meteo の weathercode に対応する絵文字
            return weatherCode switch {
                0 => "☀️", // 晴れ
                1 => "🌤", // 部分的に晴れ
                2 => "⛅", // 曇り
                3 => "☁️", // 曇り
                45 => "🌫", // 霧
                48 => "🌫",
                51 => "🌦", // 小雨
                53 => "🌦",
                55 => "🌧",
                61 => "🌧", // 雨
                63 => "🌧",
                65 => "🌧",
                71 => "❄️", // 雪
                73 => "❄️",
                75 => "❄️",
                80 => "🌧", // 雨のシャワー
                81 => "🌧",
                82 => "🌧",
                95 => "⛈", // 雷雨
                96 => "⛈",
                99 => "⛈",
                _ => "❓"
            };
        }
    }
}

