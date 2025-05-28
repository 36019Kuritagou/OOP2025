namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //本の平均金額を表示
            Console.WriteLine(books.Average(b => b.Price));

            //本のページ合計を表示
            Console.WriteLine(books.Sum(b => b.Pages));

            //金額の安い書籍名と金額を表示            
            //var minprice = books.Min(b => b.Price);
            //var bo = books.Where(b => b.Price == minprice);
            //foreach (var b in bo) {
            //    Console.WriteLine("金額の安い書籍 :" + b.Title + "   金額 :" + b.Price);
            //}
            var minprice = books.Where(x => x.Price == books.Min(b => b.Price));
            foreach (var item in minprice) {
                Console.WriteLine(item.Title + ":" + item.Price);
            }

            //ページが多い書籍名とページ数を表示
            //var maxpages = books.Max(b => b.Pages);
            //var bp = books.Where(b => b.Pages == maxpages);
            //foreach (var bb in bp) {
            //    Console.WriteLine("ページが多い書籍名 :" + bb.Title + "   ページ数" + bb.Pages);
            //}
            books.Where(x => x.Pages == books
            .Max(b => b.Pages)).ToList()
            .ForEach(x => Console.WriteLine($"{x.Title} : {x.Pages}ページ"));

            //タイトルに「物語」が含まれている書籍名をすべて表示
            var titles = books.Where(b => b.Title.Contains("物語"));
            foreach (var t in titles) {
                Console.WriteLine(t.Title);
            }
            
        }
    }
}
