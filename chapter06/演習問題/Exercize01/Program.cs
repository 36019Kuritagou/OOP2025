using System.Globalization;

namespace Exercize01 {
    internal class Program {
        static void Main(string[] args) {            

            var target = "C# Programming";
            var idExists = target.All(c => Char.IsLower(c));
            
        }
    }
}
