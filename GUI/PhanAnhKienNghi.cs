using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PhanAnhKienNghi : Form
    {
        private PhanAnhKienNghiBLL phananhkiennghiBLL = new PhanAnhKienNghiBLL();
        public PhanAnhKienNghi()
        {
            InitializeComponent();
        }

        private void PhanAnhKienNghi_Load(object sender, EventArgs e)
        {
            txttimkiemphananhkiennghi.ForeColor = Color.Gray;
            txttimkiemphananhkiennghi.Text = "Tìm kiếm theo mã đơn phản ánh kiến nghị";

            txttimkiemphananhkiennghi.Enter += Txttimkiemdonphananh_Enter;
            txttimkiemphananhkiennghi.Leave += Txttimkiemhokhaudonphananh_Leave;
            txtnoidung.Width = 200;      // chiều rộng
            txtnoidung.Height = 100;     // chiều cao (chỉ có tác dụng nếu Multiline = true)
            txtnoidung.Multiline = true; // cho phép TextBox hiển thị nhiều dòng (có thể chỉnh Height)
            txtnoidung.Font = new Font("Arial", 12); // chỉnh cỡ chữ
            pnlphananhkiennghi.BackColor = Color.LightSlateGray;
            btnthemphananhkiennghi.BackColor = Color.LightSlateGray;
            btnsuaphananhkiennghi.BackColor = Color.LightSlateGray;
            btnxoaphananhkiennghi.BackColor = Color.LightSlateGray;
            btnlammoiphananhkiennghi.BackColor = Color.LightSlateGray;
            btntimkiemphananhkiennghi.BackColor = Color.AliceBlue;
            grbphananhkiennghi.BackColor = Color.AliceBlue;
            grb3phananhkiennghi.BackColor = Color.AliceBlue;
            txtmaphananhkiennghi.ReadOnly = true;
            LoadData();
        }
        private void Txttimkiemdonphananh_Enter(object sender, EventArgs e)
        {
            if (txttimkiemphananhkiennghi.Text == "Tìm kiếm theo mã đơn phản ánh kiến nghị")
            {
                txttimkiemphananhkiennghi.Text = "";
                txttimkiemphananhkiennghi.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemhokhaudonphananh_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemphananhkiennghi.Text))
            {
                txttimkiemphananhkiennghi.Text = "Tìm kiếm theo mã đơn phản ánh kiến nghị";
                txttimkiemphananhkiennghi.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<PhanAnhKienNghiDTO> danhSach = phananhkiennghiBLL.LayDanhSachPhanAnh();
            dtvphananhkiennghi.DataSource = danhSach;
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
                TrangThai = txttrangthai.Text.Trim() // Có thể bỏ trống để nó set mặc định trong BLL
            };

            string ketQua = phananhkiennghiBLL.ThemPhanAnh(phanAnh);
            MessageBox.Show(ketQua);

            if (ketQua == "Thêm phản ánh thành công !.")
            {
                LoadData(); // load lại danh sách lên datagridview
            }
        }

        private void dtvphananhkiennghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvphananhkiennghi.Rows[e.RowIndex];

                txtmaphananhkiennghi.Text = row.Cells["MaPhanAnh"].Value?.ToString();
                txtmahokhau.Text = row.Cells["MaHoKhau"].Value?.ToString();
                txthoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtsodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtnoidung.Text = row.Cells["NoiDung"].Value?.ToString();

                if (row.Cells["NgayPhanAnh"].Value is DateTime ngayPA)
                    dtpngayphananh.Value = ngayPA;

                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
            }
        }

        private void btnsuaphananhkiennghi_Click(object sender, EventArgs e)
        {
            PhanAnhKienNghiDTO phanAnh = new PhanAnhKienNghiDTO
            {
                MaPhanAnh = Convert.ToInt32(txtmaphananhkiennghi.Text.Trim()),
                MaHoKhau = txtmahokhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                NoiDung = txtnoidung.Text.Trim(),
                NgayPhanAnh = dtpngayphananh.Value,
                TrangThai = txttrangthai.Text.Trim()
            };

            string ketQua = phananhkiennghiBLL.SuaPhanAnh(phanAnh);
            MessageBox.Show(ketQua);

            if (ketQua == "Sửa phản ánh thành công!")
            {
                LoadData(); // Refresh danh sách
            }
        }

        private void btnxoaphananhkiennghi_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtmaphananhkiennghi.Text, out int maPhanAnh))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phản ánh này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string ketQua = phananhkiennghiBLL.XoaPhanAnh(maPhanAnh);
                    MessageBox.Show(ketQua);
                    LoadData(); // cập nhật lại danh sách
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phản ánh cần xóa.");
            }
        }

        private void btntimkiemphananhkiennghi_Click(object sender, EventArgs e)
        {
            txttimkiemphananhkiennghi.Focus(); // Đảm bảo text mới nhất được cập nhật
            string TuKhoa3 = txttimkiemphananhkiennghi.Text.Trim();

            if (string.IsNullOrWhiteSpace(TuKhoa3))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = phananhkiennghiBLL.TimKiemDonPhanAnh(TuKhoa3);

            if (ketQua.Count > 0)
            {
                dtvphananhkiennghi.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoiphananhkiennghi_Click(object sender, EventArgs e)
        {
 
            txtmaphananhkiennghi.Text = ""; 
            txtmahokhau.Text = ""; 
            txthoten.Text = ""; 
            txtsodienthoai.Text = ""; 
            txtnoidung.Text = ""; 
            dtpngayphananh.Value = DateTime.Now; 
            txttrangthai.Text = ""; 


            dtvphananhkiennghi.DataSource = null;
            dtvphananhkiennghi.Rows.Clear();
            LoadData();
        }

        private void btnkhaosat_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhaoSat khaoSat = new KhaoSat();
            khaoSat.ShowDialog();
        }
    }
}
