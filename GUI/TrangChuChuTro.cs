using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class TrangChuChuTro : Form
    {
        ChuTroBLL chutroBLL = new ChuTroBLL();
        private string TenDangNhap;
        private string ChucVu;
        private int maUser;

        public TrangChuChuTro(int maUser, string tenDangNhap, string chucVu)
        {
            InitializeComponent();
            this.TenDangNhap = tenDangNhap;
            this.ChucVu = chucVu;
            this.maUser = maUser;
        }
        public TrangChuChuTro()
        {
            InitializeComponent();
        }

        private void TrangChuChuTro_Load(object sender, EventArgs e)
        {
            pnltrangchuchutro.BackColor = Color.LightSlateGray;
            btntimkiem.BackColor = Color.LightSkyBlue;    
            btncudan.BackColor = Color.LightSkyBlue;
            btnback.BackColor = Color.LightSkyBlue;
        }

        private void btncudan_Click(object sender, EventArgs e)
        {
            this.Close();
            Trangchucudan trangchucudan = new Trangchucudan(maUser,TenDangNhap, ChucVu);
            trangchucudan.ShowDialog();

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txttimkiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa)) // Kiểm tra nếu chưa nhập gì
            {
                MessageBox.Show("Hãy nhập thông tin để tìm kiếm.");
                return; // Dừng lại nếu chưa nhập gì
            }
            var ketQua = chutroBLL.TimKiemTheoTuKhoa1(tuKhoa);

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
