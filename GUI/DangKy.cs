using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangKy : Form
    {
        UserBLL userbll = new UserBLL();
        public DangKy()
        {
            InitializeComponent();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            btnthoat.BackColor = Color.LightGreen;
            btndangki.BackColor = Color.LightGreen;
            lblsignup.BackColor = Color.LightGreen;
        }

        private void btndangki_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO
           
            {
                TenDangNhap = txtdangki.Text.Trim(),
                MatKhau = txtmkdangki.Text.Trim()
                // VaiTro được tự động xác định trong BLL
            };

            string ketQua = userbll.ThemUser(user);
            MessageBox.Show(ketQua);
            if (ketQua == "Đăng Ký Thành Công!.")
            {
                this.Hide(); // hoặc quay lại màn hình đăng nhập
                DangNhap dangNhap = new DangNhap();
                dangNhap.Show();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome welcome = new Welcome();
            welcome.Show();
        }
    }
}
