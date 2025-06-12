namespace GUI
{
    partial class TrangChuNguoiThueTro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChuNguoiThueTro));
            this.grbnguoithuetro = new System.Windows.Forms.GroupBox();
            this.dgvnguoithuetro = new System.Windows.Forms.DataGridView();
            this.grbkhutro = new System.Windows.Forms.GroupBox();
            this.dgvkhutro = new System.Windows.Forms.DataGridView();
            this.pnlnguoitamtru = new System.Windows.Forms.Panel();
            this.btnback = new System.Windows.Forms.Button();
            this.lbltrangchunguoithuetro = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.grbtimkiem = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.grbnguoithuetro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnguoithuetro)).BeginInit();
            this.grbkhutro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhutro)).BeginInit();
            this.pnlnguoitamtru.SuspendLayout();
            this.grbtimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbnguoithuetro
            // 
            this.grbnguoithuetro.Controls.Add(this.dgvnguoithuetro);
            this.grbnguoithuetro.Location = new System.Drawing.Point(472, 73);
            this.grbnguoithuetro.Name = "grbnguoithuetro";
            this.grbnguoithuetro.Size = new System.Drawing.Size(499, 492);
            this.grbnguoithuetro.TabIndex = 13;
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
            this.dgvnguoithuetro.Size = new System.Drawing.Size(484, 459);
            this.dgvnguoithuetro.TabIndex = 1;
            // 
            // grbkhutro
            // 
            this.grbkhutro.Controls.Add(this.dgvkhutro);
            this.grbkhutro.Location = new System.Drawing.Point(4, 73);
            this.grbkhutro.Name = "grbkhutro";
            this.grbkhutro.Size = new System.Drawing.Size(462, 492);
            this.grbkhutro.TabIndex = 12;
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
            this.dgvkhutro.Size = new System.Drawing.Size(449, 459);
            this.dgvkhutro.TabIndex = 0;
            // 
            // pnlnguoitamtru
            // 
            this.pnlnguoitamtru.Controls.Add(this.btnback);
            this.pnlnguoitamtru.Controls.Add(this.lbltrangchunguoithuetro);
            this.pnlnguoitamtru.Controls.Add(this.btntimkiem);
            this.pnlnguoitamtru.Controls.Add(this.grbtimkiem);
            this.pnlnguoitamtru.Location = new System.Drawing.Point(4, 3);
            this.pnlnguoitamtru.Name = "pnlnguoitamtru";
            this.pnlnguoitamtru.Size = new System.Drawing.Size(967, 63);
            this.pnlnguoitamtru.TabIndex = 11;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(867, 4);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(97, 54);
            this.btnback.TabIndex = 5;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lbltrangchunguoithuetro
            // 
            this.lbltrangchunguoithuetro.AutoSize = true;
            this.lbltrangchunguoithuetro.Location = new System.Drawing.Point(50, 12);
            this.lbltrangchunguoithuetro.Name = "lbltrangchunguoithuetro";
            this.lbltrangchunguoithuetro.Size = new System.Drawing.Size(162, 16);
            this.lbltrangchunguoithuetro.TabIndex = 4;
            this.lbltrangchunguoithuetro.Text = "Trang Chủ Người Tạm Trú";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(351, 4);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(105, 54);
            this.btntimkiem.TabIndex = 1;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // grbtimkiem
            // 
            this.grbtimkiem.Controls.Add(this.txttimkiem);
            this.grbtimkiem.Location = new System.Drawing.Point(462, 4);
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
            // TrangChuNguoiThueTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 568);
            this.Controls.Add(this.grbnguoithuetro);
            this.Controls.Add(this.grbkhutro);
            this.Controls.Add(this.pnlnguoitamtru);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrangChuNguoiThueTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrangChuNguoiTamTru";
            this.Load += new System.EventHandler(this.TrangChuNguoiThueTro_Load);
            this.grbnguoithuetro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvnguoithuetro)).EndInit();
            this.grbkhutro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhutro)).EndInit();
            this.pnlnguoitamtru.ResumeLayout(false);
            this.pnlnguoitamtru.PerformLayout();
            this.grbtimkiem.ResumeLayout(false);
            this.grbtimkiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbnguoithuetro;
        private System.Windows.Forms.DataGridView dgvnguoithuetro;
        private System.Windows.Forms.GroupBox grbkhutro;
        private System.Windows.Forms.DataGridView dgvkhutro;
        private System.Windows.Forms.Panel pnlnguoitamtru;
        private System.Windows.Forms.Label lbltrangchunguoithuetro;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.GroupBox grbtimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btnback;
    }
}