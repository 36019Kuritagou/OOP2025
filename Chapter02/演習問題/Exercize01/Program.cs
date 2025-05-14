namespace Exercize01 {
    internal class Program {
        static void Main(string[] args) {

            var songs = new List<Song>();

            Console.WriteLine("******曲の登録*****");
            while (true) {
                Console.Write("曲名:");
                string title = Console.ReadLine();

                if (title.Equals("end", StringComparison.OrdinalIgnoreCase))
                    break;


                Console.Write("アーティスト名:");
                string artistName = Console.ReadLine();

                Console.Write("演奏時間:");
                int length = int.Parse(Console.ReadLine());

                // Song song = new Song(title, artistName, length);
                Song song = new Song() {
                    Title = title,
                    ArtistName = artistName,
                    Length = length
                };

                songs.Add(song);

                Console.WriteLine();

            }
             printSongs(songs);
        }











        //new Song("Let it be", "The Beatles", 243),
        //new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
        //new Song("Close To You", "Carpenters", 276),
        //new Song("Honesty", "Billy Joel", 231),
        //new Song("I Will Always Love You", "Whitney Houston", 273),
        //};

        //2.1.3



        //2.1.4
        private static void printSongs(IEnumerable<Song> songs) {

            //foreach (var song in songs) {
            //    var minutes = song.Length / 60;
            //    var seconds = song.Length % 60;
            //    Console.WriteLine($"{song.Title},{song.ArtistName} {minutes}:{seconds:00}");

            //}
            //#else
            //TimeSpan構造体を使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title},{song.ArtistName}, 演奏時間 {timespan.Minutes}:{timespan.Seconds:00}");

                //            }
                //#endif
                //            Console.WriteLine();
                //        }


            }
        }
    }
}

