

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1();
            Console.WriteLine("---");
            Exercise2();
            Console.WriteLine("---");
            Exercise3();
        }

        private static void Exercise1() {
            Console.WriteLine("入力値　：");
            var stringNumber = Console.ReadLine();
            if (int.TryParse(stringNumber, out int number)) {
                if (number < 0) {
                    Console.WriteLine(number);
                }else if (number <100) {
                    Console.WriteLine(number * 2);
                }else if (number < 500) {
                    Console.WriteLine(number * 3);
                }else if (number >= 500) {
                    Console.WriteLine(number);
                }
            }else {
                Console.WriteLine("入力値に誤りがあります");
            }
        }

        private static void Exercise2() {
            
        }

        private static void Exercise3() {
            
        }
    }
}
