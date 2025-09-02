using System.Text.RegularExpressions;

namespace Exercize04 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");

            var newlines = lines.Select(line => Regex.Replace(line, @"v4\.0""", @"v5.0"));

            File.WriteAllLines("sampleChange.txt", newlines);

            var text = File.ReadAllText("sampleChange.txt");
            Console.WriteLine(text);
        }
    }
}
    

