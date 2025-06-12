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
    public partial class SinhHoatCuocHop : Form
    {
        private SinhHoatCuocHopBLL sinhhoatcuochopbll = new SinhHoatCuocHopBLL();
        public SinhHoatCuocHop()
        {
            InitializeComponent();
        }

        private void SinhHoatCuocHop_Load(object sender, EventArgs e)
        {
            dtvcuochop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvcuochop.MultiSelect = false;
            txttimkiemcuochop.ForeColor = Color.Gray;
            txttimkiemcuochop.Text = "Tìm kiếm theo mã sinh hoạt cuộc họp";

            txttimkiemcuochop.Enter += Txttimkiemsinhhoatcuochop_Enter;
            txttimkiemcuochop.Leave += Txttimkiemsinhhoatcuochop_Leave;
            txtnoidung.Width = 200;      // chiều rộng
                txtnoidung.Height = 100;     // chiều cao (chỉ có tác dụng nếu Multiline = true)
                txtnoidung.Multiline = true; // cho phép TextBox hiển thị nhiều dòng (có thể chỉnh Height)
                txtnoidung.Font = new Font("Arial", 12); // chỉnh cỡ chữ
                pnlcuochop.BackColor = Color.LightPink;
                btntimkiemcuochop.BackColor = Color.LightBlue;
                btnsuacuochop.BackColor = Color.LightPink;
                btnxoacuochop.BackColor = Color.LightPink;
                btnlammoicuochop.BackColor = Color.LightPink;
                btnback1cuochop.BackColor = Color.LightPink;
                btnthemcuochop.BackColor = Color.LightPink;
                grbthongtinkhutro.BackColor = Color.AliceBlue;
                btnxuatdoncuochop.BackColor = Color.LightPink;
                grb3cuochop.BackColor = Color.AliceBlue;
            LoadData();
        }
        private void Txttimkiemsinhhoatcuochop_Enter(object sender, EventArgs e)
        {
            if (txttimkiemcuochop.Text == "Tìm kiếm theo mã sinh hoạt cuộc họp")
            {
                txttimkiemcuochop.Text = "";
                txttimkiemcuochop.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemsinhhoatcuochop_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemcuochop.Text))
            {
                txttimkiemcuochop.Text = "Tìm kiếm theo mã sinh hoạt cuộc họp";
                txttimkiemcuochop.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<SinhHoatCuocHopDTO> danhSach = sinhhoatcuochopbll.LayDanhSachSinhHoat();
            dtvcuochop.DataSource = danhSach;
        }

        private void btnthemcuochop_Click(object sender, EventArgs e)
        {
            SinhHoatCuocHopDTO sh = new SinhHoatCuocHopDTO
            {
                MaSinhHoat = txtmasinhhoat.Text.Trim(),
                TenSinhHoat = txttenbuoisinhhoat.Text.Trim(),
                NgayToChuc = dtpngaytochuc.Value,
                DiaDiem = txtdiadiem.Text.Trim(),
                NoiDung = txtnoidung.Text.Trim(),
                MoTa = txtmota.Text.Trim(),
                NguoiToChuc = txtnguoitochuc.Text.Trim(),
                SoDienThoaiNguoiToChuc = txtsodienthoainguoitao.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };

            string ketQua = sinhhoatcuochopbll.ThemSinhHoat(sh);
            MessageBox.Show(ketQua);

            if (ketQua == "Thêm Buổi Sinh Hoạt , Cuộc Họp Thành Công !.")
            {
                LoadData(); // reload lại bảng
            }
        }


        private void btnback1cuochop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvcuochop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvcuochop.Rows[e.RowIndex];

                txtmasinhhoat.Text = row.Cells["MaSinhHoat"].Value?.ToString();
                txttenbuoisinhhoat.Text = row.Cells["TenSinhHoat"].Value?.ToString();

                DateTime.TryParse(row.Cells["NgayToChuc"].Value?.ToString(), out DateTime ngayToChuc);
                dtpngaytochuc.Value = ngayToChuc;

                txtdiadiem.Text = row.Cells["DiaDiem"].Value?.ToString();
                txtnoidung.Text = row.Cells["NoiDung"].Value?.ToString();
                txtmota.Text = row.Cells["MoTa"].Value?.ToString();
                txtnguoitochuc.Text = row.Cells["NguoiToChuc"].Value?.ToString();
                txtsodienthoainguoitao.Text = row.Cells["SoDienThoaiNguoiToChuc"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmasinhhoat.ReadOnly = true;
            }
        }

        private void btnsuacuochop_Click(object sender, EventArgs e)
        {
            SinhHoatCuocHopDTO sh = new SinhHoatCuocHopDTO
            {
                MaSinhHoat = txtmasinhhoat.Text.Trim(),
                TenSinhHoat = txttenbuoisinhhoat.Text.Trim(),
                NgayToChuc = dtpngaytochuc.Value,
                DiaDiem = txtdiadiem.Text.Trim(),
                NoiDung = txtnoidung.Text.Trim(),
                MoTa = txtmota.Text.Trim(),
                NguoiToChuc = txtnguoitochuc.Text.Trim(),
                SoDienThoaiNguoiToChuc = txtsodienthoainguoitao.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };

            string ketQua = sinhhoatcuochopbll.SuaSinhHoat(sh);
            MessageBox.Show(ketQua);

            if (ketQua == "Sửa buổi sinh hoạt thành công!")
            {
                LoadData();
            }
        }

        private void btnxoacuochop_Click(object sender, EventArgs e)
        {
            string maSinhHoatCuocHop = txtmasinhhoat.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSinhHoatCuocHop))
            {
                MessageBox.Show("Vui lòng chọn cuộc họp cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa cuộc họp có mã [{maSinhHoatCuocHop}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = sinhhoatcuochopbll.XoaSinhHoatCuocHop(maSinhHoatCuocHop);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa cuộc họp thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btntimkiemcuochop_Click(object sender, EventArgs e)
        {
            txttimkiemcuochop.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaSinhHoat = txttimkiemcuochop.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaSinhHoat))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = sinhhoatcuochopbll.TimKiemSinhHoat(MaSinhHoat);

            if (ketQua.Count > 0)
            {
                dtvcuochop.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnxuatdoncuochop_Click(object sender, EventArgs e)
        {
            if (dtvcuochop.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một buổi cuộc họp.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dtvcuochop.SelectedRows[0];
            // Lấy dữ liệu từ cột theo tên bạn đặt trong DataGridView
            string tenBuoi = row.Cells["TenSinhHoat"].Value.ToString();
            string ngayToChuc = Convert.ToDateTime(row.Cells["NgayToChuc"].Value)
                                     .ToString("dd/MM/yyyy");
            string diaDiem = row.Cells["DiaDiem"].Value.ToString();
            string noiDung = row.Cells["NoiDung"].Value.ToString();
            string moTa = row.Cells["MoTa"].Value.ToString();
            string nguoiToChuc = row.Cells["NguoiToChuc"].Value.ToString();
            string soDienThoai = row.Cells["SoDienThoaiNguoiToChuc"].Value.ToString();
            string trangThai = row.Cells["TrangThai"].Value.ToString();

            // Khởi tạo Form mời tham dự, truyền dữ liệu vào constructor
            var frm = new DonSinhHoatCuocHop(
                tenBuoi, ngayToChuc, diaDiem, noiDung,
                moTa, nguoiToChuc, soDienThoai, trangThai
            );
            frm.ShowDialog();
        }

        private void btnlammoicuochop_Click(object sender, EventArgs e)
        {
            txtmasinhhoat.Text = "";
            txttenbuoisinhhoat.Text = "";
            dtpngaytochuc.Value = DateTime.Now;
            txtdiadiem.Text = "";
            txtnoidung.Text = "";
            txtmota.Text = "";
            txtnguoitochuc.Text = "";
            txtsodienthoainguoitao.Text = "";
            txttrangthai.Text = "";
            txtmasinhhoat.ReadOnly = false;

            // Nếu có DataGridView sinh hoạt
            dtvcuochop.DataSource = null;
            dtvcuochop.Rows.Clear();
            LoadData();
        }
    }
}

