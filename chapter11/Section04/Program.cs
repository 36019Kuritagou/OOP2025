namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");

            var newlines =

                File.WriteAllLines("sampleChange.txt", newlines);

            var text = File.ReadAllText("sampleChange.txt");
            Console.WriteLine(text);
        }
    }
}
