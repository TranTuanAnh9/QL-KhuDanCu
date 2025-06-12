namespace GUI
{
    partial class TrangChuHoKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChuHoKhau));
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnqlhokhau = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltrangchuhokhau = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(150, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(835, 684);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(835, 684);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnqlhokhau);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Location = new System.Drawing.Point(-2, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 766);
            this.panel2.TabIndex = 4;
            // 
            // btnqlhokhau
            // 
            this.btnqlhokhau.Location = new System.Drawing.Point(-8, 184);
            this.btnqlhokhau.Name = "btnqlhokhau";
            this.btnqlhokhau.Size = new System.Drawing.Size(180, 59);
            this.btnqlhokhau.TabIndex = 1;
            this.btnqlhokhau.Text = "Quản Lý Hộ Khẩu";
            this.btnqlhokhau.UseVisualStyleBackColor = true;
            this.btnqlhokhau.Click += new System.EventHandler(this.btnqlhokhau_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(-8, 268);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(180, 59);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbltrangchuhokhau);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 79);
            this.panel1.TabIndex = 3;
            // 
            // lbltrangchuhokhau
            // 
            this.lbltrangchuhokhau.AutoSize = true;
            this.lbltrangchuhokhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltrangchuhokhau.Location = new System.Drawing.Point(449, 19);
            this.lbltrangchuhokhau.Name = "lbltrangchuhokhau";
            this.lbltrangchuhokhau.Size = new System.Drawing.Size(157, 20);
            this.lbltrangchuhokhau.TabIndex = 0;
            this.lbltrangchuhokhau.Text = "Trang Chủ Hộ Khẩu";
            // 
            // TrangChuHoKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrangChuHoKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrangChuHoKhau";
            this.Load += new System.EventHandler(this.TrangChuHoKhau_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnqlhokhau;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltrangchuhokhau;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}