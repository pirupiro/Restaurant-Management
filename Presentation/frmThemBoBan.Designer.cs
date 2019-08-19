namespace Presentation
{
    partial class frmThemBoBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemBoBan));
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okTile = new MetroFramework.Controls.MetroTile();
            this.huyTile = new MetroFramework.Controls.MetroTile();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.label2.Location = new System.Drawing.Point(91, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 0);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.Location = new System.Drawing.Point(140, 125);
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.ReadOnly = true;
            this.numericUpDown.Size = new System.Drawing.Size(75, 23);
            this.numericUpDown.TabIndex = 1;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // okTile
            // 
            this.okTile.ActiveControl = null;
            this.okTile.Location = new System.Drawing.Point(76, 180);
            this.okTile.Name = "okTile";
            this.okTile.Size = new System.Drawing.Size(70, 40);
            this.okTile.Style = MetroFramework.MetroColorStyle.White;
            this.okTile.TabIndex = 2;
            this.okTile.Text = "OK";
            this.okTile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okTile.TileImage = ((System.Drawing.Image)(resources.GetObject("okTile.TileImage")));
            this.okTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okTile.UseCustomForeColor = true;
            this.okTile.UseSelectable = true;
            this.okTile.UseTileImage = true;
            this.okTile.Click += new System.EventHandler(this.okTile_Click);
            // 
            // huyTile
            // 
            this.huyTile.ActiveControl = null;
            this.huyTile.Location = new System.Drawing.Point(200, 180);
            this.huyTile.Name = "huyTile";
            this.huyTile.Size = new System.Drawing.Size(75, 40);
            this.huyTile.Style = MetroFramework.MetroColorStyle.White;
            this.huyTile.TabIndex = 3;
            this.huyTile.Text = "Hủy";
            this.huyTile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.huyTile.TileImage = ((System.Drawing.Image)(resources.GetObject("huyTile.TileImage")));
            this.huyTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.huyTile.UseCustomForeColor = true;
            this.huyTile.UseSelectable = true;
            this.huyTile.UseTileImage = true;
            this.huyTile.Click += new System.EventHandler(this.huyTile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.label1.Location = new System.Drawing.Point(117, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 0);
            this.label1.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(221, 127);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(32, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "bàn";
            // 
            // frmThemBoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.huyTile);
            this.Controls.Add(this.okTile);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmThemBoBan";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label2;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private MetroFramework.Controls.MetroTile okTile;
        private MetroFramework.Controls.MetroTile huyTile;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}