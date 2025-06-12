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
    public partial class ThuPhiDongGop : Form
    {
        private ThuPhiDongGopBLL thuphidonggopbll = new ThuPhiDongGopBLL();
        public ThuPhiDongGop()
        {
            InitializeComponent();
        }

        private void ThuPhiDongGop_Load(object sender, EventArgs e)
        {
            dtvthuphidonggop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvthuphidonggop.MultiSelect = false;
            txttimkiemthuphidonggop.ForeColor = Color.Gray;
            txttimkiemthuphidonggop.Text = "Tìm kiếm theo mã ghi nhận";
            txttimkiemthuphidonggop.ForeColor = Color.Gray;

            txttimkiemthuphidonggop.Enter += Txttimkiemthuphi_Enter;
            txttimkiemthuphidonggop.Leave += Txttimkiemthuphi_Leave;
            pnl1thuphidonggop.BackColor = Color.SteelBlue;
            btnthemthuphidonggop.BackColor = Color.SteelBlue;
            btnsuathuphidonggop.BackColor = Color.SteelBlue;
            btnxuatdon.BackColor = Color.SteelBlue;
            btnxoathuphidonggop.BackColor = Color.SteelBlue;
            btntimkiemthuphidonggop.BackColor = Color.LightSalmon;
            btnlammoithuphidonggop.BackColor = Color.SteelBlue;
            grbgiaytamvang5.BackColor = Color.AliceBlue;
            grb3thuphidonggop.BackColor = Color.AliceBlue;
            LoadData();
        }
        private void Txttimkiemthuphi_Enter(object sender, EventArgs e)
        {
            if (txttimkiemthuphidonggop.Text == "Tìm kiếm theo mã ghi nhận")
            {
                txttimkiemthuphidonggop.Text = "";
                txttimkiemthuphidonggop.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemthuphi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemthuphidonggop.Text))
            {
                txttimkiemthuphidonggop.Text = "Tìm kiếm theo mã ghi nhận";
                txttimkiemthuphidonggop.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<ThuPhiDongGopDTO> danhSach = thuphidonggopbll.LayDanhSachThuPhi();
            dtvthuphidonggop.DataSource = danhSach;
        }
        private void btnthemthuphidonggop_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô nhập có bị bỏ trống không
            if (string.IsNullOrWhiteSpace(txtmathuphi.Text) ||
                string.IsNullOrWhiteSpace(txttenkhoanthu.Text) ||
                string.IsNullOrWhiteSpace(txtsotien.Text) ||
                string.IsNullOrWhiteSpace(txtlydothu.Text) ||
                string.IsNullOrWhiteSpace(txttrangthai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal soTien;
            if (!decimal.TryParse(txtsotien.Text.Trim(), out soTien))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số tiền!");
                return;
            }
            ThuPhiDongGopDTO dto = new ThuPhiDongGopDTO
            {
                MaThuPhi = txtmathuphi.Text.Trim(),
                TenKhoanThu = txttenkhoanthu.Text.Trim(),
                SoTien = soTien,
                HanDong = dtphandong.Value,
                LyDoThu = txtlydothu.Text.Trim(),
                TrangThai = txttrangthai.Text
            };
            string kq = thuphidonggopbll.ThemThuPhi(dto);
            MessageBox.Show(kq);

            if (kq == "Thêm Khoản Thu Thành Công !.")
            {
                LoadData();
            }
        }
        private void dtvthuphidonggop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvthuphidonggop.Rows[e.RowIndex];

                txtmathuphi.Text = row.Cells["MaThuPhi"].Value?.ToString();
                txttenkhoanthu.Text = row.Cells["TenKhoanThu"].Value?.ToString();
                txtsotien.Text = row.Cells["SoTien"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["HanDong"].Value?.ToString(), out DateTime ngayHanDong))
                {
                    dtphandong.Value = ngayHanDong;
                }

                txtlydothu.Text = row.Cells["LyDoThu"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmathuphi.ReadOnly = true;
            }
        }
        private void btnsuathuphidonggop_Click(object sender, EventArgs e)
        {
            if (
        string.IsNullOrWhiteSpace(txttenkhoanthu.Text) ||
        string.IsNullOrWhiteSpace(txtsotien.Text) ||
        string.IsNullOrWhiteSpace(txtlydothu.Text) ||
        string.IsNullOrWhiteSpace(txttrangthai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi sửa!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtsotien.Text.Trim(), out decimal soTien))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số tiền!");
                return;
            }
            ThuPhiDongGopDTO dto = new ThuPhiDongGopDTO
            {
                MaThuPhi = txtmathuphi.Text.Trim(),
                TenKhoanThu = txttenkhoanthu.Text.Trim(),
                SoTien = soTien,
                HanDong = dtphandong.Value,
                LyDoThu = txtlydothu.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };
            string kq = thuphidonggopbll.SuaThuPhi(dto);
            MessageBox.Show(kq);

            if (kq == "Sửa Khoản Thu Thành Công!")
            {
                LoadData();
            }
        }

        private void btnxoathuphidonggop_Click(object sender, EventArgs e)
        {
            string maThuPhiDongGop = txtmathuphi.Text.Trim();

            if (string.IsNullOrWhiteSpace(maThuPhiDongGop))
            {
                MessageBox.Show("Vui lòng chọn khoản thu cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khoản thu có mã [{maThuPhiDongGop}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = thuphidonggopbll.XoaThuPhiDongGop(maThuPhiDongGop);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa khoản thu thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btntimkiemthuphidonggop_Click(object sender, EventArgs e)
        {

            txttimkiemthuphidonggop.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaThuPhi = txttimkiemthuphidonggop.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaThuPhi))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = thuphidonggopbll.TimKiemThuPhi(MaThuPhi);

            if (ketQua.Count > 0)
            {
                dtvthuphidonggop.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnxuatdon_Click(object sender, EventArgs e)
        {
            if (dtvthuphidonggop.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtvthuphidonggop.SelectedRows[0];

                string tenKhoanThu = row.Cells["TenKhoanThu"].Value.ToString();
                string hanDong = Convert.ToDateTime(row.Cells["HanDong"].Value).ToString("dd/MM/yyyy");
                string soTien = Convert.ToDecimal(row.Cells["SoTien"].Value).ToString("N0") + " VNĐ";
                string lyDo = row.Cells["LyDoThu"].Value.ToString();

                // Gọi form đơn thu phí với các thông tin
                DonThuPhiDongGop formDon = new DonThuPhiDongGop(tenKhoanThu, hanDong, soTien, lyDo);
                formDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xuất đơn.");
            }
        }

        private void btnlammoithuphidonggop_Click(object sender, EventArgs e)
        {
            txtmathuphi.Text = "";
            txttenkhoanthu.Text = "";
            txtsotien.Text = "";
            dtphandong.Value = DateTime.Now; // Reset ngày về hôm nay, bạn có thể thay đổi nếu cần
            txtlydothu.Text = "";
            txttrangthai.Text = "";
            txtmathuphi.ReadOnly = false;

            // Nếu có DataGridView thu phí
            dtvthuphidonggop.DataSource = null;
            dtvthuphidonggop.Rows.Clear();
            LoadData();
        }
    }
}
