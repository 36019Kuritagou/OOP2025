using System;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string _keyword = "";

        protected override void Initialize(string fname) {
            Console.Write("カウントする単語を入力してください: ");
            _keyword = Console.ReadLine() ?? "";
            _count = 0;
        }

        protected override void Execute(string line) {
            // 単語の出現回数をカウント（大文字小文字を区別しない）
            _count += line.Split(new[] { ' ', '\t', ',', '.', ';', '(', ')', '{', '}', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
                          .Count(word => string.Equals(word, _keyword, StringComparison.OrdinalIgnoreCase));
        }

        protected override void Terminate() {
            Console.WriteLine($"\"{_keyword}\" の出現回数: {_count} 回");
        }
    }
}