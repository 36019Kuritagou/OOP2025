using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Section01 {
    internal class Program {

        static void Main(string[] args) {

            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var lowerList = cities.ConvAll(s => s.Length <= 5);

            foreach (var s in names) {
                Console.WriteLine(s);
            }

        }
    }
}

