
namespace Exercize01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);
        }

        private static void Exercise1(string text) {
            var count = new Dictionary<char, int>();
            foreach (var c in text.ToUpper()) {
                if ('A' <= c && c <= 'Z') {
                    if (count.ContainsKey(c)) {
                        count[c]++;
                    } else {
                        count[c] = 1;
                    }
                }
            }
            foreach (var a in count.OrderBy(b => b.Key)) {
                Console.WriteLine($"{a.Key}:{a.Value}");
            }


        }

        private static void Exercise2(string text) {
            var count = new SortedDictionary<char, int>();
            foreach (var c in text.ToUpper()) {
                if ('A' <= c && c <= 'Z') {
                    if (count.ContainsKey(c)) {
                        count[c]++;
                    } else {
                        count[c] = 1;
                    }
                }
            }
            foreach (var a in count) {
                Console.WriteLine($"{a.Key}:{a.Value}");
            }



        }
    }
}
