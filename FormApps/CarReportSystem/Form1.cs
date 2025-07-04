using System.ComponentModel;

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
            if (author = null) {
                author.Items.Add(author);
         
            }
            //���o�^�Ȃ�o�^�y�o�^�ςȂ牽�����Ȃ��z
            
        }

        private void setCbCarName(string carName) {
            cbCarname.Items.Add(carName);
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {
            var carReport = new CarReport {
                Date = dateTimePicker1.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarname.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image
            };
            ListCarReports.Add(carReport);
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

        private CarReport.MakerGroup GetRadioButtonMaker() {
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
            ListCarReports = null;
        }

        //�C���{�^���̃C���f���g�n���h��
        private void btRecordModify_Click(object sender,EventArgs e) {

        }
        
        //�폜�{�^���̃C���f���g�n���h��
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //�J�[���|�[�g�Ǘ��p���X�g����A
            //�Y������f�[�^���폜����

        }
    }
}
