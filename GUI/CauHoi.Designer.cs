namespace GUI
{
    partial class CauHoi
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
            this.grbcauhoi = new System.Windows.Forms.GroupBox();
            this.dgvauhoi = new System.Windows.Forms.DataGridView();
            this.cbbcauhoi = new System.Windows.Forms.ComboBox();
            this.lblmakhaosat = new System.Windows.Forms.Label();
            this.lblnoidung = new System.Windows.Forms.Label();
            this.lblkieu = new System.Windows.Forms.Label();
            this.lblthutu = new System.Windows.Forms.Label();
            this.txtmakhaosat = new System.Windows.Forms.TextBox();
            this.txtnoidung = new System.Windows.Forms.TextBox();
            this.rdbtuluan = new System.Windows.Forms.RadioButton();
            this.rdbtracnghiem = new System.Windows.Forms.RadioButton();
            this.txtthutu = new System.Windows.Forms.TextBox();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.btntaodapan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblcauhoi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbcauhoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvauhoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbcauhoi
            // 
            this.grbcauhoi.Controls.Add(this.dgvauhoi);
            this.grbcauhoi.Location = new System.Drawing.Point(10, 59);
            this.grbcauhoi.Name = "grbcauhoi";
            this.grbcauhoi.Size = new System.Drawing.Size(609, 577);
            this.grbcauhoi.TabIndex = 0;
            this.grbcauhoi.TabStop = false;
            this.grbcauhoi.Text = "Danh sách câu hỏi";
            // 
            // dgvauhoi
            // 
            this.dgvauhoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvauhoi.Location = new System.Drawing.Point(7, 21);
            this.dgvauhoi.Name = "dgvauhoi";
            this.dgvauhoi.RowHeadersWidth = 51;
            this.dgvauhoi.RowTemplate.Height = 24;
            this.dgvauhoi.Size = new System.Drawing.Size(596, 546);
            this.dgvauhoi.TabIndex = 0;
            this.dgvauhoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvauhoi_CellContentClick);
            // 
            // cbbcauhoi
            // 
            this.cbbcauhoi.FormattingEnabled = true;
            this.cbbcauhoi.Location = new System.Drawing.Point(205, 14);
            this.cbbcauhoi.Name = "cbbcauhoi";
            this.cbbcauhoi.Size = new System.Drawing.Size(805, 24);
            this.cbbcauhoi.TabIndex = 1;
            this.cbbcauhoi.SelectedIndexChanged += new System.EventHandler(this.cbbcauhoi_SelectedIndexChanged);
            // 
            // lblmakhaosat
            // 
            this.lblmakhaosat.AutoSize = true;
            this.lblmakhaosat.Location = new System.Drawing.Point(3, 56);
            this.lblmakhaosat.Name = "lblmakhaosat";
            this.lblmakhaosat.Size = new System.Drawing.Size(80, 16);
            this.lblmakhaosat.TabIndex = 3;
            this.lblmakhaosat.Text = "Mã khảo sát";
            // 
            // lblnoidung
            // 
            this.lblnoidung.AutoSize = true;
            this.lblnoidung.Location = new System.Drawing.Point(3, 96);
            this.lblnoidung.Name = "lblnoidung";
            this.lblnoidung.Size = new System.Drawing.Size(61, 16);
            this.lblnoidung.TabIndex = 4;
            this.lblnoidung.Text = "Nội dung";
            // 
            // lblkieu
            // 
            this.lblkieu.AutoSize = true;
            this.lblkieu.Location = new System.Drawing.Point(3, 140);
            this.lblkieu.Name = "lblkieu";
            this.lblkieu.Size = new System.Drawing.Size(33, 16);
            this.lblkieu.TabIndex = 5;
            this.lblkieu.Text = "Kiểu";
            // 
            // lblthutu
            // 
            this.lblthutu.AutoSize = true;
            this.lblthutu.Location = new System.Drawing.Point(3, 186);
            this.lblthutu.Name = "lblthutu";
            this.lblthutu.Size = new System.Drawing.Size(46, 16);
            this.lblthutu.TabIndex = 6;
            this.lblthutu.Text = "Thứ tự ";
            this.lblthutu.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtmakhaosat
            // 
            this.txtmakhaosat.Location = new System.Drawing.Point(95, 56);
            this.txtmakhaosat.Name = "txtmakhaosat";
            this.txtmakhaosat.Size = new System.Drawing.Size(217, 22);
            this.txtmakhaosat.TabIndex = 8;
            // 
            // txtnoidung
            // 
            this.txtnoidung.Location = new System.Drawing.Point(95, 96);
            this.txtnoidung.Name = "txtnoidung";
            this.txtnoidung.Size = new System.Drawing.Size(217, 22);
            this.txtnoidung.TabIndex = 9;
            this.txtnoidung.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // rdbtuluan
            // 
            this.rdbtuluan.AutoSize = true;
            this.rdbtuluan.Location = new System.Drawing.Point(95, 140);
            this.rdbtuluan.Name = "rdbtuluan";
            this.rdbtuluan.Size = new System.Drawing.Size(72, 20);
            this.rdbtuluan.TabIndex = 10;
            this.rdbtuluan.TabStop = true;
            this.rdbtuluan.Text = "Tự luận";
            this.rdbtuluan.UseVisualStyleBackColor = true;
            // 
            // rdbtracnghiem
            // 
            this.rdbtracnghiem.AutoSize = true;
            this.rdbtracnghiem.Location = new System.Drawing.Point(206, 140);
            this.rdbtracnghiem.Name = "rdbtracnghiem";
            this.rdbtracnghiem.Size = new System.Drawing.Size(106, 20);
            this.rdbtracnghiem.TabIndex = 11;
            this.rdbtracnghiem.TabStop = true;
            this.rdbtracnghiem.Text = "Trắc Nghiệm";
            this.rdbtracnghiem.UseVisualStyleBackColor = true;
            // 
            // txtthutu
            // 
            this.txtthutu.Location = new System.Drawing.Point(95, 186);
            this.txtthutu.Name = "txtthutu";
            this.txtthutu.Size = new System.Drawing.Size(217, 22);
            this.txtthutu.TabIndex = 12;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(6, 305);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(92, 49);
            this.btnthem.TabIndex = 13;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(113, 305);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(92, 49);
            this.btnsua.TabIndex = 14;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(220, 305);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(92, 49);
            this.btnxoa.TabIndex = 15;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnlammoi
            // 
            this.btnlammoi.Location = new System.Drawing.Point(6, 377);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(92, 49);
            this.btnlammoi.TabIndex = 16;
            this.btnlammoi.Text = "Làm Mới";
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(113, 377);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(92, 49);
            this.btnback.TabIndex = 17;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btntaodapan
            // 
            this.btntaodapan.Location = new System.Drawing.Point(6, 450);
            this.btntaodapan.Name = "btntaodapan";
            this.btntaodapan.Size = new System.Drawing.Size(118, 49);
            this.btntaodapan.TabIndex = 18;
            this.btntaodapan.Text = "Tạo Đáp Án";
            this.btntaodapan.UseVisualStyleBackColor = true;
            this.btntaodapan.Click += new System.EventHandler(this.btntaodapan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btntaodapan);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.btnlammoi);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.lblmakhaosat);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.txtmakhaosat);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Controls.Add(this.lblnoidung);
            this.panel1.Controls.Add(this.txtthutu);
            this.panel1.Controls.Add(this.txtnoidung);
            this.panel1.Controls.Add(this.lblthutu);
            this.panel1.Controls.Add(this.rdbtracnghiem);
            this.panel1.Controls.Add(this.lblkieu);
            this.panel1.Controls.Add(this.rdbtuluan);
            this.panel1.Location = new System.Drawing.Point(625, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 567);
            this.panel1.TabIndex = 1;
            // 
            // lblcauhoi
            // 
            this.lblcauhoi.AutoSize = true;
            this.lblcauhoi.Location = new System.Drawing.Point(10, 17);
            this.lblcauhoi.Name = "lblcauhoi";
            this.lblcauhoi.Size = new System.Drawing.Size(140, 16);
            this.lblcauhoi.TabIndex = 2;
            this.lblcauhoi.Text = "Bài khảo sát đang tạo ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lblcauhoi);
            this.panel2.Controls.Add(this.grbcauhoi);
            this.panel2.Controls.Add(this.cbbcauhoi);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 646);
            this.panel2.TabIndex = 2;
            // 
            // CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 650);
            this.Controls.Add(this.panel2);
            this.Name = "CauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CauHoi";
            this.Load += new System.EventHandler(this.CauHoi_Load);
            this.grbcauhoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvauhoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbcauhoi;
        private System.Windows.Forms.DataGridView dgvauhoi;
        private System.Windows.Forms.ComboBox cbbcauhoi;
        private System.Windows.Forms.Label lblmakhaosat;
        private System.Windows.Forms.Label lblnoidung;
        private System.Windows.Forms.Label lblkieu;
        private System.Windows.Forms.Label lblthutu;
        private System.Windows.Forms.TextBox txtmakhaosat;
        private System.Windows.Forms.TextBox txtnoidung;
        private System.Windows.Forms.RadioButton rdbtuluan;
        private System.Windows.Forms.RadioButton rdbtracnghiem;
        private System.Windows.Forms.TextBox txtthutu;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btntaodapan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblcauhoi;
        private System.Windows.Forms.Panel panel2;
    }
}