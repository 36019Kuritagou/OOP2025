using System.Data;
using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            //var today = new DateTime(2025,7,12); ;
            //var now = DateTime.Now;

            //Console.WriteLine($"Today:{today.Month}");
            //Console.WriteLine($"Now:{now}");

            //①自分の生年月日は何曜日かプログラムを書いて調べる
            /*var birthday = new DateTime(2006, 1, 15);
            Console.WriteLine($"西暦:{birthday.Year}");
            Console.WriteLine($"月:{birthday.Month}");
            Console.WriteLine($"日:{birthday.Day}");
            DayOfWeek dayOfWeek = birthday.DayOfWeek;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日dddd",culture);
            Console.WriteLine(str);*/
            Console.Write("西暦: ");
            var y = int.Parse(Console.ReadLine());
            Console.Write("月: ");
            var m = int.Parse(Console.ReadLine());
            Console.Write("日: ");
            var d = int.Parse(Console.ReadLine());

            var date = new DateTime(y, m, d);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var era = culture.DateTimeFormat.Calendar.GetEra(date);
            var eraName = culture.DateTimeFormat.GetEraName(era);            
            var str = date.ToString("ggyy年M月d日dddd", culture);
            Console.WriteLine(str);

            //③生まれてから〇〇〇〇日目です
            var now = DateTime.Now;
            var diff = now.Date - date;
            Console.WriteLine($"生まれてから{diff.Days}日間");

            //②うるう年の判定プログラムを作成する
            //西暦を入力
            //〇〇〇〇はうるう年です
            //〇〇〇〇は平成です
            var isLeapYear = DateTime.IsLeapYear(y);
            if(isLeapYear) {
                Console.WriteLine("うるう年です");
            }else {
                Console.WriteLine("うるう年ではありません");
            }


        }
    }
}
