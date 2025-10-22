using SQLite;
using System.IO;
using System.Windows.Media.Imaging;

namespace Sample.Data {
    public class Person {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public byte[] Picture { get; set; }

        public BitmapImage PictureImage {
            get {
                if (Picture == null) return null;
                using (var ms = new MemoryStream(Picture)) {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
        }
    }
}