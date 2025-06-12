namespace GUI
{
    partial class LoiNhan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.grbloinhan = new System.Windows.Forms.GroupBox();
            this.txttieude = new System.Windows.Forms.TextBox();
            this.lbltieude = new System.Windows.Forms.Label();
            this.lblloinhan = new System.Windows.Forms.Label();
            this.txtloinhan = new System.Windows.Forms.TextBox();
            this.btngui = new System.Windows.Forms.Button();
            this.lblloai = new System.Windows.Forms.Label();
            this.cbbdoituong = new System.Windows.Forms.ComboBox();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.lsb = new System.Windows.Forms.ListBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.grbdanhsachnk = new System.Windows.Forms.GroupBox();
            this.dgvdanhsach = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grbloinhan.SuspendLayout();
            this.grbdanhsachnk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhsach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnlammoi);
            this.panel1.Controls.Add(this.grbloinhan);
            this.panel1.Controls.Add(this.btngui);
            this.panel1.Controls.Add(this.lblloai);
            this.panel1.Controls.Add(this.cbbdoituong);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.btntimkiem);
            this.panel1.Controls.Add(this.lsb);
            this.panel1.Controls.Add(this.txttimkiem);
            this.panel1.Controls.Add(this.grbdanhsachnk);
            this.panel1.Location = new System.Drawing.Point(1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 622);
            this.panel1.TabIndex = 0;
            // 
            // btnlammoi
            // 
            this.btnlammoi.Location = new System.Drawing.Point(903, 270);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(89, 52);
            this.btnlammoi.TabIndex = 13;
            this.btnlammoi.Text = "Làm Mới";
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // grbloinhan
            // 
            this.grbloinhan.Controls.Add(this.txttieude);
            this.grbloinhan.Controls.Add(this.lbltieude);
            this.grbloinhan.Controls.Add(this.lblloinhan);
            this.grbloinhan.Controls.Add(this.txtloinhan);
            this.grbloinhan.Location = new System.Drawing.Point(4, 378);
            this.grbloinhan.Name = "grbloinhan";
            this.grbloinhan.Size = new System.Drawing.Size(571, 241);
            this.grbloinhan.TabIndex = 12;
            this.grbloinhan.TabStop = false;
            this.grbloinhan.Text = "Nội Dung";
            // 
            // txttieude
            // 
            this.txttieude.Location = new System.Drawing.Point(84, 32);
            this.txttieude.Name = "txttieude";
            this.txttieude.Size = new System.Drawing.Size(446, 22);
            this.txttieude.TabIndex = 7;
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.Location = new System.Drawing.Point(8, 32);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(54, 16);
            this.lbltieude.TabIndex = 0;
            this.lbltieude.Text = "Tiêu Đề";
            // 
            // lblloinhan
            // 
            this.lblloinhan.AutoSize = true;
            this.lblloinhan.Location = new System.Drawing.Point(8, 88);
            this.lblloinhan.Name = "lblloinhan";
            this.lblloinhan.Size = new System.Drawing.Size(60, 16);
            this.lblloinhan.TabIndex = 6;
            this.lblloinhan.Text = "Lời Nhắn";
            // 
            // txtloinhan
            // 
            this.txtloinhan.Location = new System.Drawing.Point(74, 85);
            this.txtloinhan.Multiline = true;
            this.txtloinhan.Name = "txtloinhan";
            this.txtloinhan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtloinhan.Size = new System.Drawing.Size(456, 22);
            this.txtloinhan.TabIndex = 7;
            // 
            // btngui
            // 
            this.btngui.Location = new System.Drawing.Point(594, 503);
            this.btngui.Name = "btngui";
            this.btngui.Size = new System.Drawing.Size(109, 48);
            this.btngui.TabIndex = 11;
            this.btngui.Text = "Gửi";
            this.btngui.UseVisualStyleBackColor = true;
            this.btngui.Click += new System.EventHandler(this.btngui_Click);
            // 
            // lblloai
            // 
            this.lblloai.AutoSize = true;
            this.lblloai.Location = new System.Drawing.Point(20, 20);
            this.lblloai.Name = "lblloai";
            this.lblloai.Size = new System.Drawing.Size(106, 16);
            this.lblloai.TabIndex = 10;
            this.lblloai.Text = "Chọn Đối Tượng ";
            // 
            // cbbdoituong
            // 
            this.cbbdoituong.FormattingEnabled = true;
            this.cbbdoituong.Location = new System.Drawing.Point(148, 18);
            this.cbbdoituong.Name = "cbbdoituong";
            this.cbbdoituong.Size = new System.Drawing.Size(421, 24);
            this.cbbdoituong.TabIndex = 9;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(903, 104);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(89, 47);
            this.btnthem.TabIndex = 8;
            this.btnthem.Text = "Thêm ";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(903, 189);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(89, 49);
            this.btnxoa.TabIndex = 5;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(903, 9);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(89, 47);
            this.btntimkiem.TabIndex = 4;
            this.btntimkiem.Text = "Tìm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // lsb
            // 
            this.lsb.FormattingEnabled = true;
            this.lsb.ItemHeight = 16;
            this.lsb.Location = new System.Drawing.Point(594, 69);
            this.lsb.Name = "lsb";
            this.lsb.Size = new System.Drawing.Size(291, 292);
            this.lsb.TabIndex = 3;
            this.lsb.Tag = "";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(594, 20);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(291, 22);
            this.txttimkiem.TabIndex = 2;
            // 
            // grbdanhsachnk
            // 
            this.grbdanhsachnk.Controls.Add(this.dgvdanhsach);
            this.grbdanhsachnk.Location = new System.Drawing.Point(3, 58);
            this.grbdanhsachnk.Name = "grbdanhsachnk";
            this.grbdanhsachnk.Size = new System.Drawing.Size(566, 314);
            this.grbdanhsachnk.TabIndex = 0;
            this.grbdanhsachnk.TabStop = false;
            this.grbdanhsachnk.Text = "Danh Sách";
            // 
            // dgvdanhsach
            // 
            this.dgvdanhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdanhsach.Location = new System.Drawing.Point(8, 22);
            this.dgvdanhsach.Name = "dgvdanhsach";
            this.dgvdanhsach.RowHeadersWidth = 51;
            this.dgvdanhsach.RowTemplate.Height = 24;
            this.dgvdanhsach.Size = new System.Drawing.Size(549, 281);
            this.dgvdanhsach.TabIndex = 0;
            // 
            // LoiNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 624);
            this.Controls.Add(this.panel1);
            this.Name = "LoiNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoiNhan";
            this.Load += new System.EventHandler(this.LoiNhan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbloinhan.ResumeLayout(false);
            this.grbloinhan.PerformLayout();
            this.grbdanhsachnk.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanhsach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtloinhan;
        private System.Windows.Forms.Label lblloinhan;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.ListBox lsb;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.GroupBox grbdanhsachnk;
        private System.Windows.Forms.DataGridView dgvdanhsach;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label lblloai;
        private System.Windows.Forms.ComboBox cbbdoituong;
        private System.Windows.Forms.Button btngui;
        private System.Windows.Forms.GroupBox grbloinhan;
        private System.Windows.Forms.TextBox txttieude;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.Button btnlammoi;
    }
}