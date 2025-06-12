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
    public partial class GhiNhanThamGia : Form
    {
        private GhiNhanThamGiaBLL ghinhanthamgiabll = new GhiNhanThamGiaBLL();
        public GhiNhanThamGia()
        {
            InitializeComponent();
        }

        private void GhiNhanThamGia_Load(object sender, EventArgs e)
        {
            txttimkiemghinhathamgia.ForeColor = Color.Gray;
            txttimkiemghinhathamgia.Text = "Tìm kiếm theo mã ghi nhận";
            txttimkiemghinhathamgia.ForeColor = Color.Gray;

            txttimkiemghinhathamgia.Enter += Txttimkiemhodathamgia_Enter;
            txttimkiemghinhathamgia.Leave += Txttimkiemhodathamgia_Leave;
            pnl1ghinhanthamgia.BackColor = Color.LightSkyBlue;
            grb3ghinhanthamgia.BackColor = Color.LightSkyBlue;
            grbghinhanthamgia.BackColor = Color.AliceBlue;
            btnthemghinhanthamgia.BackColor = Color.LightGoldenrodYellow;
            btnsuaghinhanthamgia.BackColor = Color.LightGoldenrodYellow;
            btnxoaghinhanthamgia.BackColor = Color.LightGoldenrodYellow;
            btnlammoighinhanthamgia.BackColor = Color.LightGoldenrodYellow;
           btntimkiemghinhanthamgia.BackColor = Color.LightGoldenrodYellow;
            grb3ghinhanthamgia.BackColor= Color.AliceBlue;
            LoadData();

        }
        private void Txttimkiemhodathamgia_Enter(object sender, EventArgs e)
        {
            if (txttimkiemghinhathamgia.Text == "Tìm kiếm theo mã ghi nhận")
            {
                txttimkiemghinhathamgia.Text = "";
                txttimkiemghinhathamgia.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemhodathamgia_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemghinhathamgia.Text))
            {
                txttimkiemghinhathamgia.Text = "Tìm kiếm theo mã ghi nhận";
                txttimkiemghinhathamgia.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<GhiNhanThamGiaDTO> danhSach = ghinhanthamgiabll.LayDanhSachGhiNhan();
            dtvghinhanthamgia.DataSource = danhSach;
        }

        private void btnthemghinhanthamgia_Click(object sender, EventArgs e)
        {
            GhiNhanThamGiaDTO ghiNhan = new GhiNhanThamGiaDTO
            {
                MaGhiNhan = txtmaghinhan.Text.Trim(),
                MaHoKhau = txtmahokhau.Text.Trim(),
                MaSinhHoat = txtmasinhhoat.Text.Trim(),
                TenBuoiSinhHoat = txttenbuoisinhhoat.Text.Trim(),
                TenNguoiThamGia = txttennguoithamgia.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                GhiChu = txtghichu.Text.Trim()
            };

            string thongBao = ghinhanthamgiabll.ThemGhiNhan(ghiNhan);
            MessageBox.Show(thongBao);

            if (thongBao == "Thêm Hộ Đã Tham Gia Thành Công !.")
            {
                LoadData();
            }
        }

        private void dtvghinhanthamgia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvghinhanthamgia.Rows[e.RowIndex];

                txtmaghinhan.Text = row.Cells["MaGhiNhan"].Value?.ToString();
                txtmahokhau.Text = row.Cells["MaHoKhau"].Value?.ToString();
                txtmasinhhoat.Text = row.Cells["MaSinhHoat"].Value?.ToString();
                txttenbuoisinhhoat.Text = row.Cells["TenBuoiSinhHoat"].Value?.ToString();
                txttennguoithamgia.Text = row.Cells["TenNguoiThamGia"].Value?.ToString();
                txtsodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value?.ToString();
                txtmaghinhan.ReadOnly = true;
            }
        }

        private void btnsuaghinhanthamgia_Click(object sender, EventArgs e)
        {
            GhiNhanThamGiaDTO ghiNhan = new GhiNhanThamGiaDTO
            {
                MaGhiNhan = txtmaghinhan.Text.Trim(),
                MaHoKhau = txtmahokhau.Text.Trim(),
                MaSinhHoat = txtmasinhhoat.Text.Trim(),
                TenBuoiSinhHoat = txttenbuoisinhhoat.Text.Trim(),
                TenNguoiThamGia = txttennguoithamgia.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                GhiChu = txtghichu.Text.Trim()
            };

            string thongBao = ghinhanthamgiabll.SuaGhiNhan(ghiNhan);
            MessageBox.Show(thongBao);

            if (thongBao == "Cập nhật thông tin thành công!")
            {
                LoadData();
            }
        }

        private void btnxoaghinhanthamgia_Click(object sender, EventArgs e)
        {
            string maGhiNhan = txtmaghinhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(maGhiNhan))
            {
                MessageBox.Show("Vui lòng chọn hộ đã tham gia cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hộ đã tham gia có mã [{maGhiNhan}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = ghinhanthamgiabll.XoaGhiNhaThamGia(maGhiNhan);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa hộ đã tham gia thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void grb3ghinhanthamgia_Enter(object sender, EventArgs e)
        {

        }

        private void btntimkiemghinhanthamgia_Click(object sender, EventArgs e)
        {
            txttimkiemghinhathamgia.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaGhiNhan = txttimkiemghinhathamgia.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaGhiNhan))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }
            var ketQua = ghinhanthamgiabll.TimKiemHoDaThamGia(MaGhiNhan);

            if (ketQua.Count > 0)
            {
                dtvghinhanthamgia.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoighinhanthamgia_Click(object sender, EventArgs e)
        {
            txtmaghinhan.Text = "";
            txtmahokhau.Text = "";
            txtmasinhhoat.Text = "";
            txttenbuoisinhhoat.Text = "";
            txttennguoithamgia.Text = "";
            txtsodienthoai.Text = "";
            txtghichu.Text = "";
            txtmaghinhan.ReadOnly = false;

            // Nếu có DataGridView ghi nhận tham gia
            dtvghinhanthamgia.DataSource = null;
            dtvghinhanthamgia.Rows.Clear();
            LoadData();
        }
    }
}
