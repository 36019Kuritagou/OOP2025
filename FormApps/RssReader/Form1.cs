using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var wc = HttpClient()) {

                string xml = await wc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //var url = wc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url); //RSSの取得

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item").
                    Select(x => new ItemData {
                        Title = (string)x.Element("title"),
                        Link = (string)x.Element("link"),
                    }).ToList();

                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));

                
            }
        }
    }
}
