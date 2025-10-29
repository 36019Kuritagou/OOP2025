
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
                .GroupBy(book => book.PublishedYear)
                .OrderBy(group => group.Key)
                .Select(group => new {
                    Year = group.Key,
                    Count = group.Count()
                });
            
            foreach (var item in bookCountByYear) {
                Console.WriteLine($"発行年: {item.Year}, 冊数: {item.Count}");
            }
        }

        private static void Exercise1_4() {
            var sortedBooks = Library.Books
            .OrderByDescending(book => book.PublishedYear)
            .ThenByDescending(book => book.Price);

            foreach (var book in sortedBooks) {
                Console.WriteLine(book);
            }

        }

        private static void Exercise1_5() {
            
        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {
            
        }
    }
}
