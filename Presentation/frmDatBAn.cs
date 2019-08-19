using BUS;
using DTO;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmDatBan : MetroForm
    {
        DangNhap login;
        List<DataTable> selected;
        List<MetroTile> metroTileList;
        List<Ban> tableList;
        HoaDon currentBill;
        int selectedIndex;

        public frmDatBan(DangNhap input)
        {
            InitializeComponent();
            login = input;
            tableList = TableBUS.LoadAll();
            selected = new List<DataTable>(tableList.Count);
            dgv.DataSource = BillDetailBUS.LoadAll(0);
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Tên món";
            dgv.Columns[2].HeaderText = "Số lượng";
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[3].HeaderText = "Thành tiền";
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void frmDatBan_Load(object sender, EventArgs e)
        {
            metroTileList = new List<MetroTile>(tableList.Count);

            for (int i = 0; i < tableList.Count; i++)
            {
                selected.Add(null);

                // Thiết lập thuộc tính cho tile
                MetroTile tile = new MetroTile();
                tile.Size = new Size(120, 75);
                tile.UseTileImage = true;
                tile.TileImage = Properties.Resources.round;
                tile.TileImageAlign = ContentAlignment.MiddleCenter;
                tile.Text = (i + 1).ToString();
                tile.UseCustomForeColor = true;
                tile.ForeColor = Color.Black;
                tile.TextAlign = ContentAlignment.MiddleCenter;
                tile.TileTextFontSize = MetroTileTextSize.Tall;
                tile.TileTextFontWeight = MetroTileTextWeight.Bold;
                tile.Margin = new Padding(10);
                tile.Click += Tile_Click;

                if (tableList[i].TinhTrang == "Còn trống")
                {
                    tile.Style = MetroColorStyle.Green;
                }
                else
                {
                    tile.Style = MetroColorStyle.Red;
                }

                flowLayoutPanel.Controls.Add(tile);
                metroTileList.Add(tile);
            }
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
            DialogResult dialog = MetroMessageBox.Show(this, "Bạn muốn đăng xuất khỏi chương trình ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        private void Tile_Click(object sender, EventArgs e)
        {
            int index = metroTileList.IndexOf((MetroTile)sender);

            if (tableList[index].TinhTrang == "Còn trống")
            {
                using (frmChonMon form = new frmChonMon(index + 1))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selected[index] = form.Selected;
                        metroTileList[index].Style = MetroColorStyle.Red;
                        tableList[index].TinhTrang = "Đã được đặt";
                        TableBUS.UpdateStatus(tableList[index]);
                        int tongTien = 0;

                        currentBill = new HoaDon
                        {
                            MaBan = tableList[index].MaBan,
                            MaNhanVien = login.MaNhanVien,
                        };

                        BillBUS.Insert(currentBill);
                        currentBill = BillBUS.GetLastBill(tableList[index].MaBan);

                        foreach (DataRow row in selected[index].Rows)
                        {
                            string tenMon = row["Tên món"].ToString();
                            int donGia = (int)row["Đơn giá"];
                            int soLuong = (int)row["Số lượng"];
                            int thanhTien = donGia * soLuong;
                            tongTien += thanhTien;

                            ChiTietHoaDon detail = new ChiTietHoaDon(currentBill.MaHoaDon, tenMon, soLuong, thanhTien);
                            ChiTietHoaDon existedDetail = BillDetailBUS.GetBillDetail(detail);

                            if (existedDetail != null)
                            {
                                detail.SoLuong += existedDetail.SoLuong;
                                detail.ThanhTien += existedDetail.ThanhTien;
                                BillDetailBUS.Update(detail);
                            }
                            else
                            {
                                BillDetailBUS.Insert(detail);
                            }
                        }

                        currentBill.TongTien = tongTien + tongTien / 10;
                        BillBUS.UpdateTotalPrice(currentBill);
                    }
                }
            }
            else
            {
                currentBill = BillBUS.GetLastBill(tableList[index].MaBan);
                dgv.DataSource = BillDetailBUS.LoadAll(currentBill.MaHoaDon);
                selectedIndex = index;
                thanhToanTile.Visible = true;
                themMonTile.Visible = true;
                tongTienLabel.Visible = true;
                tongTienLabel.Text = currentBill.TongTien.ToString("N0");
                label.Visible = true;
            }
        }

        private void themMonTile_Click(object sender, EventArgs e)
        {
            using (frmChonMon form = new frmChonMon(selectedIndex + 1))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selected[selectedIndex] = form.Selected;
                    int tongTien = 0;

                    foreach (DataRow row in selected[selectedIndex].Rows)
                    {
                        string tenMon = row["Tên món"].ToString();
                        int donGia = (int)row["Đơn giá"];
                        int soLuong = (int)row["Số lượng"];
                        int thanhTien = donGia * soLuong;
                        tongTien += thanhTien;

                        ChiTietHoaDon detail = new ChiTietHoaDon(currentBill.MaHoaDon, tenMon, soLuong, thanhTien);
                        ChiTietHoaDon existedDetail = BillDetailBUS.GetBillDetail(detail);

                        if (existedDetail != null)
                        {
                            detail.SoLuong += existedDetail.SoLuong;
                            detail.ThanhTien += existedDetail.ThanhTien;
                            BillDetailBUS.Update(detail);
                        }
                        else
                        {
                            BillDetailBUS.Insert(detail);
                        }
                    }

                    currentBill.TongTien += tongTien + tongTien / 10;
                    BillBUS.UpdateTotalPrice(currentBill);
                    metroTileList[selectedIndex].PerformClick();
                }
            }
        }

        private void thanhToanTile_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MetroMessageBox.Show(this, "Bạn muốn thanh toán hóa đơn cho bàn " + (selectedIndex + 1) + " ?", "Pay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                metroTileList[selectedIndex].Style = MetroColorStyle.Green;
                tableList[selectedIndex].TinhTrang = "Còn trống";
                TableBUS.UpdateStatus(tableList[selectedIndex]);
                thanhToanTile.Visible = false;
                themMonTile.Visible = false;
                tongTienLabel.Visible = false;
                label.Visible = false;
                dgv.DataSource = BillDetailBUS.LoadAll(0);
                BillBUS.UpdateInvoicingTime(currentBill);
                Refresh();
                DialogResult dialog2 = MetroMessageBox.Show(this, "Thanh toán thành công, bạn có muốn in hóa đơn ?", "Print receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog2 == DialogResult.Yes)
                {
                    frmThanhToan form = new frmThanhToan(currentBill.MaHoaDon, selectedIndex + 1, login.MaNhanVien);
                    form.Show();
                }
            }
        }
    }
}
