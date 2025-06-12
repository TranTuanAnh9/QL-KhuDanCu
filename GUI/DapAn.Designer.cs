namespace GUI
{
    partial class DapAn
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
            this.lbldapanchocauhoi = new System.Windows.Forms.Label();
            this.grbdanhsachdapantheocauhoi = new System.Windows.Forms.GroupBox();
            this.dgvdapan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.btnlammoi = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtnoidungdapan = new System.Windows.Forms.TextBox();
            this.txtmacauhoi = new System.Windows.Forms.TextBox();
            this.lblnoidungcauhoi = new System.Windows.Forms.Label();
            this.lblmacauhoi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbdanhsachdapantheocauhoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdapan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbldapanchocauhoi
            // 
            this.lbldapanchocauhoi.AutoSize = true;
            this.lbldapanchocauhoi.Location = new System.Drawing.Point(11, 6);
            this.lbldapanchocauhoi.Name = "lbldapanchocauhoi";
            this.lbldapanchocauhoi.Size = new System.Drawing.Size(186, 16);
            this.lbldapanchocauhoi.TabIndex = 0;
            this.lbldapanchocauhoi.Text = "Câu hỏi đang được tạo đáp án";
            // 
            // grbdanhsachdapantheocauhoi
            // 
            this.grbdanhsachdapantheocauhoi.Controls.Add(this.dgvdapan);
            this.grbdanhsachdapantheocauhoi.Location = new System.Drawing.Point(3, 46);
            this.grbdanhsachdapantheocauhoi.Name = "grbdanhsachdapantheocauhoi";
            this.grbdanhsachdapantheocauhoi.Size = new System.Drawing.Size(568, 546);
            this.grbdanhsachdapantheocauhoi.TabIndex = 2;
            this.grbdanhsachdapantheocauhoi.TabStop = false;
            this.grbdanhsachdapantheocauhoi.Text = "Danh sách đáp án theo câu hỏi";
            // 
            // dgvdapan
            // 
            this.dgvdapan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdapan.Location = new System.Drawing.Point(7, 22);
            this.dgvdapan.Name = "dgvdapan";
            this.dgvdapan.RowHeadersWidth = 51;
            this.dgvdapan.RowTemplate.Height = 24;
            this.dgvdapan.Size = new System.Drawing.Size(555, 510);
            this.dgvdapan.TabIndex = 0;
            this.dgvdapan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdapan_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.btnlammoi);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Controls.Add(this.txtnoidungdapan);
            this.panel1.Controls.Add(this.txtmacauhoi);
            this.panel1.Controls.Add(this.lblnoidungcauhoi);
            this.panel1.Controls.Add(this.lblmacauhoi);
            this.panel1.Location = new System.Drawing.Point(577, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 533);
            this.panel1.TabIndex = 3;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(137, 215);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(97, 54);
            this.btnback.TabIndex = 10;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnlammoi
            // 
            this.btnlammoi.Location = new System.Drawing.Point(3, 215);
            this.btnlammoi.Name = "btnlammoi";
            this.btnlammoi.Size = new System.Drawing.Size(97, 54);
            this.btnlammoi.TabIndex = 9;
            this.btnlammoi.Text = "Làm mới";
            this.btnlammoi.UseVisualStyleBackColor = true;
            this.btnlammoi.Click += new System.EventHandler(this.btnlammoi_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(267, 134);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(97, 54);
            this.btnxoa.TabIndex = 8;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(137, 134);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(97, 54);
            this.btnsua.TabIndex = 7;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(3, 134);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(97, 54);
            this.btnthem.TabIndex = 6;
            this.btnthem.Text = "Thêm ";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtnoidungdapan
            // 
            this.txtnoidungdapan.Location = new System.Drawing.Point(163, 54);
            this.txtnoidungdapan.Name = "txtnoidungdapan";
            this.txtnoidungdapan.Size = new System.Drawing.Size(225, 22);
            this.txtnoidungdapan.TabIndex = 5;
            // 
            // txtmacauhoi
            // 
            this.txtmacauhoi.Location = new System.Drawing.Point(163, 12);
            this.txtmacauhoi.Name = "txtmacauhoi";
            this.txtmacauhoi.Size = new System.Drawing.Size(225, 22);
            this.txtmacauhoi.TabIndex = 4;
            // 
            // lblnoidungcauhoi
            // 
            this.lblnoidungcauhoi.AutoSize = true;
            this.lblnoidungcauhoi.Location = new System.Drawing.Point(13, 54);
            this.lblnoidungcauhoi.Name = "lblnoidungcauhoi";
            this.lblnoidungcauhoi.Size = new System.Drawing.Size(106, 16);
            this.lblnoidungcauhoi.TabIndex = 2;
            this.lblnoidungcauhoi.Text = "Nội dung đáp án";
            // 
            // lblmacauhoi
            // 
            this.lblmacauhoi.AutoSize = true;
            this.lblmacauhoi.Location = new System.Drawing.Point(13, 12);
            this.lblmacauhoi.Name = "lblmacauhoi";
            this.lblmacauhoi.Size = new System.Drawing.Size(72, 16);
            this.lblmacauhoi.TabIndex = 1;
            this.lblmacauhoi.Text = "Mã câu hỏi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.lbldapanchocauhoi);
            this.panel2.Controls.Add(this.grbdanhsachdapantheocauhoi);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 595);
            this.panel2.TabIndex = 4;
            // 
            // DapAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 603);
            this.Controls.Add(this.panel2);
            this.Name = "DapAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DapAn";
            this.Load += new System.EventHandler(this.DapAn_Load);
            this.grbdanhsachdapantheocauhoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdapan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbldapanchocauhoi;
        private System.Windows.Forms.GroupBox grbdanhsachdapantheocauhoi;
        private System.Windows.Forms.DataGridView dgvdapan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtnoidungdapan;
        private System.Windows.Forms.TextBox txtmacauhoi;
        private System.Windows.Forms.Label lblnoidungcauhoi;
        private System.Windows.Forms.Label lblmacauhoi;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnlammoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}