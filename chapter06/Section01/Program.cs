using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = "JSON";
            var str2 = "JSON";

            var cultureinfo = new CultureInfo("ja-JP");
            if(String.Compare(str1,str2,cultureinfo,CompareOptions.IgnoreKanaType) == 0) {
                Console.WriteLine("一致しています");
            }
        }
    }
}
