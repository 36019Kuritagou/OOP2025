
namespace Exercize01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();

            Exercise1_3();
            Console.WriteLine();

            Exercise1_4();
            Console.WriteLine();

            Exercise1_5();
            Console.WriteLine();

            Exercise1_6();
            Console.WriteLine();

            Exercise1_7();
            Console.WriteLine();

            Exercise1_8();
            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var mostExpensiveBook = Library.Books
                .OrderByDescending(book => book.Price)
                .FirstOrDefault();       
                Console.WriteLine(mostExpensiveBook);
            

            }

        private static void Exercise1_3() {
            var bookCountByYear = Library.Books
                .GroupBy(b => b.PublishedYear)
                .OrderBy(b => b.Key)
                .Select(b => new {
                    PublishdYear = b.Key,
                    Count = b.Count()
                });
            
            foreach (var item in bookCountByYear) {
                Console.WriteLine($"発行年: {item.PublishdYear}, 冊数: {item.Count}");
            }
        }

        private static void Exercise1_4() {
            var sortedBooks = Library.Books
            .OrderByDescending(book => book.PublishedYear)
            .ThenByDescending(book => book.Price);

            foreach (var book in sortedBooks) {
                Console.WriteLine($"{book.PublishedYear}年,{book.Price}円, {book.Title}");
            }

        }

        private static void Exercise1_5() {
            var categoryIds2022 = Library.Books
                .Where(book => book.PublishedYear == 2022)
                .Select(book => book.CategoryId)
                .Distinct();
            
            var categories2022 = Library.Categories
                .Where(category => categoryIds2022.Contains(category.Id));
            
            foreach (var category in categories2022) {
                Console.WriteLine(category);
            }
        }

        private static void Exercise1_6() {
            var groupedBooks = Library.Books
                .GroupBy(book => book.CategoryId)
                .OrderBy(group => group.Key);

            foreach (var group in groupedBooks) {
                // カテゴリ名を取得
                var categoryName = Library.Categories
                    .First(c => c.Id == group.Key).Name;

                Console.WriteLine($"# { categoryName}");

                // タイトル順に並び替えて出力
                foreach (var book in group.OrderBy(b => b.Title)) {
                    Console.WriteLine(book.ToString());
                }
            }
            }

        private static void Exercise1_7() {
            var developmentCategoryId = Library.Categories
                .First(c => c.Name == "Development").Id;

            // Developmentカテゴリの書籍を発行年ごとに分類
            var groupedBooks = Library.Books
                .Where(b => b.CategoryId == developmentCategoryId)
                .GroupBy(b => b.PublishedYear)
                .OrderBy(g => g.Key);

            // 結果をコンソールに出力
            foreach (var group in groupedBooks) {
                Console.WriteLine($"# {group.Key}");
                foreach (var book in group) {
                    Console.WriteLine(book.Title);
                }
            }
        }

        private static void Exercise1_8() {
            var result = Library.Categories
            .GroupJoin(
                Library.Books,
                category => category.Id,
                book => book.CategoryId,
                (category, books) => new {
                    CategoryName = category.Name,
                    BookCount = books.Count()
                }
            )
            .Where(x => x.BookCount >= 4)
            .Select(x => x.CategoryName);

            foreach (var name in result) {
                Console.WriteLine(name);
            }
        }

    }
}

