using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }        

        private async Task button1_Click(object sender, EventArgs e) {
            ToolStripLabel1.text = "";
            await DoLongTimeWork();
            ToolStripLabel1.text = "èIóπ";
        }
    }
}
