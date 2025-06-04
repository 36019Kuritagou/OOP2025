

using System.Reflection.Metadata;
using System.Text;

namespace Exercize03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.6");
            Exercise5(text);
        }
        #endregion






        private static void Exercise1(string text) {
            var cou = text.Count(c => c == ' ');
            Console.WriteLine(cou);
        }

        private static void Exercise2(string text) {
            var sr = text.Replace("big", "small");
            Console.WriteLine(sr);
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            var sb = new StringBuilder(array[0]);
            foreach (var word in array.Skip(1)) {
                sb.Append(" ");
                sb.Append(word);
            }
            var str = sb.ToString().TrimEnd();
            Console.WriteLine(sb + ".");
        }

        private static void Exercise4(string text) {
            var words = text.Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine("単語数" + words);
        }

        private static void Exercise5(string text) {
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(c => c.Length <= 4);
            foreach(var c in words) {
                Console.WriteLine(c);
            }           

        }
        private static void Exercize6(string text) {

            Console.WriteLine("出現アルファベットの個数");
            var str = text.ToLower();
            for (char c = 'a'; c <= 'z'; c++) {
                Console.WriteLine(c + ";" + str.Count(ct => ct == c));
            }
        }

    }
}
