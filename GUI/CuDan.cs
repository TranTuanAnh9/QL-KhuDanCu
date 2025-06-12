using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class Trangchucudan : Form
    {
        CuDanBLL cuDanBLL = new CuDanBLL();
        private KhaoSatBLL khaoSatBLL = new KhaoSatBLL();
        private ThongBaoBLL thongBaoBLL = new ThongBaoBLL();
        // Thêm biến lưu TenDangNhap và ChucVu
        private string TenDangNhap;
        private string ChucVu;
        private int maUser;

        // Tạo constructor có tham số để truyền TenDangNhap và ChucVu từ form khác

        public Trangchucudan(int maUser , string tenDangNhap, string chucVu)
        {
            InitializeComponent();
            TenDangNhap = tenDangNhap;
            ChucVu = chucVu;
            this.maUser = maUser;
        }
        public Trangchucudan()
        {
            InitializeComponent();
        }

        private void Trangchucudan_Load(object sender, EventArgs e)
        {
            pnlcudan.BackColor = Color.AliceBlue;
            btntimkiem.BackColor = Color.LightSkyBlue;
            btnbaiviet.BackColor = Color.LightSkyBlue;
            btnback.BackColor = Color.LightSkyBlue;
            // Lấy MaUser hiện tại
            int maUser = CurrentUser.MaUser;

            int soKhaoSatChuaLam = khaoSatBLL.DemSoKhaoSatChuaLam(maUser);

            // Hiển thị số lên label (label ở góc button Thông báo)
            if (soKhaoSatChuaLam > 0)
            {
                lblThongBaoSoLuong.Text = soKhaoSatChuaLam.ToString();
                lblThongBaoSoLuong.Visible = true;
                lblThongBaoSoLuong.ForeColor = Color.Red;  // màu đỏ
            }
            else
            {
                lblThongBaoSoLuong.Visible = false;
            }
            CapNhatSoLuongKhaoSatChuaLam();
            CapNhatSoLuongThongBaoChuaDoc();
        }

        private void btnbaiviet_Click(object sender, EventArgs e)
        {
            CuDanPhanAnhKienNghi cuDanPhanAnhKienNghi = new CuDanPhanAnhKienNghi(TenDangNhap, ChucVu);
            cuDanPhanAnhKienNghi.Show();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
            TrangChuChuTro trangChuChuTro = new TrangChuChuTro();
            trangChuChuTro.Show();
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txttimkiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa)) // Kiểm tra nếu chưa nhập gì
              {
                 MessageBox.Show("Hãy nhập thông tin để tìm kiếm.");
                 return; // Dừng lại nếu chưa nhập gì
              }
            var ketQua = cuDanBLL.TimKiemTheoTuKhoa(tuKhoa);

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

            dgvnhankhau.Visible = true;
            dgvhokhau.Visible = true;
            dataGridView1.Visible = true;

            switch (ketQua.LoaiKetQua)
            {
                case "NhanKhau":
                    dgvnhankhau.DataSource = ketQua.DuLieu;
                    dgvnhankhau.Visible = true;
                    break;

                case "HoKhau":
                    dgvhokhau.DataSource = ketQua.DuLieu;
                    dgvhokhau.Visible = true;
                    break;

                case "GiayTamVang":
                    dataGridView1.DataSource = ketQua.DuLieu;
                    dataGridView1.Visible = true;
                    break;
            }
        }
        public void CapNhatSoLuongKhaoSatChuaLam()
        {
            int soKhaoSatChuaLam = khaoSatBLL.DemSoKhaoSatChuaLam(maUser);

            if (soKhaoSatChuaLam > 0)
            {
                lblThongBaoSoLuong.Text = soKhaoSatChuaLam.ToString();
                lblThongBaoSoLuong.Visible = true;
            }
            else
            {
                lblThongBaoSoLuong.Visible = false;
            }
        }
        private void btnthongbao_Click(object sender, EventArgs e)
        {
            ChonBaiKhaoSat chonBaiKhaoSat = new ChonBaiKhaoSat(this.maUser);
            chonBaiKhaoSat.Owner = this; 
            chonBaiKhaoSat.ShowDialog();
        }
        private void CapNhatSoLuongThongBaoChuaDoc()
        {
            int soThongBaoChuaDoc = thongBaoBLL.DemThongBaoChuaDoc(TenDangNhap);

            if (soThongBaoChuaDoc > 0)
            {
                lbltinnhan.Text = soThongBaoChuaDoc.ToString();
                lbltinnhan.Visible = true;
                lbltinnhan.ForeColor = Color.Red;
            }
            else
            {
                lbltinnhan.Visible = false;
            }
        }

        private void btntinnhan_Click(object sender, EventArgs e)
        {
            ChonTinNhan chonTinNhan = new ChonTinNhan(this.TenDangNhap);
            chonTinNhan.Owner = this;
            chonTinNhan.ShowDialog();
        }
    }
}
