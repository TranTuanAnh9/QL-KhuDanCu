namespace GUI
{
    partial class Trangchucudan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trangchucudan));
            this.pnlcudan = new System.Windows.Forms.Panel();
            this.lbltinnhan = new System.Windows.Forms.Label();
            this.btntinnhan = new System.Windows.Forms.Button();
            this.lblThongBaoSoLuong = new System.Windows.Forms.Label();
            this.btnthongbao = new System.Windows.Forms.Button();
            this.grbthongtingiaytamvang = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnback = new System.Windows.Forms.Button();
            this.grbhnhakhau = new System.Windows.Forms.GroupBox();
            this.dgvnhankhau = new System.Windows.Forms.DataGridView();
            this.grbhokhau = new System.Windows.Forms.GroupBox();
            this.dgvhokhau = new System.Windows.Forms.DataGridView();
            this.btnbaiviet = new System.Windows.Forms.Button();
            this.lbltrangchucudan = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.pnlcudan.SuspendLayout();
            this.grbthongtingiaytamvang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grbhnhakhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnhankhau)).BeginInit();
            this.grbhokhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhokhau)).BeginInit();
            this.grbtimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlcudan
            // 
            this.pnlcudan.Controls.Add(this.lbltinnhan);
            this.pnlcudan.Controls.Add(this.btntinnhan);
            this.pnlcudan.Controls.Add(this.lblThongBaoSoLuong);
            this.pnlcudan.Controls.Add(this.btnthongbao);
            this.pnlcudan.Controls.Add(this.grbthongtingiaytamvang);
            this.pnlcudan.Controls.Add(this.btnback);
            this.pnlcudan.Controls.Add(this.grbhnhakhau);
            this.pnlcudan.Controls.Add(this.grbhokhau);
            this.pnlcudan.Controls.Add(this.btnbaiviet);
            this.pnlcudan.Controls.Add(this.lbltrangchucudan);
            this.pnlcudan.Controls.Add(this.btntimkiem);
            this.pnlcudan.Controls.Add(this.grbtimkiem);
            this.pnlcudan.Location = new System.Drawing.Point(3, 2);
            this.pnlcudan.Name = "pnlcudan";
            this.pnlcudan.Size = new System.Drawing.Size(1209, 571);
            this.pnlcudan.TabIndex = 7;
            // 
            // lbltinnhan
            // 
            this.lbltinnhan.AutoSize = true;
            this.lbltinnhan.Location = new System.Drawing.Point(1009, 12);
            this.lbltinnhan.Name = "lbltinnhan";
            this.lbltinnhan.Size = new System.Drawing.Size(44, 16);
            this.lbltinnhan.TabIndex = 28;
            this.lbltinnhan.Text = "label1";
            // 
            // btntinnhan
            // 
            this.btntinnhan.Location = new System.Drawing.Point(909, 17);
            this.btntinnhan.Name = "btntinnhan";
            this.btntinnhan.Size = new System.Drawing.Size(110, 52);
            this.btntinnhan.TabIndex = 27;
            this.btntinnhan.Text = "Tin Nhắn";
            this.btntinnhan.UseVisualStyleBackColor = true;
            this.btntinnhan.Click += new System.EventHandler(this.btntinnhan_Click);
            // 
            // lblThongBaoSoLuong
            // 
            this.lblThongBaoSoLuong.AutoSize = true;
            this.lblThongBaoSoLuong.Location = new System.Drawing.Point(1165, 7);
            this.lblThongBaoSoLuong.Name = "lblThongBaoSoLuong";
            this.lblThongBaoSoLuong.Size = new System.Drawing.Size(44, 16);
            this.lblThongBaoSoLuong.TabIndex = 26;
            this.lblThongBaoSoLuong.Text = "label1";
            // 
            // btnthongbao
            // 
            this.btnthongbao.Location = new System.Drawing.Point(1070, 17);
            this.btnthongbao.Name = "btnthongbao";
            this.btnthongbao.Size = new System.Drawing.Size(110, 54);
            this.btnthongbao.TabIndex = 25;
            this.btnthongbao.Text = "Thông báo";
            this.btnthongbao.UseVisualStyleBackColor = true;
            this.btnthongbao.Click += new System.EventHandler(this.btnthongbao_Click);
            // 
            // grbthongtingiaytamvang
            // 
            this.grbthongtingiaytamvang.Controls.Add(this.dataGridView1);
            this.grbthongtingiaytamvang.Location = new System.Drawing.Point(806, 79);
            this.grbthongtingiaytamvang.Name = "grbthongtingiaytamvang";
            this.grbthongtingiaytamvang.Size = new System.Drawing.Size(396, 492);
            this.grbthongtingiaytamvang.TabIndex = 10;
            this.grbthongtingiaytamvang.TabStop = false;
            this.grbthongtingiaytamvang.Text = "Thông Tin Giấy Tạm Vắng";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(382, 459);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(231, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(105, 49);
            this.btnback.TabIndex = 24;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // grbhnhakhau
            // 
            this.grbhnhakhau.Controls.Add(this.dgvnhankhau);
            this.grbhnhakhau.Location = new System.Drawing.Point(9, 70);
            this.grbhnhakhau.Name = "grbhnhakhau";
            this.grbhnhakhau.Size = new System.Drawing.Size(390, 492);
            this.grbhnhakhau.TabIndex = 8;
            this.grbhnhakhau.TabStop = false;
            this.grbhnhakhau.Text = "Thông Tin Nhân Khẩu";
            // 
            // dgvnhankhau
            // 
            this.dgvnhankhau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvnhankhau.Location = new System.Drawing.Point(7, 22);
            this.dgvnhankhau.Name = "dgvnhankhau";
            this.dgvnhankhau.RowHeadersWidth = 51;
            this.dgvnhankhau.RowTemplate.Height = 24;
            this.dgvnhankhau.Size = new System.Drawing.Size(373, 459);
            this.dgvnhankhau.TabIndex = 0;
            // 
            // grbhokhau
            // 
            this.grbhokhau.Controls.Add(this.dgvhokhau);
            this.grbhokhau.Location = new System.Drawing.Point(405, 73);
            this.grbhokhau.Name = "grbhokhau";
            this.grbhokhau.Size = new System.Drawing.Size(395, 492);
            this.grbhokhau.TabIndex = 9;
            this.grbhokhau.TabStop = false;
            this.grbhokhau.Text = "Thông Tin Hộ Khẩu";
            // 
            // dgvhokhau
            // 
            this.dgvhokhau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhokhau.Location = new System.Drawing.Point(6, 22);
            this.dgvhokhau.Name = "dgvhokhau";
            this.dgvhokhau.RowHeadersWidth = 51;
            this.dgvhokhau.RowTemplate.Height = 24;
            this.dgvhokhau.Size = new System.Drawing.Size(380, 459);
            this.dgvhokhau.TabIndex = 1;
            // 
            // btnbaiviet
            // 
            this.btnbaiviet.Location = new System.Drawing.Point(352, 12);
            this.btnbaiviet.Name = "btnbaiviet";
            this.btnbaiviet.Size = new System.Drawing.Size(105, 49);
            this.btnbaiviet.TabIndex = 23;
            this.btnbaiviet.Text = "Bài Viết";
            this.btnbaiviet.UseVisualStyleBackColor = true;
            this.btnbaiviet.Click += new System.EventHandler(this.btnbaiviet_Click);
            // 
            // lbltrangchucudan
            // 
            this.lbltrangchucudan.AutoSize = true;
            this.lbltrangchucudan.Location = new System.Drawing.Point(50, 12);
            this.lbltrangchucudan.Name = "lbltrangchucudan";
            this.lbltrangchucudan.Size = new System.Drawing.Size(116, 16);
            this.lbltrangchucudan.TabIndex = 4;
            this.lbltrangchucudan.Text = "Trang Chủ Cư Dân";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(474, 12);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(105, 49);
            this.btntimkiem.TabIndex = 1;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Controls.Add(this.txttimkiem);
            this.grbtimkiem.Location = new System.Drawing.Point(585, 10);
            this.grbtimkiem.Name = "grbtimkiem";
            this.grbtimkiem.Size = new System.Drawing.Size(247, 56);
            this.grbtimkiem.TabIndex = 0;
            this.grbtimkiem.TabStop = false;
            this.grbtimkiem.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(7, 28);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(232, 22);
            this.txttimkiem.TabIndex = 0;
            // 
            // Trangchucudan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 579);
            this.Controls.Add(this.pnlcudan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Trangchucudan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ Cư Dân";
            this.Load += new System.EventHandler(this.Trangchucudan_Load);
            this.pnlcudan.ResumeLayout(false);
            this.pnlcudan.PerformLayout();
            this.grbthongtingiaytamvang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grbhnhakhau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvnhankhau)).EndInit();
            this.grbhokhau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhokhau)).EndInit();
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlcudan;
        private System.Windows.Forms.Label lbltrangchucudan;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btnbaiviet;
        private System.Windows.Forms.GroupBox grbhnhakhau;
        private System.Windows.Forms.DataGridView dgvnhankhau;
        private System.Windows.Forms.GroupBox grbhokhau;
        private System.Windows.Forms.DataGridView dgvhokhau;
        private System.Windows.Forms.GroupBox grbthongtingiaytamvang;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnthongbao;
        private System.Windows.Forms.Label lblThongBaoSoLuong;
        private System.Windows.Forms.Label lbltinnhan;
        private System.Windows.Forms.Button btntinnhan;
    }
}