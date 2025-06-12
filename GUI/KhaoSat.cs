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
    public partial class KhaoSat : Form
    {
        private KhaoSatBLL ksBLL = new KhaoSatBLL();
        private int maKhaoSat = 0;
        public KhaoSat()
        {
            InitializeComponent();
        }

        private void KhaoSat_Load(object sender, EventArgs e)
        {
            LoadKhaoSat();
            panel2.BackColor = Color.PaleTurquoise;
            btnthemkhaosat.BackColor = Color.WhiteSmoke;
            btnsua.BackColor = Color.WhiteSmoke;
            btnxoa.BackColor = Color.WhiteSmoke;
            btnlammoi.BackColor = Color.WhiteSmoke;
            btnback.BackColor = Color.WhiteSmoke;
            btntaocauhoi.BackColor = Color.RoyalBlue;
            btndangbai.BackColor = Color.PapayaWhip;
            // Cấu hình hiển thị đẹp
            dgvkhaosat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvkhaosat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvkhaosat.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvkhaosat.RowTemplate.Height = 30; // tùy chỉnh nếu cần
            txtmakhaosat.ReadOnly = true;
            txttrangthai.ReadOnly = true;

        }
        private void LoadKhaoSat()
        {
            dgvkhaosat.DataSource = ksBLL.LayDanhSachKhaoSat();
        }

        private void btnthemkhaosat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttieude.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề.");
                return;
            }

            // Gán sẵn trạng thái "Đang thử nghiệm" cho textbox (nếu muốn hiển thị)
            txttrangthai.Text = "Đang thử nghiệm";

            KhaoSatDTO ks = new KhaoSatDTO
            {
                TieuDe = txttieude.Text,
                NgayTao = dtpngaytao.Value,
                TrangThai = "Đang thử nghiệm"  // Luôn gán cứng
            };

            int maMoi = ksBLL.ThemKhaoSat(ks);

            if (maMoi > 0)
            {
                MessageBox.Show("Thêm khảo sát thành công. Mã: " + maMoi);
                LoadKhaoSat();
                txttieude.Clear();
                txttrangthai.Text = ""; // Reset lại nếu cần
            }
            else
            {
                MessageBox.Show("Thêm khảo sát thất bại!");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvkhaosat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khảo sát để sửa.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txttieude.Text))
            {
                MessageBox.Show("Tiêu đề không được để trống.");
                return;
            }
            KhaoSatDTO ks = new KhaoSatDTO
            {
                MaKhaoSat = Convert.ToInt32(txtmakhaosat.Text),
                TieuDe = txttieude.Text,
                NgayTao = dtpngaytao.Value
            };

            if (ksBLL.SuaKhaoSat(ks))
            {
                MessageBox.Show("Sửa khảo sát thành công.");
                LoadKhaoSat();
            }
            else
            {
                MessageBox.Show("Sửa khảo sát thất bại.");
            }
        }
        private void dgvkhaosat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvkhaosat.Rows[e.RowIndex];
                maKhaoSat = Convert.ToInt32(row.Cells["MaKhaoSat"].Value); 
                txtmakhaosat.Text = row.Cells["MaKhaoSat"].Value.ToString();
                txttieude.Text = row.Cells["TieuDe"].Value.ToString();
                dtpngaytao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                txttrangthai.Text = row.Cells["TrangThai"].Value.ToString();
                dgvkhaosat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhanAnhKienNghi phanAnhKienNghi = new PhanAnhKienNghi();
            phanAnhKienNghi.ShowDialog();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmakhaosat.Text = "";
            txttieude.Text="";
            dtpngaytao.Value = DateTime.Now;
            txttrangthai.Text = "";

        }

        private void btntaocauhoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmakhaosat.Text))
            {
                MessageBox.Show("Vui lòng chọn khảo sát trước khi tạo câu hỏi.");
                return;
            }

            int maKhaoSat = Convert.ToInt32(txtmakhaosat.Text);
            CauHoi cauHoi = new CauHoi(maKhaoSat);
            this.Hide();
            cauHoi.ShowDialog();
        }

        private void btnxemtruoc_Click(object sender, EventArgs e)
        {
            if (dgvkhaosat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bài khảo sát.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKhaoSat = Convert.ToInt32(dgvkhaosat.SelectedRows[0].Cells["MaKhaoSat"].Value);
            string tenKhaoSat = dgvkhaosat.SelectedRows[0].Cells["TieuDe"].Value.ToString();

            List<CauHoiDTO> danhSachCauHoi = new CauHoiBLL().LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);

            if (danhSachCauHoi.Count == 0)
            {
                MessageBox.Show("Bài khảo sát này chưa có câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LamBaiKhaoSat frm = new LamBaiKhaoSat(maKhaoSat, tenKhaoSat);
            frm.ShowDialog();
        }

        private void btndangbai_Click(object sender, EventArgs e)
        {
            if (maKhaoSat <= 0)
            {
                MessageBox.Show("Vui lòng chọn bài khảo sát để đăng!");
                return;
            }
            bool ketQua = ksBLL.DangBaiKhaoSat(maKhaoSat);
            if (ketQua)
            {
                MessageBox.Show("Đăng bài khảo sát thành công!");
                LoadKhaoSat();
            }
            else
            {
                MessageBox.Show("Đăng bài thất bại, vui lòng thử lại!");
            }
        }

        private void btnxemketqua_Click(object sender, EventArgs e)
        {
            KetQuaLamBai ketQuaLamBai = new KetQuaLamBai();
            ketQuaLamBai.ShowDialog();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvkhaosat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khảo sát cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maKhaoSat = Convert.ToInt32(dgvkhaosat.CurrentRow.Cells["MaKhaoSat"].Value);

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa khảo sát mã {maKhaoSat}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                bool kq = ksBLL.XoaKhaoSat(maKhaoSat);
                if (kq)
                {
                    MessageBox.Show("Xóa khảo sát thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhaoSat();
                }
                else
                {
                    MessageBox.Show("Xóa khảo sát thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
