using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            string filePath = "走れメロス.txt"; // フルパスにするか、実行ファイルと同じ場所に置く

            try {
                string content = await ReadFileAsync(filePath);
                textBox1.Text = content;
                toolStripStatusLabel1.Text = "読み込み成功";
            }
            catch (Exception ex) {
                MessageBox.Show($"ファイルの読み込み中にエラーが発生しました: {ex.Message}");
                toolStripStatusLabel1.Text = "読み込み失敗";
            }
        }

        private async Task<string> ReadFileAsync(string path) {
            // Shift-JISなどの文字コードを指定する場合はこちら
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8)) {
                return await reader.ReadToEndAsync();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {
            // ステータスバーをクリックしたときの処理（必要なら実装）
        }
    }
}
