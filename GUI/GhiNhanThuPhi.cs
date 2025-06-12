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
    public partial class GhiNhanThuPhi : Form
    {
        private GhiNhanDongGopBLL ghinhandonggopbll = new GhiNhanDongGopBLL();
        public GhiNhanThuPhi()
        {
            InitializeComponent();
        }
        private void GhiNhanThuPhi_Load(object sender, EventArgs e)
        {
            txttimkiemghinhathuphi.ForeColor = Color.Gray;
            txttimkiemghinhathuphi.Text = "Tìm kiếm theo mã ghi nhận";

            txttimkiemghinhathuphi.Enter += Txttimkiemhodadongtien_Enter;
            txttimkiemghinhathuphi.Leave += Txttimkiemhodadongtien_Leave;
            pnl1thuphidonggop.BackColor = Color.LightSlateGray;
            grb3ghinhathuphi.BackColor = Color.AliceBlue;
            grbghinhathuphi.BackColor = Color.AliceBlue;
            btnthemghinhathuphi.BackColor= Color.LightSkyBlue;
            btnsuaghinhathuphi.BackColor = Color.LightSkyBlue;
            btnxoaghinhathuphi.BackColor = Color.LightSkyBlue;
            btnlammoighinhathuphi.BackColor = Color.LightSkyBlue;
            btntimkiemghinhathuphi.BackColor = Color.LightSkyBlue;
            LoadData();
        }
        private void Txttimkiemhodadongtien_Enter(object sender, EventArgs e)
        {
            if (txttimkiemghinhathuphi.Text == "Tìm kiếm theo mã ghi nhận")
            {
                txttimkiemghinhathuphi.Text = "";
                txttimkiemghinhathuphi.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemhodadongtien_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemghinhathuphi.Text))
            {
                txttimkiemghinhathuphi.Text = "Tìm kiếm theo mã ghi nhận";
                txttimkiemghinhathuphi.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<GhiNhanDongGopDTO> danhSach = ghinhandonggopbll.LayDanhSachGhiNhan();
            dtvghinhathuphi.DataSource = danhSach;
        }
        private void btnthemghinhathuphi_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(txtmaghinhan.Text) ||
                string.IsNullOrWhiteSpace(txtmahokhau.Text) ||
                string.IsNullOrWhiteSpace(txtmathuphi.Text) ||
                 string.IsNullOrWhiteSpace(txttennguoidong.Text) ||
                string.IsNullOrWhiteSpace(txtsotiendong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng số tiền
            if (!decimal.TryParse(txtsotiendong.Text.Trim(), out decimal soTienDong))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số tiền phải là số ! ", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GhiNhanDongGopDTO ghiNhan = new GhiNhanDongGopDTO
            {
                MaGhiNhan = txtmaghinhan.Text.Trim(),
                MaHoKhau = txtmahokhau.Text.Trim(),
                MaThuPhi = txtmathuphi.Text.Trim(),
                TenNguoiDong = txttennguoidong.Text.Trim(),
                NgayDong = dtpngaydong.Value,
                SoTienDong = decimal.Parse(txtsotiendong.Text.Trim()),
                GhiChu = txtghichu.Text.Trim()
            };

            string thongBao = ghinhandonggopbll.ThemGhiNhan(ghiNhan);
            MessageBox.Show(thongBao);

            if (thongBao == "Thêm hộ đã thu thành công !.")
            {
                LoadData();
            }
        }
        private void dtvghinhathuphi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvghinhathuphi.Rows[e.RowIndex];

                txtmaghinhan.Text = row.Cells["MaGhiNhan"].Value?.ToString();
                txtmahokhau.Text = row.Cells["MaHoKhau"].Value?.ToString();
                txtmathuphi.Text = row.Cells["MaThuPhi"].Value?.ToString();
                txttennguoidong.Text = row.Cells["TenNguoiDong"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayDong"].Value?.ToString(), out DateTime ngayDong))
                {
                    dtpngaydong.Value = ngayDong;
                }

                txtsotiendong.Text = row.Cells["SoTienDong"].Value?.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value?.ToString();
                txtmaghinhan.ReadOnly = true;
            }
        }

        private void btnsuaghinhathuphi_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu rỗng
            if (
                string.IsNullOrWhiteSpace(txtmahokhau.Text) ||
                string.IsNullOrWhiteSpace(txtmathuphi.Text) ||
                string.IsNullOrWhiteSpace(txttennguoidong.Text) ||
                string.IsNullOrWhiteSpace(txtsotiendong.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra định dạng số tiền
            if (!decimal.TryParse(txtsotiendong.Text.Trim(), out decimal soTienDong))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số tiền!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Tạo đối tượng DTO
            GhiNhanDongGopDTO ghiNhan = new GhiNhanDongGopDTO
            {
                MaGhiNhan = txtmaghinhan.Text.Trim(),
                MaHoKhau = txtmahokhau.Text.Trim(),
                MaThuPhi = txtmathuphi.Text.Trim(),
                TenNguoiDong = txttennguoidong.Text.Trim(),
                NgayDong = dtpngaydong.Value,
                SoTienDong = soTienDong,
                GhiChu = txtghichu.Text.Trim()
            };

            // 4. Gọi BLL để sửa
            string thongBao = ghinhandonggopbll.SuaGhiNhan(ghiNhan);
            MessageBox.Show(thongBao);

            if (thongBao == "Sửa ghi nhận đóng góp thành công !")
            {
                LoadData();
            }
        }

        private void btnxoaghinhathuphi_Click(object sender, EventArgs e)
        {
            string maGhiNhan = txtmaghinhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(maGhiNhan))
            {
                MessageBox.Show("Vui lòng chọn hộ đã đóng cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hộ đã đóng có mã [{maGhiNhan}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = ghinhandonggopbll.XoaGhiNhanDongGop(maGhiNhan);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa hộ đã đóng thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btntimkiemghinhathuphi_Click(object sender, EventArgs e)
        {
            txttimkiemghinhathuphi.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaGhiNhan = txttimkiemghinhathuphi.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaGhiNhan))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = ghinhandonggopbll.TimKiemHoDaDongTien(MaGhiNhan);

            if (ketQua.Count > 0)
            {
                dtvghinhathuphi.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoighinhathuphi_Click(object sender, EventArgs e)
        {
            txtmaghinhan.Text = "";
            txtmahokhau.Text = "";
            txtmathuphi.Text = "";
            txttennguoidong.Text = "";
            dtpngaydong.Value = DateTime.Now; // Reset về ngày hiện tại
            txtsotiendong.Text = "";
            txtghichu.Text = "";
            txtmaghinhan.ReadOnly = false;

            // Nếu có DataGridView ghi nhận thu phí
            dtvghinhathuphi.DataSource = null;
            dtvghinhathuphi.Rows.Clear();
            LoadData();
        }
    }
}
