using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();

            cbUrl.DisplayMember = "Key";
            cbUrl.ValueMember = "Value";

            cbUrl.Items.Add(new KeyValuePair<string, string>("����", "https://news.yahoo.co.jp/rss/categories/domestic.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("����", "https://news.yahoo.co.jp/rss/categories/world.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("�o��", "https://news.yahoo.co.jp/rss/categories/business.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("�G���^��", "https://news.yahoo.co.jp/rss/categories/entertainment.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("�X�|�[�c", "https://news.yahoo.co.jp/rss/categories/sports.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("IT", "https://news.yahoo.co.jp/rss/categories/it.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("�Ȋw", "https://news.yahoo.co.jp/rss/categories/science.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("���C�t", "https://news.yahoo.co.jp/rss/categories/life.xml"));
            cbUrl.Items.Add(new KeyValuePair<string, string>("�n��", "https://news.yahoo.co.jp/rss/categories/local.xml"));

            cbUrl.SelectedIndex = 0;
            if (cbUrl.Items.Count > 0) {
                cbUrl.SelectedIndex = 0;
            }

            // �C�x���g�o�^
            btRegistration.Click += btRegistration_Click;
            btDelete.Click += tbDelete_Click;
        }

        private async void btRssGet_Click_1(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                var selected = (KeyValuePair<string, string>)cbUrl.SelectedItem;
                string xml = await hc.GetStringAsync(selected.Value);
                XDocument xdoc = XDocument.Parse(xml);

                //var url = hc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url); //RSS�̎擾

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link")
                    }).ToList();

                //���X�g�{�b�N�X�փ^�C�g����\��
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "�f�[�^�Ȃ�"));

            }
        }




        private void lbTitles_Click(object sender, EventArgs e) {

            if (lbTitles.SelectedIndex < 0 || lbTitles.SelectedIndex >= items.Count) return;
            string link = items[lbTitles.SelectedIndex].Link;
            if (!string.IsNullOrEmpty(link)) {
                wvRssLink.Source = new Uri(link);
            }
        }

        //�߂�
        private void btReturn_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();

        }

        //�i��
        private void btMove_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();

        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btReturn.Enabled = wvRssLink.CanGoBack;
            btMove.Enabled = wvRssLink.CanGoForward;
        }



        // ���C�ɓ���o�^
        private void btRegistration_Click(object sender, EventArgs e) {
            string url = tbFavorite.Text.Trim();
            if (string.IsNullOrEmpty(url)) {
                MessageBox.Show("�o�^����URL����͂��Ă��������B");
                return;
            }

            if (!cbUrl.Items.Contains(url)) {
                cbUrl.Items.Add(url);
                MessageBox.Show("���C�ɓ���ɓo�^���܂����B");
            } else {
                MessageBox.Show("���łɓo�^����Ă��܂��B");
            }
        }

        //���C�ɓ���폜
        private void tbDelete_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedItem == null) {
                MessageBox.Show("�폜����URL��I�����Ă��������B");
                return;
            }

            string url = cbUrl.SelectedItem.ToString();
            if (MessageBox.Show($"�u{url}�v���폜���܂����H", "�m�F", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                cbUrl.Items.Remove(url);
                if (cbUrl.Items.Count > 0) {
                    cbUrl.SelectedIndex = 0;
                }
            }
        }

        private void lbTitles_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {
            cbUrl.SelectedIndex = -1;
        }
    }
}
