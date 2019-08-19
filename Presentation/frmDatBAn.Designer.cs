namespace Presentation
{
    partial class frmDatBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatBan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new MetroFramework.Controls.MetroGrid();
            this.label = new MetroFramework.Controls.MetroLabel();
            this.tongTienLabel = new MetroFramework.Controls.MetroLabel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.themMonTile = new MetroFramework.Controls.MetroTile();
            this.thanhToanTile = new MetroFramework.Controls.MetroTile();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 29);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(131, 25);
            this.changePasswordToolStripMenuItem.Text = "Đổi mật khẩu";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.Location = new System.Drawing.Point(615, 92);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(119)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(133)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(562, 400);
            this.dgv.Style = MetroFramework.MetroColorStyle.Orange;
            this.dgv.TabIndex = 17;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.label.Location = new System.Drawing.Point(139, 532);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(215, 25);
            this.label.TabIndex = 21;
            this.label.Text = "Tổng tiền (bao gồm VAT):";
            this.label.Visible = false;
            // 
            // tongTienLabel
            // 
            this.tongTienLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tongTienLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.tongTienLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.tongTienLabel.Location = new System.Drawing.Point(351, 532);
            this.tongTienLabel.Name = "tongTienLabel";
            this.tongTienLabel.Size = new System.Drawing.Size(179, 25);
            this.tongTienLabel.TabIndex = 22;
            this.tongTienLabel.Text = "Chỗ này để tổng tiền";
            this.tongTienLabel.Visible = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(24, 92);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(585, 400);
            this.flowLayoutPanel.TabIndex = 24;
            // 
            // themMonTile
            // 
            this.themMonTile.ActiveControl = null;
            this.themMonTile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.themMonTile.Location = new System.Drawing.Point(744, 516);
            this.themMonTile.Name = "themMonTile";
            this.themMonTile.Size = new System.Drawing.Size(135, 55);
            this.themMonTile.Style = MetroFramework.MetroColorStyle.White;
            this.themMonTile.TabIndex = 23;
            this.themMonTile.Text = "Thêm món";
            this.themMonTile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.themMonTile.TileImage = ((System.Drawing.Image)(resources.GetObject("themMonTile.TileImage")));
            this.themMonTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.themMonTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.themMonTile.UseCustomForeColor = true;
            this.themMonTile.UseSelectable = true;
            this.themMonTile.UseTileImage = true;
            this.themMonTile.Visible = false;
            this.themMonTile.Click += new System.EventHandler(this.themMonTile_Click);
            // 
            // thanhToanTile
            // 
            this.thanhToanTile.ActiveControl = null;
            this.thanhToanTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.thanhToanTile.Location = new System.Drawing.Point(966, 516);
            this.thanhToanTile.Name = "thanhToanTile";
            this.thanhToanTile.Size = new System.Drawing.Size(140, 55);
            this.thanhToanTile.Style = MetroFramework.MetroColorStyle.White;
            this.thanhToanTile.TabIndex = 20;
            this.thanhToanTile.Text = "Thanh toán";
            this.thanhToanTile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thanhToanTile.TileImage = ((System.Drawing.Image)(resources.GetObject("thanhToanTile.TileImage")));
            this.thanhToanTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thanhToanTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.thanhToanTile.UseCustomForeColor = true;
            this.thanhToanTile.UseSelectable = true;
            this.thanhToanTile.UseTileImage = true;
            this.thanhToanTile.Visible = false;
            this.thanhToanTile.Click += new System.EventHandler(this.thanhToanTile_Click);
            // 
            // frmDatBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.themMonTile);
            this.Controls.Add(this.tongTienLabel);
            this.Controls.Add(this.label);
            this.Controls.Add(this.thanhToanTile);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDatBan";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "ĐẶT BÀN";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.frmDatBan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private MetroFramework.Controls.MetroGrid dgv;
        private MetroFramework.Controls.MetroTile thanhToanTile;
        private MetroFramework.Controls.MetroLabel label;
        private MetroFramework.Controls.MetroLabel tongTienLabel;
        private MetroFramework.Controls.MetroTile themMonTile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}