namespace GUI
{
    partial class KetQuaLamBai
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
            this.btnxemkq = new System.Windows.Forms.Button();
            this.txtMaKhaoSat = new System.Windows.Forms.TextBox();
            this.lblmabaikhaosat = new System.Windows.Forms.Label();
            this.txtMaUser = new System.Windows.Forms.TextBox();
            this.lblmauser = new System.Windows.Forms.Label();
            this.grbketqua = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grbketqua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnxemkq);
            this.panel1.Controls.Add(this.txtMaKhaoSat);
            this.panel1.Controls.Add(this.lblmabaikhaosat);
            this.panel1.Controls.Add(this.txtMaUser);
            this.panel1.Controls.Add(this.lblmauser);
            this.panel1.Controls.Add(this.grbketqua);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 616);
            this.panel1.TabIndex = 0;
            // 
            // btnxemkq
            // 
            this.btnxemkq.Location = new System.Drawing.Point(644, 21);
            this.btnxemkq.Name = "btnxemkq";
            this.btnxemkq.Size = new System.Drawing.Size(148, 46);
            this.btnxemkq.TabIndex = 5;
            this.btnxemkq.Text = "Xem Kết Quả";
            this.btnxemkq.UseVisualStyleBackColor = true;
            this.btnxemkq.Click += new System.EventHandler(this.btnxemkq_Click);
            // 
            // txtMaKhaoSat
            // 
            this.txtMaKhaoSat.Location = new System.Drawing.Point(414, 33);
            this.txtMaKhaoSat.Name = "txtMaKhaoSat";
            this.txtMaKhaoSat.Size = new System.Drawing.Size(185, 22);
            this.txtMaKhaoSat.TabIndex = 4;
            // 
            // lblmabaikhaosat
            // 
            this.lblmabaikhaosat.AutoSize = true;
            this.lblmabaikhaosat.Location = new System.Drawing.Point(286, 36);
            this.lblmabaikhaosat.Name = "lblmabaikhaosat";
            this.lblmabaikhaosat.Size = new System.Drawing.Size(106, 16);
            this.lblmabaikhaosat.TabIndex = 3;
            this.lblmabaikhaosat.Text = "Mã Bài Khảo Sát";
            // 
            // txtMaUser
            // 
            this.txtMaUser.Location = new System.Drawing.Point(92, 33);
            this.txtMaUser.Name = "txtMaUser";
            this.txtMaUser.Size = new System.Drawing.Size(165, 22);
            this.txtMaUser.TabIndex = 2;
            // 
            // lblmauser
            // 
            this.lblmauser.AutoSize = true;
            this.lblmauser.Location = new System.Drawing.Point(10, 36);
            this.lblmauser.Name = "lblmauser";
            this.lblmauser.Size = new System.Drawing.Size(58, 16);
            this.lblmauser.TabIndex = 1;
            this.lblmauser.Text = "Mã User";
            // 
            // grbketqua
            // 
            this.grbketqua.Controls.Add(this.dgvKetQua);
            this.grbketqua.Location = new System.Drawing.Point(10, 79);
            this.grbketqua.Name = "grbketqua";
            this.grbketqua.Size = new System.Drawing.Size(910, 528);
            this.grbketqua.TabIndex = 0;
            this.grbketqua.TabStop = false;
            this.grbketqua.Text = "Kết quả";
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(7, 22);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 24;
            this.dgvKetQua.Size = new System.Drawing.Size(897, 500);
            this.dgvKetQua.TabIndex = 0;
            // 
            // KetQuaLamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 622);
            this.Controls.Add(this.panel1);
            this.Name = "KetQuaLamBai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KetQuaLamBai";
            this.Load += new System.EventHandler(this.KetQuaLamBai_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbketqua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMaUser;
        private System.Windows.Forms.Label lblmauser;
        private System.Windows.Forms.GroupBox grbketqua;
        private System.Windows.Forms.Button btnxemkq;
        private System.Windows.Forms.TextBox txtMaKhaoSat;
        private System.Windows.Forms.Label lblmabaikhaosat;
        private System.Windows.Forms.DataGridView dgvKetQua;
    }
}