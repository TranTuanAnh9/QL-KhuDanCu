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
    public partial class User : Form
    {
        private UserBLL userbll = new UserBLL();
        public User()
        {
            InitializeComponent();
        }

        private void txtmaghinhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void User_Load(object sender, EventArgs e)
        {
            txttimkiemuser.ForeColor = Color.Gray;
            txttimkiemuser.Text = "Tìm kiếm theo tên đăng nhập";

            txttimkiemuser.Enter += Txttimkiemuser_Enter;
            txttimkiemuser.Leave += Txttimkiemuser_Leave;
            pnl1user.BackColor = Color.LightCoral;
            grb3user.BackColor = Color.AliceBlue;
            grbuser.BackColor = Color.AliceBlue;
            btnthemuser.BackColor = Color.LightBlue;
            btnsuauser.BackColor = Color.LightBlue;
            btnxoauser.BackColor = Color.LightBlue;
            btnlammoiuser.BackColor = Color.LightBlue;
            btntimkiemuser.BackColor = Color.LightBlue;
            btnlshd.BackColor = Color.LightBlue;
            txtmauser.ReadOnly = true;
            txtvaitro.ReadOnly = true;
            LoadData();
        }
        private void Txttimkiemuser_Enter(object sender, EventArgs e)
        {
            if (txttimkiemuser.Text == "Tìm kiếm theo tên đăng nhập")
            {
                txttimkiemuser.Text = "";
                txttimkiemuser.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemuser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemuser.Text))
            {
                txttimkiemuser.Text = "Tìm kiếm theo tên đăng nhập";
                txttimkiemuser.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<UserDTO> danhSach = userbll.LayDanhSachUser();
            dtvuser.DataSource = danhSach;
        }

        private void btnthemuser_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO
            {
                TenDangNhap = txttendangnhap.Text.Trim(),
                MatKhau = txtmatkhau.Text.Trim()
                // VaiTro sẽ được xử lý trong BLL
            };

            string ketQua = userbll.ThemUser(user);
            MessageBox.Show(ketQua);
            if (ketQua == "Thêm user thành công !.")
            {
                LoadData(); // load lại dữ liệu
            }
        }

        private void dtvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvuser.Rows[e.RowIndex];

                txtmauser.Text = row.Cells["MaUser"].Value?.ToString();
                txttendangnhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtmatkhau.Text = row.Cells["MatKhau"].Value?.ToString();
                txtvaitro.Text = row.Cells["VaiTro"].Value?.ToString();
                txtmauser.ReadOnly = true;
                txtvaitro.ReadOnly = true;
            }
        }

        private void btnsuauser_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO
            {
                MaUser = int.Parse(txtmauser.Text.Trim()),
                TenDangNhap = txttendangnhap.Text.Trim(),
                MatKhau = txtmatkhau.Text.Trim()
                // VaiTro sẽ xử lý lại trong BLL theo TenDangNhap
            };

            string ketQua = userbll.SuaUser(user);
            MessageBox.Show(ketQua);
            if (ketQua == "Sửa user thành công!")
            {
                LoadData(); // refresh
            }
        }

        private void btnxoauser_Click(object sender, EventArgs e)
        {
            string maUser = txtmauser.Text.Trim();

            if (string.IsNullOrWhiteSpace(maUser))
            {
                MessageBox.Show("Vui lòng chọn tài khoản người dùng cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản người dùng có mã [{maUser}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = userbll.XoaUser(maUser);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa tài khoản người dùng thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btntimkiemuser_Click(object sender, EventArgs e)
        {
            txttimkiemuser.Focus(); // Đảm bảo text mới nhất được cập nhật
            string TenDangNhap = txttimkiemuser.Text.Trim();

            if (string.IsNullOrWhiteSpace(TenDangNhap))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = userbll.TimKiemUser(TenDangNhap);

            if (ketQua.Count > 0)
            {
                dtvuser.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoiuser_Click(object sender, EventArgs e)
        {
            txtmauser.Text = "";
            txttendangnhap.Text = "";
            txtmatkhau.Text = "";
            txtvaitro.Text = "";
            dtvuser.DataSource = null;
            dtvuser.Rows.Clear();
            LoadData();
        }

        private void btnlshd_Click(object sender, EventArgs e)
        {
            Lichsuhoatdong lichsuhoatdong = new Lichsuhoatdong();
            lichsuhoatdong.ShowDialog();
        }
    }
}
