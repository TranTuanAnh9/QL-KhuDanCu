namespace GUI
{
    partial class TrangChuChuTro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChuChuTro));
            this.grbnguoithuetro = new System.Windows.Forms.GroupBox();
            this.dgvnguoithuetro = new System.Windows.Forms.DataGridView();
            this.grbkhutro = new System.Windows.Forms.GroupBox();
            this.dgvkhutro = new System.Windows.Forms.DataGridView();
            this.pnltrangchuchutro = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.btncudan = new System.Windows.Forms.Button();
            this.lbltrangchuchutro = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.grbnguoithuetro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnguoithuetro)).BeginInit();
            this.grbkhutro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhutro)).BeginInit();
            this.pnltrangchuchutro.SuspendLayout();
            this.grbtimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbnguoithuetro
            // 
            this.grbnguoithuetro.Controls.Add(this.dgvnguoithuetro);
            this.grbnguoithuetro.Location = new System.Drawing.Point(534, 73);
            this.grbnguoithuetro.Name = "grbnguoithuetro";
            this.grbnguoithuetro.Size = new System.Drawing.Size(528, 492);
            this.grbnguoithuetro.TabIndex = 16;
            this.grbnguoithuetro.TabStop = false;
            this.grbnguoithuetro.Text = "Thông Tin Người Thuê Trọ";
            // 
            // dgvnguoithuetro
            // 
            this.dgvnguoithuetro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvnguoithuetro.Location = new System.Drawing.Point(6, 22);
            this.dgvnguoithuetro.Name = "dgvnguoithuetro";
            this.dgvnguoithuetro.RowHeadersWidth = 51;
            this.dgvnguoithuetro.RowTemplate.Height = 24;
            this.dgvnguoithuetro.Size = new System.Drawing.Size(514, 459);
            this.dgvnguoithuetro.TabIndex = 1;
            // 
            // grbkhutro
            // 
            this.grbkhutro.Controls.Add(this.dgvkhutro);
            this.grbkhutro.Location = new System.Drawing.Point(5, 73);
            this.grbkhutro.Name = "grbkhutro";
            this.grbkhutro.Size = new System.Drawing.Size(523, 492);
            this.grbkhutro.TabIndex = 15;
            this.grbkhutro.TabStop = false;
            this.grbkhutro.Text = "Thông Tin Khu Trọ";
            // 
            // dgvkhutro
            // 
            this.dgvkhutro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhutro.Location = new System.Drawing.Point(7, 22);
            this.dgvkhutro.Name = "dgvkhutro";
            this.dgvkhutro.RowHeadersWidth = 51;
            this.dgvkhutro.RowTemplate.Height = 24;
            this.dgvkhutro.Size = new System.Drawing.Size(510, 459);
            this.dgvkhutro.TabIndex = 0;
            // 
            // pnltrangchuchutro
            // 
            this.pnltrangchuchutro.Controls.Add(this.btnback);
            this.pnltrangchuchutro.Controls.Add(this.btncudan);
            this.pnltrangchuchutro.Controls.Add(this.lbltrangchuchutro);
            this.pnltrangchuchutro.Controls.Add(this.btntimkiem);
            this.pnltrangchuchutro.Controls.Add(this.grbtimkiem);
            this.pnltrangchuchutro.Location = new System.Drawing.Point(5, 3);
            this.pnltrangchuchutro.Name = "pnltrangchuchutro";
            this.pnltrangchuchutro.Size = new System.Drawing.Size(1057, 63);
            this.pnltrangchuchutro.TabIndex = 14;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(951, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(98, 54);
            this.btnback.TabIndex = 26;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btncudan
            // 
            this.btncudan.Location = new System.Drawing.Point(215, 9);
            this.btncudan.Name = "btncudan";
            this.btncudan.Size = new System.Drawing.Size(105, 49);
            this.btncudan.TabIndex = 25;
            this.btncudan.Text = "Cư Dân";
            this.btncudan.UseVisualStyleBackColor = true;
            this.btncudan.Click += new System.EventHandler(this.btncudan_Click);
            // 
            // lbltrangchuchutro
            // 
            this.lbltrangchuchutro.AutoSize = true;
            this.lbltrangchuchutro.Location = new System.Drawing.Point(50, 12);
            this.lbltrangchuchutro.Name = "lbltrangchuchutro";
            this.lbltrangchuchutro.Size = new System.Drawing.Size(119, 16);
            this.lbltrangchuchutro.TabIndex = 4;
            this.lbltrangchuchutro.Text = "Trang Chủ Chủ Trọ";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(326, 9);
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
            this.grbtimkiem.Location = new System.Drawing.Point(437, 3);
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
            // TrangChuChuTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 568);
            this.Controls.Add(this.grbnguoithuetro);
            this.Controls.Add(this.grbkhutro);
            this.Controls.Add(this.pnltrangchuchutro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrangChuChuTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ Chủ Trọ";
            this.Load += new System.EventHandler(this.TrangChuChuTro_Load);
            this.grbnguoithuetro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvnguoithuetro)).EndInit();
            this.grbkhutro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhutro)).EndInit();
            this.pnltrangchuchutro.ResumeLayout(false);
            this.pnltrangchuchutro.PerformLayout();
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbnguoithuetro;
        private System.Windows.Forms.DataGridView dgvnguoithuetro;
        private System.Windows.Forms.GroupBox grbkhutro;
        private System.Windows.Forms.DataGridView dgvkhutro;
        private System.Windows.Forms.Panel pnltrangchuchutro;
        private System.Windows.Forms.Label lbltrangchuchutro;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btncudan;
        private System.Windows.Forms.Button btnback;
    }
}