namespace GUI
{
    partial class KhaoSat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhaoSat));
            this.grbdanhsachbaikhaosat = new System.Windows.Forms.GroupBox();
            this.dgvkhaosat = new System.Windows.Forms.DataGridView();
            this.lblmakhaosat = new System.Windows.Forms.Label();
            this.lbltieude = new System.Windows.Forms.Label();
            this.lblngaytao = new System.Windows.Forms.Label();
            this.lbltrangthai = new System.Windows.Forms.Label();
            this.txtmakhaosat = new System.Windows.Forms.TextBox();
            this.txttieude = new System.Windows.Forms.TextBox();
            this.txttrangthai = new System.Windows.Forms.TextBox();
            this.dtpngaytao = new System.Windows.Forms.DateTimePicker();
            this.btnthemkhaosat = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.btntaocauhoi = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btndangbai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnxemketqua = new System.Windows.Forms.Button();
            this.btnxemtruoc = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbdanhsachbaikhaosat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhaosat)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbdanhsachbaikhaosat
            // 
            this.grbdanhsachbaikhaosat.Controls.Add(this.dgvkhaosat);
            this.grbdanhsachbaikhaosat.Location = new System.Drawing.Point(3, 3);
            this.grbdanhsachbaikhaosat.Name = "grbdanhsachbaikhaosat";
            this.grbdanhsachbaikhaosat.Size = new System.Drawing.Size(680, 528);
            this.grbdanhsachbaikhaosat.TabIndex = 0;
            this.grbdanhsachbaikhaosat.TabStop = false;
            this.grbdanhsachbaikhaosat.Text = "Danh Sách Các Bài Khảo Sát";
            // 
            // dgvkhaosat
            // 
            this.dgvkhaosat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhaosat.Location = new System.Drawing.Point(7, 22);
            this.dgvkhaosat.Name = "dgvkhaosat";
            this.dgvkhaosat.RowHeadersWidth = 51;
            this.dgvkhaosat.RowTemplate.Height = 24;
            this.dgvkhaosat.Size = new System.Drawing.Size(667, 499);
            this.dgvkhaosat.TabIndex = 0;
            this.dgvkhaosat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkhaosat_CellContentClick);
            // 
            // lblmakhaosat
            // 
            this.lblmakhaosat.AutoSize = true;
            this.lblmakhaosat.Location = new System.Drawing.Point(3, 13);
            this.lblmakhaosat.Name = "lblmakhaosat";
            this.lblmakhaosat.Size = new System.Drawing.Size(83, 16);
            this.lblmakhaosat.TabIndex = 1;
            this.lblmakhaosat.Text = "Mã Khảo Sát";
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.Location = new System.Drawing.Point(3, 59);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(54, 16);
            this.lbltieude.TabIndex = 2;
            this.lbltieude.Text = "Tiêu Đề";
            // 
            // lblngaytao
            // 
            this.lblngaytao.AutoSize = true;
            this.lblngaytao.Location = new System.Drawing.Point(3, 108);
            this.lblngaytao.Name = "lblngaytao";
            this.lblngaytao.Size = new System.Drawing.Size(68, 16);
            this.lblngaytao.TabIndex = 3;
            this.lblngaytao.Text = "Ngày Tạo";
            // 
            // lbltrangthai
            // 
            this.lbltrangthai.AutoSize = true;
            this.lbltrangthai.Location = new System.Drawing.Point(3, 164);
            this.lbltrangthai.Name = "lbltrangthai";
            this.lbltrangthai.Size = new System.Drawing.Size(73, 16);
            this.lbltrangthai.TabIndex = 4;
            this.lbltrangthai.Text = "Trạng Thái";
            // 
            // txtmakhaosat
            // 
            this.txtmakhaosat.Location = new System.Drawing.Point(108, 13);
            this.txtmakhaosat.Name = "txtmakhaosat";
            this.txtmakhaosat.Size = new System.Drawing.Size(216, 22);
            this.txtmakhaosat.TabIndex = 5;
            // 
            // txttieude
            // 
            this.txttieude.Location = new System.Drawing.Point(108, 56);
            this.txttieude.Name = "txttieude";
            this.txttieude.Size = new System.Drawing.Size(216, 22);
            this.txttieude.TabIndex = 6;
            // 
            // txttrangthai
            // 
            this.txttrangthai.Location = new System.Drawing.Point(108, 164);
            this.txttrangthai.Name = "txttrangthai";
            this.txttrangthai.Size = new System.Drawing.Size(216, 22);
            this.txttrangthai.TabIndex = 8;
            // 
            // dtpngaytao
            // 
            this.dtpngaytao.Location = new System.Drawing.Point(108, 108);
            this.dtpngaytao.Name = "dtpngaytao";
            this.dtpngaytao.Size = new System.Drawing.Size(216, 22);
            this.dtpngaytao.TabIndex = 9;
            // 
            // btnthemkhaosat
            // 
            this.btnthemkhaosat.Location = new System.Drawing.Point(6, 221);
            this.btnthemkhaosat.Name = "btnthemkhaosat";
            this.btnthemkhaosat.Size = new System.Drawing.Size(94, 49);
            this.btnthemkhaosat.TabIndex = 10;
            this.btnthemkhaosat.Text = "Thêm";
            this.btnthemkhaosat.UseVisualStyleBackColor = true;
            this.btnthemkhaosat.Click += new System.EventHandler(this.btnthemkhaosat_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(206, 221);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(94, 49);
            this.btnxoa.TabIndex = 11;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(106, 221);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(94, 49);
            this.btnsua.TabIndex = 12;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnlammoi
            // 
            this.btnlammoi.Location = new System.Drawing.Point(6, 293);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(94, 49);
            this.btnlammoi.TabIndex = 13;
            this.btnlammoi.Text = "Làm Mới";
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btntaocauhoi
            // 
            this.btntaocauhoi.Location = new System.Drawing.Point(6, 362);
            this.btntaocauhoi.Name = "btntaocauhoi";
            this.btntaocauhoi.Size = new System.Drawing.Size(116, 49);
            this.btntaocauhoi.TabIndex = 15;
            this.btntaocauhoi.Text = "Tạo Câu Hỏi";
            this.btntaocauhoi.UseVisualStyleBackColor = true;
            this.btntaocauhoi.Click += new System.EventHandler(this.btntaocauhoi_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(108, 293);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(94, 49);
            this.btnback.TabIndex = 16;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btndangbai
            // 
            this.btndangbai.Location = new System.Drawing.Point(128, 362);
            this.btndangbai.Name = "btndangbai";
            this.btndangbai.Size = new System.Drawing.Size(116, 49);
            this.btndangbai.TabIndex = 17;
            this.btndangbai.Text = "Đăng Bài";
            this.btndangbai.UseVisualStyleBackColor = true;
            this.btndangbai.Click += new System.EventHandler(this.btndangbai_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnxemketqua);
            this.panel1.Controls.Add(this.btnxemtruoc);
            this.panel1.Controls.Add(this.btndangbai);
            this.panel1.Controls.Add(this.lblmakhaosat);
            this.panel1.Controls.Add(this.btntaocauhoi);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.txtmakhaosat);
            this.panel1.Controls.Add(this.txttieude);
            this.panel1.Controls.Add(this.btnlammoi);
            this.panel1.Controls.Add(this.lbltieude);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.lblngaytao);
            this.panel1.Controls.Add(this.dtpngaytao);
            this.panel1.Controls.Add(this.btnthemkhaosat);
            this.panel1.Controls.Add(this.lbltrangthai);
            this.panel1.Controls.Add(this.txttrangthai);
            this.panel1.Location = new System.Drawing.Point(689, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 521);
            this.panel1.TabIndex = 1;
            // 
            // btnxemketqua
            // 
            this.btnxemketqua.Location = new System.Drawing.Point(208, 293);
            this.btnxemketqua.Name = "btnxemketqua";
            this.btnxemketqua.Size = new System.Drawing.Size(92, 49);
            this.btnxemketqua.TabIndex = 19;
            this.btnxemketqua.Text = "Xem Kết Quả";
            this.btnxemketqua.UseVisualStyleBackColor = true;
            this.btnxemketqua.Click += new System.EventHandler(this.btnxemketqua_Click);
            // 
            // btnxemtruoc
            // 
            this.btnxemtruoc.Location = new System.Drawing.Point(6, 429);
            this.btnxemtruoc.Name = "btnxemtruoc";
            this.btnxemtruoc.Size = new System.Drawing.Size(238, 51);
            this.btnxemtruoc.TabIndex = 18;
            this.btnxemtruoc.Text = "Xem giao diện làm bài";
            this.btnxemtruoc.UseVisualStyleBackColor = true;
            this.btnxemtruoc.Click += new System.EventHandler(this.btnxemtruoc_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbdanhsachbaikhaosat);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 541);
            this.panel2.TabIndex = 2;
            // 
            // KhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 547);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KhaoSat";
            this.Load += new System.EventHandler(this.KhaoSat_Load);
            this.grbdanhsachbaikhaosat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhaosat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbdanhsachbaikhaosat;
        private System.Windows.Forms.DataGridView dgvkhaosat;
        private System.Windows.Forms.Label lblmakhaosat;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.Label lblngaytao;
        private System.Windows.Forms.Label lbltrangthai;
        private System.Windows.Forms.TextBox txtmakhaosat;
        private System.Windows.Forms.TextBox txttieude;
        private System.Windows.Forms.TextBox txttrangthai;
        private System.Windows.Forms.DateTimePicker dtpngaytao;
        private System.Windows.Forms.Button btnthemkhaosat;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button btntaocauhoi;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btndangbai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnxemtruoc;
        private System.Windows.Forms.Button btnxemketqua;
    }
}