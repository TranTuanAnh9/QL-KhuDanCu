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
    public partial class TrangChuNguoiThueTro : Form
    {
        TamTru TamTru = new TamTru();
        private string TenDangNhap;
        private string ChucVu;

        public TrangChuNguoiThueTro(string tenDangNhap, string chucVu)
        {
            InitializeComponent();
            this.TenDangNhap = tenDangNhap;
            this.ChucVu = chucVu;
        }
        public TrangChuNguoiThueTro()
        {
            InitializeComponent();
        }

        private void TrangChuNguoiThueTro_Load(object sender, EventArgs e)
        {
            btntimkiem.BackColor = Color.LightSkyBlue;
            pnlnguoitamtru.BackColor = Color.LightSlateGray;
            btnback.BackColor = Color.LightSkyBlue;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txttimkiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa)) // Kiểm tra nếu chưa nhập gì
            {
                MessageBox.Show("Hãy nhập thông tin để tìm kiếm.");
                return; // Dừng lại nếu chưa nhập gì
            }
            var ketQua = TamTru.TimKiemTheoTuKhoa1(tuKhoa);

            LichsuhoatdongDTO lichSu = new LichsuhoatdongDTO
            {
                TenDangNhap = TenDangNhap,
                ChucVu = ChucVu,
                HanhDong = "Tìm kiếm thông tin",
                NoiDung = $"Tìm kiếm với từ khóa: {tuKhoa}",
                ThoiGian = DateTime.Now
            };
            LichsuhoatdongBLL lichSuBLL = new LichsuhoatdongBLL();
            lichSuBLL.ThemLichSuHoatDong(lichSu);


            if (ketQua == null)
            {
                MessageBox.Show("Không có thông tin với mã này.");
                return;
            }

            dgvkhutro.Visible = true;
            dgvnguoithuetro.Visible = true;
            switch (ketQua.Loai)
            {
                case "KhuTro":
                    dgvkhutro.DataSource = ketQua.DuLieu1;
                    dgvkhutro.Visible = true;
                    break;

                case "NguoiThueTro":
                    dgvnguoithuetro.DataSource = ketQua.DuLieu1;
                    dgvnguoithuetro.Visible = true;
                    break;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome welcome = new Welcome();
            welcome.ShowDialog();
        }
    }
}
