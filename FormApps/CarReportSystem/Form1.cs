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
            //���ɓo�^�ς��m�F
            if (!cbAuthor.Items.Contains(author)) {
            }
            //���o�^�Ȃ�o�^�y�o�^�ςȂ牽�����Ȃ��z
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
                tsslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ������o�^�ł�";
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
            InputItemsAllClear();  //�o�^��͍��ڂ��N���A
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
                return CarReport.MakerGroup.�g���^;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.���Y;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.�X�o��;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.�z���_;
            if (rbImport.Checked)
                return CarReport.MakerGroup.�A����;

            return CarReport.MakerGroup.���̑�;
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
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;

                default:
                    rbOther.Checked = true;
                    break;
            }
        }
        //�V�K�ǉ��̃C���f���g�n���h��
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //�C���{�^���̃C���f���g�n���h��
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

        //�폜�{�^���̃C���f���g�n���h��
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

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                //�I�����ꂽ�F�̎擾
                this.BackColor = cd.Color;
            }
        }
    }
}
