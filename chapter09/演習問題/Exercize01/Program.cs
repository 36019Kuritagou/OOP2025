using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercize01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            var form = string.Format("{0:yyyy/MM/dd mm:ss}", dateTime);
            Console.WriteLine(form);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            var dform = dateTime.ToString($"yyyy年MM月dd日 mm:ss");
            Console.WriteLine(dform);

        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var date = new DateTime(2024, 3, 9);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(date);
            var eraName = culture.DateTimeFormat.GetEraName(era);
            var str = dateTime.ToString("ggyy年M月d日dddd", culture);
            Console.WriteLine(str);
        }
    }
}
