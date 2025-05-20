

using System.Xml.Linq;

namespace Exercize02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            do {
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    break;
                int index = names.FindIndex(s => s.Equals(name));
                Console.WriteLine(index);
            } while (true);
        }

        //private static void Exercise2_1(List<string> cities) {
        //    Console.WriteLine("都市名を入力。空行で終了");

        //    string name;
        //    do {
        //        name = Console.ReadLine();

        //        if (!string.IsNullOrEmpty(name)) {
        //            int index = cities.FindIndex(city => city == name);
        //            if (index >= 0) {
        //                Console.WriteLine(index);
        //            } else {
        //                Console.WriteLine(-1);
        //            }
        //        }

        //    } while (!string.IsNullOrEmpty(name));
        //}




        private static void Exercise2_2(object names) {
            
        }

        private static void Exercise2_3(object names) {

        }

        private static void Exercise2_4(object names) {
            
        }

       


       
    }
}
