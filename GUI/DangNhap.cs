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
    public partial class DangNhap : Form
    {
        private UserBLL userbll = new UserBLL();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
          
           btnthoat.BackColor = Color.LightGreen    ;
            btndangnhap.BackColor = Color.LightGreen;
            lbllogin.BackColor = Color.LightGreen;
        }

        private void lbllogin_Click(object sender, EventArgs e)
        {

        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txttendangnhap.Text.Trim();
            string matKhau = txtmkdangnhap.Text.Trim();

            UserDTO user = userbll.DangNhap(tenDangNhap, matKhau);

            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                return;
            }

            // Gán thông tin người dùng vào lớp CurrentUser
            CurrentUser.MaUser = user.MaUser;
            CurrentUser.TenDangNhap = user.TenDangNhap;
            CurrentUser.VaiTro = user.VaiTro;

            MessageBox.Show("Đăng nhập thành công với vai trò: " + user.VaiTro);

            // Mở form tương ứng theo vai trò
            this.Hide(); // Ẩn form đăng nhập

            if (user.VaiTro == "Cán bộ")
            {
                Trangchu trangchu = new Trangchu();
                trangchu.ShowDialog();
            }
            else if (user.VaiTro == "Chủ trọ")
            {
                TrangChuChuTro trangChuChuTro = new TrangChuChuTro(user.MaUser,user.TenDangNhap, user.VaiTro);
                trangChuChuTro.ShowDialog();
            }
            else if (user.VaiTro == "Cư dân")
            {
                Trangchucudan trangchucudan = new Trangchucudan(user.MaUser,tenDangNhap, user.VaiTro);
                trangchucudan.ShowDialog();
            }
            else if (user.VaiTro == "Trưởng thôn")
            {
                Trangchu trangchu = new Trangchu();
                trangchu.ShowDialog();
            }
            else if (user.VaiTro == "Tạm trú")
            {
                TrangChuNguoiThueTro trangChuNguoiThueTro = new TrangChuNguoiThueTro(user.TenDangNhap, user.VaiTro);
                trangChuNguoiThueTro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vai trò không được hỗ trợ.");
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
