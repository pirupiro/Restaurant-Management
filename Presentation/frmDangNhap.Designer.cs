namespace Presentation
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.mkTextBox = new MetroFramework.Controls.MetroTextBox();
            this.tkTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.dnTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // mkTextBox
            // 
            // 
            // 
            // 
            this.mkTextBox.CustomButton.Image = null;
            this.mkTextBox.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.mkTextBox.CustomButton.Name = "";
            this.mkTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mkTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mkTextBox.CustomButton.TabIndex = 1;
            this.mkTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mkTextBox.CustomButton.UseSelectable = true;
            this.mkTextBox.CustomButton.Visible = false;
            this.mkTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mkTextBox.Lines = new string[0];
            this.mkTextBox.Location = new System.Drawing.Point(156, 128);
            this.mkTextBox.MaxLength = 10;
            this.mkTextBox.Name = "mkTextBox";
            this.mkTextBox.PasswordChar = '●';
            this.mkTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mkTextBox.SelectedText = "";
            this.mkTextBox.SelectionLength = 0;
            this.mkTextBox.SelectionStart = 0;
            this.mkTextBox.ShortcutsEnabled = true;
            this.mkTextBox.Size = new System.Drawing.Size(150, 25);
            this.mkTextBox.TabIndex = 1;
            this.mkTextBox.UseSelectable = true;
            this.mkTextBox.UseSystemPasswordChar = true;
            this.mkTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mkTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mkTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mkTextBox_KeyPress);
            // 
            // tkTextBox
            // 
            // 
            // 
            // 
            this.tkTextBox.CustomButton.Image = null;
            this.tkTextBox.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.tkTextBox.CustomButton.Name = "";
            this.tkTextBox.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tkTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tkTextBox.CustomButton.TabIndex = 1;
            this.tkTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tkTextBox.CustomButton.UseSelectable = true;
            this.tkTextBox.CustomButton.Visible = false;
            this.tkTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tkTextBox.Lines = new string[0];
            this.tkTextBox.Location = new System.Drawing.Point(156, 80);
            this.tkTextBox.MaxLength = 10;
            this.tkTextBox.Name = "tkTextBox";
            this.tkTextBox.PasswordChar = '\0';
            this.tkTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tkTextBox.SelectedText = "";
            this.tkTextBox.SelectionLength = 0;
            this.tkTextBox.SelectionStart = 0;
            this.tkTextBox.ShortcutsEnabled = true;
            this.tkTextBox.Size = new System.Drawing.Size(150, 25);
            this.tkTextBox.TabIndex = 0;
            this.tkTextBox.UseSelectable = true;
            this.tkTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tkTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tkTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tkTextBox_KeyPress);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(84, 131);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Mật khẩu:";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(84, 83);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Tài khoản:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dnTile
            // 
            this.dnTile.ActiveControl = null;
            this.dnTile.Location = new System.Drawing.Point(156, 180);
            this.dnTile.Name = "dnTile";
            this.dnTile.Size = new System.Drawing.Size(120, 40);
            this.dnTile.Style = MetroFramework.MetroColorStyle.White;
            this.dnTile.TabIndex = 5;
            this.dnTile.Text = "Đăng nhập";
            this.dnTile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dnTile.TileImage = ((System.Drawing.Image)(resources.GetObject("dnTile.TileImage")));
            this.dnTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dnTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.dnTile.UseCustomForeColor = true;
            this.dnTile.UseSelectable = true;
            this.dnTile.UseStyleColors = true;
            this.dnTile.UseTileImage = true;
            this.dnTile.Click += new System.EventHandler(this.dnTile_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.dnTile);
            this.Controls.Add(this.mkTextBox);
            this.Controls.Add(this.tkTextBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "ĐĂNG NHẬP";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox mkTextBox;
        private MetroFramework.Controls.MetroTextBox tkTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile dnTile;
    }
}

