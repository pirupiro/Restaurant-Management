using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmThemBoBan : MetroForm
    {
        public int Number { get; set; }

        public frmThemBoBan(string command, int numOfTables)
        {
            InitializeComponent();

            if (command == "Thêm")
            {
                Text = "THÊM BÀN";
            }
            else
            {
                Text = "BỎ BÀN";
                numericUpDown.Maximum = numOfTables;
            }

            label1.Text = "Hiện có: " + numOfTables + " bàn";
            label2.Text = command;
        }

        private void okTile_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Number = (int)numericUpDown.Value;
            MetroMessageBox.Show(this, label2.Text + " bàn thành công", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void huyTile_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
