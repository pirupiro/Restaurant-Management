using BUS;
using DTO;
using MetroFramework;
using MetroFramework.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmChinhSuaNhanVien : MetroForm
    {
        NhanVien employee;

        public frmChinhSuaNhanVien(NhanVien nhanvien)
        {
            InitializeComponent();
            employee = nhanvien;
        }

        private void frmChinhSuaNhanVien_Load(object sender, System.EventArgs e)
        {
            Text = "Thông tin của nhân viên " + employee.HoTen;
            hoTenTextBox.Text = employee.HoTen;
            ngaySinhDateTime.Value = employee.NgaySinh;
            
            if (employee.GioiTinh == "Nam")
            {
                namRadioButton.Checked = true;
            }
            else
            {
                nuRadioButton.Checked = true;
            }

            diaChiTextBox.Text = employee.DiaChi;
            sdtTextBox.Text = employee.SoDienThoai;
            ngayVaoLamDateTime.Value = employee.NgayVaoLam;
            chucVuComboBox.SelectedItem = employee.ChucVu;
            luongTextBox.Text = employee.Luong.ToString();
        }

        private void suaTile_Click(object sender, System.EventArgs e)
        {
            if (hoTenTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Họ tên không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((string)chucVuComboBox.SelectedItem == string.Empty)
            {
                MetroMessageBox.Show(this, "Nhân viên phải có chức vụ.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (sdtTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Số điện thoại không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (luongTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Lương không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (diaChiTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Địa chỉ không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(sdtTextBox.Text, "^[0-9]*$"))
            {
                MetroMessageBox.Show(this, "Số điện thoại chỉ được dùng số.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(luongTextBox.Text, "^[0-9]*$"))
            {
                MetroMessageBox.Show(this, "Lương chỉ được dùng số.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                employee.HoTen = hoTenTextBox.Text;
                employee.NgaySinh = ngaySinhDateTime.Value;

                if (namRadioButton.Checked)
                {
                    employee.GioiTinh = "Nam";
                }
                else
                {
                    employee.GioiTinh = "Nữ";
                }

                employee.DiaChi = diaChiTextBox.Text;
                employee.SoDienThoai = sdtTextBox.Text;
                employee.NgayVaoLam = ngayVaoLamDateTime.Value;
                employee.ChucVu = chucVuComboBox.SelectedItem.ToString();
                employee.Luong = int.Parse(luongTextBox.Text);

                if (EmployeeBUS.Update(employee) > 0)
                {
                    MetroMessageBox.Show(this, "Cập nhật dữ liệu nhân viên thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MetroMessageBox.Show(this, "Cập nhật dữ liệu nhân viên thất bại.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void huyTile_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
