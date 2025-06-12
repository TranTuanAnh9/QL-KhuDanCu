namespace GUI
{
    partial class DangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKy));
            this.btnthoat = new System.Windows.Forms.Button();
            this.btndangki = new System.Windows.Forms.Button();
            this.txtmkdangki = new System.Windows.Forms.TextBox();
            this.txtdangki = new System.Windows.Forms.TextBox();
            this.lblsignup = new System.Windows.Forms.Label();
            this.lblmk = new System.Windows.Forms.Label();
            this.lbltk = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnthoat
            // 
            this.btnthoat.ForeColor = System.Drawing.Color.Black;
            this.btnthoat.Location = new System.Drawing.Point(309, 325);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(94, 40);
            this.btnthoat.TabIndex = 8;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btndangki
            // 
            this.btndangki.ForeColor = System.Drawing.Color.Black;
            this.btndangki.Location = new System.Drawing.Point(189, 325);
            this.btndangki.Name = "btndangki";
            this.btndangki.Size = new System.Drawing.Size(94, 40);
            this.btndangki.TabIndex = 7;
            this.btndangki.Text = "Đăng Kí";
            this.btndangki.UseVisualStyleBackColor = true;
            this.btndangki.Click += new System.EventHandler(this.btndangki_Click);
            // 
            // txtmkdangki
            // 
            this.txtmkdangki.Location = new System.Drawing.Point(227, 267);
            this.txtmkdangki.Name = "txtmkdangki";
            this.txtmkdangki.Size = new System.Drawing.Size(304, 22);
            this.txtmkdangki.TabIndex = 6;
            // 
            // txtdangki
            // 
            this.txtdangki.Location = new System.Drawing.Point(227, 216);
            this.txtdangki.Name = "txtdangki";
            this.txtdangki.Size = new System.Drawing.Size(304, 22);
            this.txtdangki.TabIndex = 5;
            // 
            // lblsignup
            // 
            this.lblsignup.AutoSize = true;
            this.lblsignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsignup.ForeColor = System.Drawing.Color.Black;
            this.lblsignup.Location = new System.Drawing.Point(206, 122);
            this.lblsignup.Name = "lblsignup";
            this.lblsignup.Size = new System.Drawing.Size(140, 38);
            this.lblsignup.TabIndex = 2;
            this.lblsignup.Text = "Sign Up";
            // 
            // lblmk
            // 
            this.lblmk.AutoSize = true;
            this.lblmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmk.ForeColor = System.Drawing.Color.Lime;
            this.lblmk.Location = new System.Drawing.Point(57, 269);
            this.lblmk.Name = "lblmk";
            this.lblmk.Size = new System.Drawing.Size(88, 20);
            this.lblmk.TabIndex = 4;
            this.lblmk.Text = "Mật Khẩu";
            // 
            // lbltk
            // 
            this.lbltk.AutoSize = true;
            this.lbltk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltk.ForeColor = System.Drawing.Color.Lime;
            this.lbltk.Location = new System.Drawing.Point(57, 216);
            this.lbltk.Name = "lbltk";
            this.lbltk.Size = new System.Drawing.Size(138, 20);
            this.lbltk.TabIndex = 3;
            this.lbltk.Text = "Tên Đăng Nhập";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.Screenshot_2025_04_18_1522461;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1197, 691);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 690);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btndangki);
            this.Controls.Add(this.lbltk);
            this.Controls.Add(this.txtmkdangki);
            this.Controls.Add(this.txtdangki);
            this.Controls.Add(this.lblmk);
            this.Controls.Add(this.lblsignup);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "DangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            this.Load += new System.EventHandler(this.DangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btndangki;
        private System.Windows.Forms.TextBox txtmkdangki;
        private System.Windows.Forms.TextBox txtdangki;
        private System.Windows.Forms.Label lblsignup;
        private System.Windows.Forms.Label lblmk;
        private System.Windows.Forms.Label lbltk;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}