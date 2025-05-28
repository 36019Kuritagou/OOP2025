
namespace Exercize02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
    new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
    new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
    new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
    new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
    new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
    new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
    new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
};

            Console.WriteLine("7.2.1");
            Exercise1(books);

            Console.WriteLine("7.2.2");
            Exercise2(books);

            Console.WriteLine("7.2.3");
            Exercise3(books);

            Console.WriteLine("7.2.4");
            Exercise4(books);

            Console.WriteLine("7.2.5");
            Exercise5(books);

            Console.WriteLine("7.2.6");
            Exercise6(books);

            Console.WriteLine("7.2.7");
            Exercise7(books);
        }

        private static void Exercise1(List<Book> books) {
            var titles = books.Where(b => b.Title.Contains("ワンダフル・C#ライフ"));
            foreach (var t in titles) {
                Console.WriteLine(t.Title + "金額 :" + t.Price + " ページ数 :" + t.Pages);
            }
        }

        private static void Exercise2(List<Book> books) {
            var countbooks = books.Count(b => b.Title.Contains("C#"));         
                Console.WriteLine(countbooks + "冊");
            
        }

        private static void Exercise3(List<Book> books) {
            var avgpages = books.Where(b => b.Title.Contains("C#")).Average(b => b.Pages);            
            Console.WriteLine(avgpages + "ページ");           
        }

        private static void Exercise4(List<Book> books) {
            var aprice = books.FirstOrDefault(b => b.Price >= 4000);
            Console.WriteLine(aprice.Title);
        }

        private static void Exercise5(List<Book> books) {
            var bprice = books.Where(b => b.Price < 4000).Max(b => b.Pages);
            Console.WriteLine(bprice + "ページ");
        }

        private static void Exercise6(List<Book> books) {
            var cprice = books.Where(b => b.Pages >= 400).OrderByDescending(b => b.Price);
            foreach(var c in cprice) {
                Console.WriteLine(c.Title + c.Price + "円");
            }
        }

        private static void Exercise7(List<Book> books) {
            var dprice = books.Where(b => b.Title.Contains("C#")&& b.Pages <= 500);
            foreach(var dp in dprice) {
                Console.WriteLine(dp.Title);
            }
        }
    }
}
