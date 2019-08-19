using BUS;
using DTO;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmDangNhap : MetroForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void tkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dnTile_Click(sender, e);
            }
        }

        private void mkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dnTile_Click(sender, e);
            }
        }

        private void dnTile_Click(object sender, EventArgs e)
        {
            if (tkTextBox.Text == string.Empty || mkTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Tài khoản và mật khẩu không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(tkTextBox.Text, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(mkTextBox.Text, "^[a-zA-Z0-9]*$"))
            {
                MetroMessageBox.Show(this, "Tài khoản và mật khẩu không được chứa kí tự đặc biệt.\nChỉ được sử dụng a-z, A-Z, 0-9.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (LoginBUS.Has(tkTextBox.Text, mkTextBox.Text))
                {
                    MetroForm form;
                    DangNhap login = LoginBUS.GetAccount(tkTextBox.Text);
                    NhanVien employee = EmployeeBUS.GetEmployee(login.MaNhanVien);

                    if (employee.ChucVu == "Quản lý")
                    {
                        form = new frmQuanLy(login);
                    }
                    else if (employee.ChucVu == "Thu ngân")
                    {
                        form = new frmDatBan(login);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Bạn không có quyền truy cập.", "Not eligible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MetroMessageBox.Show(this, "Đăng nhập thành công.", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        tkTextBox.Text = "";
                        mkTextBox.Text = "";
                        ActiveControl = tkTextBox;
                        Show();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Tài khoản hoặc mật khẩu không chính xác.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
