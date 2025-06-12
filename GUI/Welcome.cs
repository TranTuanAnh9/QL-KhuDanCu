using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void llblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CuDanPhanAnhKienNghi cuDanPhanAnhKienNghi = new CuDanPhanAnhKienNghi();
            cuDanPhanAnhKienNghi.Show();

        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://127.0.0.1:5500/Welcom.html");
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

