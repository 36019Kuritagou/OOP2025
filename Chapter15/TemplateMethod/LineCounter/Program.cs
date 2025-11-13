using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            string filePath;

            if (args.Length > 0) {
                filePath = args[0];
            } else {
                Console.Write("処理するファイルのパスを入力してください: ");
                filePath = Console.ReadLine() ?? "";
            }

            if (!File.Exists(filePath)) {
                Console.WriteLine("指定されたファイルが存在しません。");
                return;
            }

            TextProcessor.Run<LineCounterProcessor>(filePath);
        }
    }
}