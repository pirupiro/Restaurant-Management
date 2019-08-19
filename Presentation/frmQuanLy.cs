using BUS;
using DTO;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmQuanLy : MetroForm
    {
        DangNhap login;
        int maxPageNumber;
        int currentPageNumber;
        int minYear;
        int maxYear;

        public frmQuanLy(DangNhap l)
        {
            InitializeComponent();
            login = l;
            billsPerPageComboBox.SelectedItem = billsPerPageComboBox.Items[0];
            currentPageNumber = 1;
            thangComboBox.SelectedItem = thangComboBox.Items[0];
        }
    
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabNhanVien;
            maxPageNumber = BillBUS.GetMaxPageNumber(int.Parse(billsPerPageComboBox.Text));
            maxPageNumberLabel.Text = "/ " + maxPageNumber.ToString();
            
            if (maxPageNumber == 1)
            {
                sauTile.Visible = false;
            }

            minYear = BillBUS.GetMinYear();
            maxYear = BillBUS.GetMaxYear();

            for (int i = minYear; i <= maxYear; i++)
            {
                namComboBox.Items.Add(i);
            }

            if (namComboBox.Items.Count > 0)
            {
                namComboBox.SelectedItem = namComboBox.Items[namComboBox.Items.Count - 1];
            }
            else
            {
                namComboBox.SelectedItem = 1;
            }

            namRadioButton.Checked = true;

            dgv1.DataSource = EmployeeBUS.LoadAll();
            dgv2.DataSource = MenuBUS.LoadAll();
            dgv3.DataSource = BillBUS.LoadAll(1, int.Parse(billsPerPageComboBox.Text));
            dgv5.DataSource = LoginBUS.LoadAll();

            // Đặt tên cột cho DataGridView 1
            dgv1.Columns[0].HeaderText = "Mã";
            dgv1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns[1].HeaderText = "Họ tên";
            dgv1.Columns[2].HeaderText = "Ngày sinh";
            dgv1.Columns[3].HeaderText = "Giới tính";
            dgv1.Columns[4].HeaderText = "Địa chỉ";
            dgv1.Columns[5].HeaderText = "Số điện thoại";
            dgv1.Columns[6].HeaderText = "Ngày vào làm";
            dgv1.Columns[7].HeaderText = "Chức vụ";
            dgv1.Columns[8].HeaderText = "Lương";
            dgv1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          
            // Đặt tên cột cho DataGridView 2
            dgv2.Columns[0].HeaderText = "Tên món";
            dgv2.Columns[1].HeaderText = "Đơn giá";
            dgv2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv2.Columns[2].HeaderText = "Đơn vị";

            // Đặt tên cột cho DataGridView 3
            dgv3.Columns[0].HeaderText = "Mã HD";
            dgv3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv3.Columns[1].HeaderText = "Mã bàn";
            dgv3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv3.Columns[2].HeaderText = "Mã NV";
            dgv3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv3.Columns[3].HeaderText = "Thời gian lập";
            dgv3.Columns[4].HeaderText = "Tổng tiền";
            dgv3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt tên cột cho DataGridView 5
            dgv5.Columns[0].HeaderText = "Tài khoản";
            dgv5.Columns[1].HeaderText = "Họ tên";
            dgv5.Columns[2].HeaderText = "Quyền";
        }

        #region Tool strip menu item
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau form = new frmDoiMatKhau(login))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    login = LoginBUS.GetAccount(login.TaiKhoan);
                }
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog =  MetroMessageBox.Show(this, "Bạn muốn đăng xuất khỏi chương trình ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dialog == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void themBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmThemBoBan form = new frmThemBoBan("Thêm", TableBUS.GetNumberOfTables()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TableBUS.Insert(TableBUS.GetNumberOfTables(), form.Number);
                }
            }
        }

        private void boBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmThemBoBan form = new frmThemBoBan("Bỏ", TableBUS.GetNumberOfTables()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TableBUS.Delete(form.Number);
                }
            }
        }
        #endregion

        #region Nhân viên
        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!nhanVienCuToggle.Checked)
            {
                if (e.RowIndex >= 0)
                {
                    using (frmChinhSuaNhanVien form = new frmChinhSuaNhanVien(EmployeeBUS.GetEmployee((int)dgv1.CurrentRow.Cells[0].Value)))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            dgv1.DataSource = EmployeeBUS.LoadAll();
                        }
                    }
                }
            }
        }

        private void timKiemTextBox1_TextChanged(object sender, EventArgs e)
        {
            dgv1.DataSource = EmployeeBUS.LoadAll(timKiemTextBox1.Text, nhanVienCuToggle.Checked);
        }

        private void xoaTile1_Click(object sender, EventArgs e)
        {
            if (!nhanVienCuToggle.Checked)
            {
                DialogResult dialog = MetroMessageBox.Show(this, "Bạn muốn xóa nhân viên " + (string)dgv1.CurrentRow.Cells[1].Value + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    if (EmployeeBUS.Delete((int)dgv1.CurrentRow.Cells[0].Value) > 0)
                    {
                        MetroMessageBox.Show(this, "Xóa nhân viên thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv1.DataSource = EmployeeBUS.LoadAll();
                        dgv5.DataSource = LoginBUS.LoadAll();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Xóa nhân viên thất bại.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void themTile1_Click(object sender, EventArgs e)
        {
            if (!nhanVienCuToggle.Checked)
            {
                using (frmThemNhanVien form = new frmThemNhanVien())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        dgv1.DataSource = EmployeeBUS.LoadAll();
                    }
                }
            }
        }

        private void nhanVienCuToggle_CheckedChanged(object sender, EventArgs e)
        {
            dgv1.DataSource = EmployeeBUS.LoadAll(string.Empty, nhanVienCuToggle.Checked);
        }
        #endregion

        #region Món ăn
        private void dgv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tenMonTextBox2.Text = dgv2.CurrentRow.Cells[0].Value.ToString();
                donGiaTextBox2.Text = dgv2.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void timKiemTextBox2_TextChanged(object sender, EventArgs e)
        {
            dgv2.DataSource = MenuBUS.LoadAll(timKiemTextBox2.Text);
        }

        private void xoaTile2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MetroMessageBox.Show(this, "Bạn muốn xóa món " + (string)dgv2.CurrentRow.Cells[0].Value + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dialog == DialogResult.Yes)
            {
                if (MenuBUS.Delete((string)dgv2.CurrentRow.Cells[0].Value) > 0)
                {
                    MetroMessageBox.Show(this, "Xóa món thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv2.DataSource = MenuBUS.LoadAll();
                }
                else
                {
                    MetroMessageBox.Show(this, "Xóa món thất bại.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void themTile2_Click(object sender, EventArgs e)
        {
            if (tenMonTextBox1.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Tên món không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (donGiaTextBox1.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Đơn giá không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(donGiaTextBox1.Text, "^[0-9]*$"))
            {
                MetroMessageBox.Show(this, "Đơn giá chỉ được dùng số.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (donViComboBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Đơn vị không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ThucDon dish = new ThucDon(tenMonTextBox1.Text, int.Parse(donGiaTextBox1.Text), (string)donViComboBox.SelectedItem);

                try
                {
                    if (MenuBUS.Insert(dish) > 0)
                    {
                        MetroMessageBox.Show(this, "Thêm món mới thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tenMonTextBox1.Text = string.Empty;
                        donGiaTextBox1.Text = string.Empty;
                        dgv2.DataSource = MenuBUS.LoadAll();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Thêm món mới thất bại.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MetroMessageBox.Show(this, "Đã tồn tại món " + dish.TenMon + " trong thực đơn.\nKhông thể thêm mới.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        throw;
                }
            }
        }

        private void suaTile2_Click(object sender, EventArgs e)
        {
            if (donGiaTextBox2.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Đơn giá không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(donGiaTextBox2.Text, "^[0-9]*$"))
            {
                MetroMessageBox.Show(this, "Đơn giá chỉ được dùng số.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MenuBUS.UpdatePrice(tenMonTextBox2.Text, int.Parse(donGiaTextBox2.Text)) > 0)
                {
                    MetroMessageBox.Show(this, "Cập nhật giá món thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tenMonTextBox2.Text = string.Empty;
                    donGiaTextBox2.Text = string.Empty;
                    dgv2.DataSource = MenuBUS.LoadAll();
                }
                else
                {
                    MetroMessageBox.Show(this, "Món ăn không có trong thực đơn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Hóa đơn
        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgv4.DataSource = BillDetailBUS.LoadAll((int)dgv3.CurrentRow.Cells[0].Value);
                dgv4.Columns[0].Visible = false;
                dgv4.Columns[1].HeaderText = "Tên món";
                dgv4.Columns[2].HeaderText = "Số lượng";
                dgv4.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv4.Columns[3].HeaderText = "Thành tiền";
                dgv4.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void inHoaDonTile_Click(object sender, EventArgs e)
        {
            if (dgv3.Rows.Count > 0)
            {
                int maHoaDon = (int)dgv3.CurrentRow.Cells[0].Value;
                int maBan = (int)dgv3.CurrentRow.Cells[1].Value;
                int maNhanVien = (int)dgv3.CurrentRow.Cells[2].Value;

                frmThanhToan form = new frmThanhToan(maHoaDon, maBan, maNhanVien);
                form.Show();
            }
        }

        private void billsPerPageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            currentPageNumber = 1;
            pageNumberTextBox.Text = currentPageNumber.ToString();

            if (filterByTime.Checked)
            {
                maxPageNumber = BillBUS.GetMaxPageNumberByTime(int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
                dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
            }
            else
            {
                maxPageNumber = BillBUS.GetMaxPageNumber(int.Parse(billsPerPageComboBox.Text));
                dgv3.DataSource = BillBUS.LoadAll(currentPageNumber, int.Parse(billsPerPageComboBox.Text));
            }

            maxPageNumberLabel.Text = "/ " + maxPageNumber;
            truocTile.Visible = false;

            if (maxPageNumber == 1)
            {
                sauTile.Visible = false;
            }
            else
            {
                sauTile.Visible = true;
            }
        }

        private void pageNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (pageNumberTextBox.Text == string.Empty || !pageNumberTextBox.Text.All(char.IsDigit))
                {
                    pageNumberTextBox.Text = currentPageNumber.ToString();
                }
                else
                {
                    truocTile.Visible = true;
                    sauTile.Visible = true;
                    int result;

                    if (int.TryParse(pageNumberTextBox.Text, out result))
                    {
                        if (result < 1)
                        {
                            pageNumberTextBox.Text = 1.ToString();
                        }

                        if (result > maxPageNumber)
                        {
                            pageNumberTextBox.Text = maxPageNumber.ToString();
                        }
                    }
                    else
                    {
                        pageNumberTextBox.Text = currentPageNumber.ToString();
                    }

                    currentPageNumber = int.Parse(pageNumberTextBox.Text);

                    if (currentPageNumber == 1)
                    {
                        truocTile.Visible = false;
                    }

                    if (currentPageNumber == maxPageNumber)
                    {
                        sauTile.Visible = false;

                    }

                    if (filterByTime.Checked)
                    {
                        dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
                    }
                    else
                    {
                        dgv3.DataSource = BillBUS.LoadAll(currentPageNumber, int.Parse(billsPerPageComboBox.Text));
                    }
                }
            }
        }

        private void truocTile_Click(object sender, EventArgs e)
        {
            sauTile.Visible = true;
            currentPageNumber--;
            pageNumberTextBox.Text = currentPageNumber.ToString();

            if (filterByTime.Checked)
            {
                dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
            }
            else
            {
                dgv3.DataSource = BillBUS.LoadAll(currentPageNumber, int.Parse(billsPerPageComboBox.Text));
            }

            if (currentPageNumber == 1)
            {
                truocTile.Visible = false;
            }
        }

        private void sauTile_Click(object sender, EventArgs e)
        {
            truocTile.Visible = true;
            currentPageNumber++;
            pageNumberTextBox.Text = currentPageNumber.ToString();

            if (filterByTime.Checked)
            {
                dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
            }
            else
            {
                dgv3.DataSource = BillBUS.LoadAll(currentPageNumber, int.Parse(billsPerPageComboBox.Text));
            }

            if (currentPageNumber == maxPageNumber)
            {
                sauTile.Visible = false;
            }
        }

        private void filterByTime_CheckedChanged(object sender, EventArgs e)
        {
            tuDateTime.Enabled = !tuDateTime.Enabled;
            denDateTime.Enabled = !denDateTime.Enabled;
            currentPageNumber = 1;
            pageNumberTextBox.Text = currentPageNumber.ToString();

            if (filterByTime.Checked)
            {
                maxPageNumber = BillBUS.GetMaxPageNumberByTime(int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
                maxPageNumberLabel.Text = "/ " + maxPageNumber;
                dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
            }
            else
            {
                maxPageNumber = BillBUS.GetMaxPageNumber(int.Parse(billsPerPageComboBox.Text));
                maxPageNumberLabel.Text = "/ " + maxPageNumber;
                dgv3.DataSource = BillBUS.LoadAll(currentPageNumber, int.Parse(billsPerPageComboBox.Text));
            }

            truocTile.Visible = false;

            if (maxPageNumber == 1)
            {
                sauTile.Visible = false;
            }
            else
            {
                sauTile.Visible = true;
            }
        }

        private void tuDateTime_ValueChanged(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            pageNumberTextBox.Text = currentPageNumber.ToString();
            maxPageNumber = BillBUS.GetMaxPageNumberByTime(int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
            maxPageNumberLabel.Text = "/ " + maxPageNumber;
            dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);

            truocTile.Visible = false;

            if (maxPageNumber == 1)
            {
                sauTile.Visible = false;
            }
            else
            {
                sauTile.Visible = true;
            }
        }

        private void denDateTime_ValueChanged(object sender, EventArgs e)
        {
            currentPageNumber = 1;
            pageNumberTextBox.Text = currentPageNumber.ToString();
            maxPageNumber = BillBUS.GetMaxPageNumberByTime(int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);
            maxPageNumberLabel.Text = "/ " + maxPageNumber;
            dgv3.DataSource = BillBUS.LoadAllByTime(currentPageNumber, int.Parse(billsPerPageComboBox.Text), tuDateTime.Value, denDateTime.Value);

            truocTile.Visible = false;

            if (maxPageNumber == 1)
            {
                sauTile.Visible = false;
            }
            else
            {
                sauTile.Visible = true;
            }
        }
        #endregion

        #region Tài khoản
        private void xoaTile3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MetroMessageBox.Show(this, "Bạn muốn xóa tài khoản " + (string)dgv5.CurrentRow.Cells[0].Value + 
                                                             " của nhân viên " + (string)dgv5.CurrentRow.Cells[1].Value + " ?", 
                                                             "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                LoginBUS.DeleteAccount((string)dgv5.CurrentRow.Cells[0].Value);
                dgv5.DataSource = LoginBUS.LoadAll();
            }
        }

       
        private void taoTile_Click(object sender, EventArgs e)
        {
            if (manvTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Mã nhân viên không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tkTextBox.Text == string.Empty || mkTextBox.Text == string.Empty)
            {
                MetroMessageBox.Show(this, "Tài khoản và mật khẩu không được để trống.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(manvTextBox.Text, "^[0-9]*$"))
            {
                MetroMessageBox.Show(this, "Mã nhân viên phải là số.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Regex.IsMatch(tkTextBox.Text, "^[a-zA-Z0-9]*$") || !Regex.IsMatch(mkTextBox.Text, "^[a-zA-Z0-9]*$"))
            {
                MetroMessageBox.Show(this, "Tài khoản và mật khẩu không được chứa kí tự đặc biệt." + "\n" + "Chỉ được sử dụng a-z, A-Z, 0-9.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DangNhap login = new DangNhap(tkTextBox.Text, mkTextBox.Text, int.Parse(manvTextBox.Text));

                try
                {
                    if (LoginBUS.CreateAccount(login) > 0)
                    {
                        MetroMessageBox.Show(this, "Tạo tài khoản thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        manvTextBox.Text = string.Empty;
                        tkTextBox.Text = string.Empty;
                        mkTextBox.Text = string.Empty;
                        dgv5.DataSource = LoginBUS.LoadAll();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Tạo tài khoản thất bại.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MetroMessageBox.Show(this, "Mã nhân viên không tồn tai.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == 2627)
                    {
                        MetroMessageBox.Show(this, "Tài khoản đã tồn tại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        throw;
                }
            }
        }

        private void manvTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                taoTile_Click(sender, e);
            }
        }

        private void tkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                taoTile_Click(sender, e);
            }
        }

        private void mkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                taoTile_Click(sender, e);
            }
        }
        #endregion

        #region Doanh thu
        private void ngayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ngayRadioButton.Checked)
            {
                thangComboBox.Visible = true;
                thangLabel.Visible = true;
                namComboBox.Visible = true;
                namLabel.Visible = true;
                doanhThuChart.Series[0].Name = "Doanh thu ngày";
                doanhThuChart.Series[0].Points.Clear();
                int month = int.Parse(thangComboBox.Text);
                int year = int.Parse(namComboBox.Text);
                int daysInMonth = DateTime.DaysInMonth(year, month);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    doanhThuChart.Series["Doanh thu ngày"].Points.AddXY(day, BillBUS.GetTotalByDay(day, month, year));
                }
            }
        }

        private void thangRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (thangRadioButton.Checked)
            {
                thangComboBox.Visible = false;
                thangLabel.Visible = false;
                namComboBox.Visible = true;
                namLabel.Visible = true;
                doanhThuChart.Series[0].Name = "Doanh thu tháng";
                doanhThuChart.Series[0].Points.Clear();
                int year = int.Parse(namComboBox.Text);

                for (int month = 1; month <= 12; month++)
                {
                    doanhThuChart.Series["Doanh thu tháng"].Points.AddXY(month, BillBUS.GetTotalByMonth(month, year));
                }
            }
        }

        private void namRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (namRadioButton.Checked)
            {
                thangComboBox.Visible = false;
                thangLabel.Visible = false;
                namComboBox.Visible = false;
                namLabel.Visible = false;
                doanhThuChart.Series[0].Name = "Doanh thu năm";
                doanhThuChart.Series[0].Points.Clear();

                for (int year = minYear; year <= maxYear; year++)
                {
                    doanhThuChart.Series["Doanh thu năm"].Points.AddXY(year, BillBUS.GetTotalByYear(year));
                }
            }
        }

        private void thangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ngayRadioButton.Checked)
            {
                doanhThuChart.Series[0].Name = "Doanh thu ngày";
                doanhThuChart.Series[0].Points.Clear();
                int month = int.Parse(thangComboBox.Text);
                int year = int.Parse(namComboBox.Text);
                int daysInMonth = DateTime.DaysInMonth(year, month);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    doanhThuChart.Series["Doanh thu ngày"].Points.AddXY(day, BillBUS.GetTotalByDay(day, month, year));
                }
            }
        }

        private void namComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ngayRadioButton.Checked)
            {
                doanhThuChart.Series[0].Name = "Doanh thu ngày";
                doanhThuChart.Series[0].Points.Clear();
                int month = int.Parse(thangComboBox.Text);
                int year = int.Parse(namComboBox.Text);
                int daysInMonth = DateTime.DaysInMonth(year, month);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    doanhThuChart.Series["Doanh thu ngày"].Points.AddXY(day, BillBUS.GetTotalByDay(day, month, year));
                }
            }
            
            if (thangRadioButton.Checked)
            {
                doanhThuChart.Series[0].Name = "Doanh thu tháng";
                doanhThuChart.Series[0].Points.Clear();
                int year = int.Parse(namComboBox.Text);

                for (int month = 1; month <= 12; month++)
                {
                    doanhThuChart.Series["Doanh thu tháng"].Points.AddXY(month, BillBUS.GetTotalByMonth(month, year));
                }
            }
        }

        private void columnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (columnRadioButton.Checked)
            {
                doanhThuChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
        }

        private void splineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (splineRadioButton.Checked)
            {
                doanhThuChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
        }

        private void pieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (pieRadioButton.Checked)
            {
                doanhThuChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }
        #endregion
    }
}
