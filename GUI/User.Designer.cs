namespace GUI
{
    partial class User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User));
            this.grbuser = new System.Windows.Forms.GroupBox();
            this.txtvaitro = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.txttendangnhap = new System.Windows.Forms.TextBox();
            this.txtmauser = new System.Windows.Forms.TextBox();
            this.lblvaitro = new System.Windows.Forms.Label();
            this.lblmatkhau = new System.Windows.Forms.Label();
            this.lbltendangnhap = new System.Windows.Forms.Label();
            this.lblmauser = new System.Windows.Forms.Label();
            this.grb3user = new System.Windows.Forms.GroupBox();
            this.btnlammoiuser = new System.Windows.Forms.Button();
            this.btnthemuser = new System.Windows.Forms.Button();
            this.btnsuauser = new System.Windows.Forms.Button();
            this.btnxoauser = new System.Windows.Forms.Button();
            this.grb2user = new System.Windows.Forms.GroupBox();
            this.dtvuser = new System.Windows.Forms.DataGridView();
            this.pnl1user = new System.Windows.Forms.Panel();
            this.lblquanlyuser = new System.Windows.Forms.Label();
            this.btntimkiemuser = new System.Windows.Forms.Button();
            this.grbtimkiemuser = new System.Windows.Forms.GroupBox();
            this.txttimkiemuser = new System.Windows.Forms.TextBox();
            this.btnlshd = new System.Windows.Forms.Button();
            this.grbuser.SuspendLayout();
            this.grb3user.SuspendLayout();
            this.grb2user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvuser)).BeginInit();
            this.pnl1user.SuspendLayout();
            this.grbtimkiemuser.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbuser
            // 
            this.grbuser.Controls.Add(this.txtvaitro);
            this.grbuser.Controls.Add(this.txtmatkhau);
            this.grbuser.Controls.Add(this.txttendangnhap);
            this.grbuser.Controls.Add(this.txtmauser);
            this.grbuser.Controls.Add(this.lblvaitro);
            this.grbuser.Controls.Add(this.lblmatkhau);
            this.grbuser.Controls.Add(this.lbltendangnhap);
            this.grbuser.Controls.Add(this.lblmauser);
            this.grbuser.Location = new System.Drawing.Point(685, 77);
            this.grbuser.Name = "grbuser";
            this.grbuser.Size = new System.Drawing.Size(436, 328);
            this.grbuser.TabIndex = 28;
            this.grbuser.TabStop = false;
            this.grbuser.Text = "Thông tin nhập vào";
            // 
            // txtvaitro
            // 
            this.txtvaitro.Location = new System.Drawing.Point(142, 185);
            this.txtvaitro.Name = "txtvaitro";
            this.txtvaitro.Size = new System.Drawing.Size(288, 22);
            this.txtvaitro.TabIndex = 15;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(142, 132);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(288, 22);
            this.txtmatkhau.TabIndex = 14;
            // 
            // txttendangnhap
            // 
            this.txttendangnhap.Location = new System.Drawing.Point(142, 81);
            this.txttendangnhap.Name = "txttendangnhap";
            this.txttendangnhap.Size = new System.Drawing.Size(288, 22);
            this.txttendangnhap.TabIndex = 12;
            // 
            // txtmauser
            // 
            this.txtmauser.Location = new System.Drawing.Point(142, 31);
            this.txtmauser.Name = "txtmauser";
            this.txtmauser.Size = new System.Drawing.Size(288, 22);
            this.txtmauser.TabIndex = 11;
            this.txtmauser.TextChanged += new System.EventHandler(this.txtmaghinhan_TextChanged);
            // 
            // lblvaitro
            // 
            this.lblvaitro.AutoSize = true;
            this.lblvaitro.Location = new System.Drawing.Point(7, 188);
            this.lblvaitro.Name = "lblvaitro";
            this.lblvaitro.Size = new System.Drawing.Size(51, 16);
            this.lblvaitro.TabIndex = 7;
            this.lblvaitro.Text = "Vai Trò";
            // 
            // lblmatkhau
            // 
            this.lblmatkhau.AutoSize = true;
            this.lblmatkhau.Location = new System.Drawing.Point(7, 138);
            this.lblmatkhau.Name = "lblmatkhau";
            this.lblmatkhau.Size = new System.Drawing.Size(62, 16);
            this.lblmatkhau.TabIndex = 2;
            this.lblmatkhau.Text = "Mật Khẩu";
            // 
            // lbltendangnhap
            // 
            this.lbltendangnhap.AutoSize = true;
            this.lbltendangnhap.Location = new System.Drawing.Point(7, 87);
            this.lbltendangnhap.Name = "lbltendangnhap";
            this.lbltendangnhap.Size = new System.Drawing.Size(102, 16);
            this.lbltendangnhap.TabIndex = 1;
            this.lbltendangnhap.Text = "Tên Đăng Nhập";
            // 
            // lblmauser
            // 
            this.lblmauser.AutoSize = true;
            this.lblmauser.Location = new System.Drawing.Point(7, 34);
            this.lblmauser.Name = "lblmauser";
            this.lblmauser.Size = new System.Drawing.Size(58, 16);
            this.lblmauser.TabIndex = 0;
            this.lblmauser.Text = "Mã User";
            // 
            // grb3user
            // 
            this.grb3user.Controls.Add(this.btnlammoiuser);
            this.grb3user.Controls.Add(this.btnthemuser);
            this.grb3user.Controls.Add(this.btnsuauser);
            this.grb3user.Controls.Add(this.btnxoauser);
            this.grb3user.Location = new System.Drawing.Point(3, 335);
            this.grb3user.Name = "grb3user";
            this.grb3user.Size = new System.Drawing.Size(676, 70);
            this.grb3user.TabIndex = 27;
            this.grb3user.TabStop = false;
            this.grb3user.Text = "Chức năng";
            // 
            // btnlammoiuser
            // 
            this.btnlammoiuser.BackColor = System.Drawing.Color.Silver;
            this.btnlammoiuser.Location = new System.Drawing.Point(535, 21);
            this.btnlammoiuser.Name = "btnlammoiuser";
            this.btnlammoiuser.Size = new System.Drawing.Size(90, 40);
            this.btnlammoiuser.TabIndex = 4;
            this.btnlammoiuser.Text = "Làm mới";
            this.btnlammoiuser.UseVisualStyleBackColor = false;
            this.btnlammoiuser.Click += new System.EventHandler(this.btnlammoiuser_Click);
            // 
            // btnthemuser
            // 
            this.btnthemuser.BackColor = System.Drawing.Color.Silver;
            this.btnthemuser.Location = new System.Drawing.Point(43, 21);
            this.btnthemuser.Name = "btnthemuser";
            this.btnthemuser.Size = new System.Drawing.Size(90, 40);
            this.btnthemuser.TabIndex = 3;
            this.btnthemuser.Text = "Thêm";
            this.btnthemuser.UseVisualStyleBackColor = false;
            this.btnthemuser.Click += new System.EventHandler(this.btnthemuser_Click);
            // 
            // btnsuauser
            // 
            this.btnsuauser.BackColor = System.Drawing.Color.Silver;
            this.btnsuauser.Location = new System.Drawing.Point(202, 21);
            this.btnsuauser.Name = "btnsuauser";
            this.btnsuauser.Size = new System.Drawing.Size(90, 40);
            this.btnsuauser.TabIndex = 2;
            this.btnsuauser.Text = "Sửa";
            this.btnsuauser.UseVisualStyleBackColor = false;
            this.btnsuauser.Click += new System.EventHandler(this.btnsuauser_Click);
            // 
            // btnxoauser
            // 
            this.btnxoauser.BackColor = System.Drawing.Color.Silver;
            this.btnxoauser.Location = new System.Drawing.Point(380, 21);
            this.btnxoauser.Name = "btnxoauser";
            this.btnxoauser.Size = new System.Drawing.Size(90, 40);
            this.btnxoauser.TabIndex = 1;
            this.btnxoauser.Text = "Xóa";
            this.btnxoauser.UseVisualStyleBackColor = false;
            this.btnxoauser.Click += new System.EventHandler(this.btnxoauser_Click);
            // 
            // grb2user
            // 
            this.grb2user.Controls.Add(this.dtvuser);
            this.grb2user.Location = new System.Drawing.Point(3, 73);
            this.grb2user.Name = "grb2user";
            this.grb2user.Size = new System.Drawing.Size(676, 256);
            this.grb2user.TabIndex = 26;
            this.grb2user.TabStop = false;
            this.grb2user.Text = "Thông Tin User";
            // 
            // dtvuser
            // 
            this.dtvuser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvuser.Location = new System.Drawing.Point(6, 21);
            this.dtvuser.Name = "dtvuser";
            this.dtvuser.RowHeadersWidth = 51;
            this.dtvuser.RowTemplate.Height = 24;
            this.dtvuser.Size = new System.Drawing.Size(670, 229);
            this.dtvuser.TabIndex = 0;
            this.dtvuser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvuser_CellContentClick);
            // 
            // pnl1user
            // 
            this.pnl1user.Controls.Add(this.btnlshd);
            this.pnl1user.Controls.Add(this.lblquanlyuser);
            this.pnl1user.Controls.Add(this.btntimkiemuser);
            this.pnl1user.Controls.Add(this.grbtimkiemuser);
            this.pnl1user.Location = new System.Drawing.Point(3, 4);
            this.pnl1user.Name = "pnl1user";
            this.pnl1user.Size = new System.Drawing.Size(1118, 62);
            this.pnl1user.TabIndex = 25;
            // 
            // lblquanlyuser
            // 
            this.lblquanlyuser.AutoSize = true;
            this.lblquanlyuser.Location = new System.Drawing.Point(49, 10);
            this.lblquanlyuser.Name = "lblquanlyuser";
            this.lblquanlyuser.Size = new System.Drawing.Size(88, 16);
            this.lblquanlyuser.TabIndex = 4;
            this.lblquanlyuser.Text = "Quản Lý User";
            this.lblquanlyuser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btntimkiemuser
            // 
            this.btntimkiemuser.Location = new System.Drawing.Point(346, 10);
            this.btntimkiemuser.Name = "btntimkiemuser";
            this.btntimkiemuser.Size = new System.Drawing.Size(105, 49);
            this.btntimkiemuser.TabIndex = 1;
            this.btntimkiemuser.Text = "Tìm Kiếm";
            this.btntimkiemuser.UseVisualStyleBackColor = true;
            this.btntimkiemuser.Click += new System.EventHandler(this.btntimkiemuser_Click);
            // 
            // grbtimkiemuser
            // 
            this.grbtimkiemuser.Controls.Add(this.txttimkiemuser);
            this.grbtimkiemuser.Location = new System.Drawing.Point(457, 3);
            this.grbtimkiemuser.Name = "grbtimkiemuser";
            this.grbtimkiemuser.Size = new System.Drawing.Size(247, 56);
            this.grbtimkiemuser.TabIndex = 0;
            this.grbtimkiemuser.TabStop = false;
            this.grbtimkiemuser.Text = "Tìm kiếm";
            // 
            // txttimkiemuser
            // 
            this.txttimkiemuser.Location = new System.Drawing.Point(7, 28);
            this.txttimkiemuser.Name = "txttimkiemuser";
            this.txttimkiemuser.Size = new System.Drawing.Size(232, 22);
            this.txttimkiemuser.TabIndex = 0;
            // 
            // btnlshd
            // 
            this.btnlshd.Location = new System.Drawing.Point(982, 10);
            this.btnlshd.Name = "btnlshd";
            this.btnlshd.Size = new System.Drawing.Size(128, 43);
            this.btnlshd.TabIndex = 5;
            this.btnlshd.Text = "Lịch sử hoạt động";
            this.btnlshd.UseVisualStyleBackColor = true;
            this.btnlshd.Click += new System.EventHandler(this.btnlshd_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 409);
            this.Controls.Add(this.grbuser);
            this.Controls.Add(this.grb3user);
            this.Controls.Add(this.grb2user);
            this.Controls.Add(this.pnl1user);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            this.grbuser.ResumeLayout(false);
            this.grbuser.PerformLayout();
            this.grb3user.ResumeLayout(false);
            this.grb2user.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtvuser)).EndInit();
            this.pnl1user.ResumeLayout(false);
            this.pnl1user.PerformLayout();
            this.grbtimkiemuser.ResumeLayout(false);
            this.grbtimkiemuser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbuser;
        private System.Windows.Forms.TextBox txtvaitro;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.TextBox txttendangnhap;
        private System.Windows.Forms.TextBox txtmauser;
        private System.Windows.Forms.Label lblvaitro;
        private System.Windows.Forms.Label lblmatkhau;
        private System.Windows.Forms.Label lbltendangnhap;
        private System.Windows.Forms.Label lblmauser;
        private System.Windows.Forms.GroupBox grb3user;
        private System.Windows.Forms.Button btnlammoiuser;
        private System.Windows.Forms.Button btnthemuser;
        private System.Windows.Forms.Button btnsuauser;
        private System.Windows.Forms.Button btnxoauser;
        private System.Windows.Forms.GroupBox grb2user;
        private System.Windows.Forms.DataGridView dtvuser;
        private System.Windows.Forms.Panel pnl1user;
        private System.Windows.Forms.Label lblquanlyuser;
        private System.Windows.Forms.Button btntimkiemuser;
        private System.Windows.Forms.GroupBox grbtimkiemuser;
        private System.Windows.Forms.TextBox txttimkiemuser;
        private System.Windows.Forms.Button btnlshd;
    }
}