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
    public partial class CuDanPhanAnhKienNghi : Form
    {
        private PhanAnhKienNghiBLL phananhBLL = new PhanAnhKienNghiBLL();
        // Thêm biến lưu TenDangNhap và ChucVu
        private string TenDangNhap;
        private string ChucVu;

        // Tạo constructor có tham số để truyền TenDangNhap và ChucVu từ form khác
        public CuDanPhanAnhKienNghi(string tenDangNhap, string chucVu)
        {
            InitializeComponent();
            TenDangNhap = tenDangNhap;
            ChucVu = chucVu;
        }
        public CuDanPhanAnhKienNghi()
        {
            InitializeComponent();
        }

        private void CuDanPhanAnhKienNghi_Load(object sender, EventArgs e)
        {
            txtnoidung.Width = 200;      // chiều rộng
            txtnoidung.Height = 100;     // chiều cao (chỉ có tác dụng nếu Multiline = true)
            txtnoidung.Multiline = true; // cho phép TextBox hiển thị nhiều dòng (có thể chỉnh Height)
            txtnoidung.Font = new Font("Arial", 12); // chỉnh cỡ chữ
            pnlphananhkiennghi.BackColor = Color.LightSlateGray;
            grbphananhkiennghi.BackColor = Color.AliceBlue;
            btnthemphananhkiennghi.BackColor = Color.LightSkyBlue;
            btntimkiemphananhkiennghi.BackColor = Color.LightSkyBlue;
            LoadData();
        }
        private void LoadData()
        {
            List<PhanAnhKienNghiDTO> danhSach = phananhBLL.LayDanhSachPhanAnh();

            // Chỉ chọn 3 cột: HoTen, NgayPhanAnh, NoiDung
            var dataHienThi = danhSach.Select(p => new
            {
                HoTen = p.HoTen,
                NgayPhanAnh = p.NgayPhanAnh.ToString("dd/MM/yyyy"),
                NoiDung = p.NoiDung,
                TrangThai = p.TrangThai
            }).ToList();

            dtvphananhkiennghi.DataSource = dataHienThi;

            // Tuỳ chọn: đổi header cho đẹp
            dtvphananhkiennghi.Columns[0].HeaderText = "Họ tên";
            dtvphananhkiennghi.Columns[1].HeaderText = "Ngày phản ánh";
            dtvphananhkiennghi.Columns[2].HeaderText = "Nội dung";
            dtvphananhkiennghi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dtvphananhkiennghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtvphananhkiennghi.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dtvphananhkiennghi.Rows[e.RowIndex];
                txthoten.Text = row.Cells[0].Value.ToString();
                dtpngayphananh.Value = DateTime.ParseExact(row.Cells[1].Value.ToString(), "dd/MM/yyyy", null);
                txtnoidung.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btntimkiemphananhkiennghi_Click(object sender, EventArgs e)
        {
            txttimkiemphananhkiennghi.Focus(); // Đảm bảo text mới nhất được cập nhật
            string TuKhoa = txttimkiemphananhkiennghi.Text.Trim();

            if (string.IsNullOrWhiteSpace(TuKhoa))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = phananhBLL.TimKiemDonPhanAnh(TuKhoa);

            LichsuhoatdongDTO lichSu = new LichsuhoatdongDTO
            {
                TenDangNhap = TenDangNhap,
                ChucVu = ChucVu,
                HanhDong = "Tìm kiếm thông tin",
                NoiDung = $"Tìm kiếm với từ khóa: {TuKhoa}",
                ThoiGian = DateTime.Now
            };
            LichsuhoatdongBLL lichSuBLL = new LichsuhoatdongBLL();
            lichSuBLL.ThemLichSuHoatDong(lichSu);

            if (ketQua.Count > 0)
            {
                var dataHienThi = ketQua.Select(p => new
                {
                    HoTen = p.HoTen,
                    NoiDung = p.NoiDung,
                    TrangThai = p.TrangThai,
                    NgayPhanAnh = p.NgayPhanAnh.ToString("dd/MM/yyyy")

                }).ToList();

                dtvphananhkiennghi.DataSource = dataHienThi;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }
        private void btnthemphananhkiennghi_Click(object sender, EventArgs e)
        {
            PhanAnhKienNghiDTO phanAnh = new PhanAnhKienNghiDTO
            {
                MaHoKhau = txtmahokhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                NoiDung = txtnoidung.Text.Trim(),
                NgayPhanAnh = dtpngayphananh.Value,
            };

            string ketQua = phananhBLL.ThemPhanAnh(phanAnh);

            MessageBox.Show(ketQua);

            if (ketQua == "Thêm phản ánh thành công !.")
            {
                LoadData(); // load lại danh sách lên datagridview

                // Lưu lịch sử thêm phản ánh
                LichsuhoatdongDTO lichSu = new LichsuhoatdongDTO
                {
                    TenDangNhap = TenDangNhap,
                    ChucVu = ChucVu,
                    HanhDong = "Thêm phản ánh kiến nghị",
                    NoiDung = $"Phản ánh kiến nghị của: {phanAnh.MaHoKhau}, Họ tên: {phanAnh.HoTen}",
                    ThoiGian = DateTime.Now
                };
                LichsuhoatdongBLL lichSuBLL = new LichsuhoatdongBLL();
                lichSuBLL.ThemLichSuHoatDong(lichSu);
            }
        }
        private void CuDanPhanAnhKienNghi_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Bạn có chắc chắn muốn thoát ứng dụng không?",
       "Xác nhận thoát",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question
   );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy sự kiện đóng form
            }
        }
    }
}
