using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> ListCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = ListCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void setCbAuthor(string author) {
            //既に登録済か確認
            if (!cbAuthor.Items.Contains(author)) {
            }
            //未登録なら登録【登録済なら何もしない】
            cbAuthor.Items.Add(author);
        }

        private void setCbCarName(string carName) {
            if (!cbCarname.Items.Contains(carName)) {
                cbCarname.Items.Add(carName);
            }
        }


        private void btRecordAdd_Click(object sender, EventArgs e) {

            tsslbMessage.Text = String.Empty;
            if (cbAuthor.Text == string.Empty || cbCarname.Text == String.Empty) {
                tsslbMessage.Text = "記録者、または車名が未登録です";
                return;
            }


            var carReport = new CarReport {
                Date = dateTimePicker1.Value,
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarname.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            ListCarReports.Add(carReport);
            setCbCarName(cbCarname.Text);
            setCbAuthor(cbAuthor.Text);
            InputItemsAllClear();  //登録後は項目をクリア
        }

        private void InputItemsAllClear() {
            dateTimePicker1.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarname.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }

        private CarReport.MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;

            return CarReport.MakerGroup.その他;
        }

        private void dgvRecord_Click(object sender, EventArgs e) {
            dateTimePicker1.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtoMaker((CarReport.MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarname.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;

        }
        private void setRadioButtoMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;

                default:
                    rbOther.Checked = true;
                    break;
            }
        }
        //新規追加のインデントハンドラ
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //修正ボタンのインデントハンドラ
        private void btRecordModify_Click_1(object sender, EventArgs e) {
            if (dgvRecord.Rows.Count == 0) return;

            ListCarReports[dgvRecord.CurrentRow.Index].Date = dateTimePicker1.Value;
            ListCarReports[dgvRecord.CurrentRow.Index].Author = cbAuthor.Text;
            ListCarReports[dgvRecord.CurrentRow.Index].Maker = getRadioButtonMaker();
            ListCarReports[dgvRecord.CurrentRow.Index].CarName = cbCarname.Text;
            ListCarReports[dgvRecord.CurrentRow.Index].Report = tbReport.Text;
            ListCarReports[dgvRecord.CurrentRow.Index].Picture = pbPicture.Image;
            dgvRecord.Refresh();
        }

        //削除ボタンのインデントハンドラ
        private void btRecordDelete_Click_1(object sender, EventArgs e) {
            /*int index = dgvRecord.CurrentRow.Index;
            ListCarReports.RemoveAt(index);*/
            if ((dgvRecord.CurrentRow == null)
                || (!dgvRecord.CurrentRow.Selected)) return;
        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.Pink;

        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();            
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.ShowDialog();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                //選択された色の取得
                this.BackColor = cd.Color;
            }
        }
    }
}
