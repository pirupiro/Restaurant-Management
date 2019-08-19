using BUS;
using DTO;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmDoiMatKhau : MetroForm
    {
        DangNhap login;

        public frmDoiMatKhau(DangNhap l)
        {
            InitializeComponent();
            login = l;
        }

        private void tkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                okTile_Click(sender, e);
        }

        private void mkhtTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                okTile_Click(sender, e);
        }

        private void mkmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                okTile_Click(sender, e);
        }

        private void showCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showCheckBox.Checked)
            {
                mkmTextBox.UseSystemPasswordChar = false;
                mkmTextBox.PasswordChar = '\0';
                nlTextBox.UseSystemPasswordChar = false;
                nlTextBox.PasswordChar = '\0';
            }
            else
            {
                mkmTextBox.UseSystemPasswordChar = true;
                nlTextBox.UseSystemPasswordChar = true;
            }
        }

        private void okTile_Click(object sender, EventArgs e)
        {
            if (mkhtTextBox.Text == string.Empty || mkmTextBox.Text == string.Empty || nlTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Mật khẩu không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(mkhtTextBox.Text, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(mkmTextBox.Text, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(nlTextBox.Text, "^[a-zA-Z0-9]*$"))
            {
                MetroMessageBox.Show(this, "Mật khẩu không được chứa kí tự đặc biệt." + "\n" + "Chỉ được sử dụng a-z, A-Z, 0-9.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (login.MatKhau == mkhtTextBox.Text)
                {
                    if (mkmTextBox.Text == nlTextBox.Text)
                    {
                        if (LoginBUS.UpdatePassword(login.TaiKhoan, mkmTextBox.Text) > 0)
                        {
                            MetroMessageBox.Show(this, "Đổi mật khẩu thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Đổi mật khẩu thất bại.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Mật khẩu không trùng khớp.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Mật khẩu hiện tại không chính xác.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void huyTile_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
