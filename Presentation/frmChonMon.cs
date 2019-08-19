using BUS;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmChonMon : MetroForm
    {
        public DataTable Selected { get; set; }
        int maBan;
        List<MetroTile> increList = new List<MetroTile>();
        List<MetroTile> decreList = new List<MetroTile>();
        List<MetroTile> delList = new List<MetroTile>();
        Point point1 = new Point(580, 28);
        Point point2 = new Point(640, 28);
        Point point3 = new Point(700 , 28);

        public frmChonMon(int id)
        {
            InitializeComponent();
            maBan = id;
            Text = "Chọn món cho bàn " + maBan;
        }

        private void frmChonMon_Load(object sender, System.EventArgs e)
        {
            dgv1.DataSource = MenuBUS.LoadAll();
            dgv1.Columns[0].HeaderText = "Tên món";
            dgv1.Columns[1].HeaderText = "Đơn giá";
            dgv1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns[2].Visible = false;

            Selected = new DataTable();
            Selected.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Tên món", typeof(string)),
                new DataColumn("Đơn giá", typeof(int)),
                new DataColumn("Số lượng", typeof(int))
            });

            dgv2.DataSource = Selected;
            dgv2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void DrawControls()
        {
            // Thiết lập thuộc tính cho Increment Tile
            MetroTile increTile = new MetroTile();
            increTile.Size = new Size(28, 28);
            increTile.Location = point1;
            increTile.UseTileImage = true;
            increTile.TileImage = Properties.Resources.increase;
            increTile.TileImageAlign = ContentAlignment.MiddleCenter;
            increTile.Style = MetroColorStyle.White;
            increTile.Click += IncreTile_Click;

            // Thiết lập thuộc tính cho Decrement Tile
            MetroTile decreTile = new MetroTile();
            decreTile.Size = new Size(28, 28);
            decreTile.Location = point2;
            decreTile.UseTileImage = true;
            decreTile.TileImage = Properties.Resources.decrease;
            decreTile.TileImageAlign = ContentAlignment.MiddleCenter;
            decreTile.Style = MetroColorStyle.White;
            decreTile.Click += DecreTile_Click;

            // Thiết lập thuộc tính cho Delete Tile
            MetroTile delTile = new MetroTile();
            delTile.Size = new Size(28, 28);
            delTile.Location = point3;
            delTile.UseTileImage = true;
            delTile.TileImage = Properties.Resources.delete;
            delTile.TileImageAlign = ContentAlignment.MiddleCenter;
            delTile.Style = MetroColorStyle.White;
            delTile.Click += DelTile_Click;

            // Thêm tiles vào panel và list
            panel.Controls.Add(increTile);
            panel.Controls.Add(decreTile);
            panel.Controls.Add(delTile);
            increList.Add(increTile);
            decreList.Add(decreTile);
            delList.Add(delTile);

            // Tăng tọa độ trục tung
            point1.Y += 28;
            point2.Y += 28;
            point3.Y += 28;
        }

        private void timkiemTextBox_TextChanged(object sender, System.EventArgs e)
        {
            dgv1.DataSource = MenuBUS.LoadAll(timkiemTextBox.Text);
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenMon = (string)dgv1.CurrentRow.Cells[0].Value;
                int donGia = (int)dgv1.CurrentRow.Cells[1].Value;
                Selected.Rows.Add(tenMon, donGia, 1);
                DrawControls();
            }
        }

        private void IncreTile_Click(object sender, System.EventArgs e)
        {
            int index = increList.IndexOf((MetroTile)sender);
            Selected.Rows[index]["Số lượng"] = (int)Selected.Rows[index]["Số lượng"] + 1;
        }

        private void DecreTile_Click(object sender, System.EventArgs e)
        {
            int index = decreList.IndexOf((MetroTile)sender);

            if ((int)Selected.Rows[index]["Số lượng"] > 1)
            {
                Selected.Rows[index]["Số lượng"] = (int)Selected.Rows[index]["Số lượng"] - 1;
            }
        }

        private void DelTile_Click(object sender, System.EventArgs e)
        {
            int index = delList.IndexOf((MetroTile)sender);

            while (index < ((panel.Controls.Count - 1) / 3))
            {
                panel.Controls.RemoveAt(panel.Controls.Count - 1);
                panel.Controls.RemoveAt(panel.Controls.Count - 1);
                panel.Controls.RemoveAt(panel.Controls.Count - 1);
            }

            increList.RemoveRange(index, increList.Count - index);
            decreList.RemoveRange(index, decreList.Count - index);
            delList.RemoveRange(index, delList.Count - index);
            Selected.Rows.RemoveAt(index);
            point1.Y = 28 * (index + 1);
            point2.Y = 28 * (index + 1);
            point3.Y = 28 * (index + 1);
            
            for (int i = index; i < Selected.Rows.Count; i++)
            {
                DrawControls();
            }
        }

        private void xacnhacTile_Click(object sender, System.EventArgs e)
        {
            if (Selected.Rows.Count == 0)
            {
                MetroMessageBox.Show(this, "Bạn vẫn chưa chọn món ăn.", "Empty list", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult = DialogResult.OK;
                MetroMessageBox.Show(this, "Chọn món ăn thành công.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void huyTile_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
