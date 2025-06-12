using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GiayTamVang : Form
    {
        private GiayTamVangBLL giaytamvangbll = new GiayTamVangBLL();
        public GiayTamVang()
        {
            InitializeComponent();
        }

        private void lblthongtinnhankhau_Click(object sender, EventArgs e)
        {

        }

        private void GiayTamVang_Load(object sender, EventArgs e)
        {
            dtvgiaytamvang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvgiaytamvang.MultiSelect = false;
            txttimkiemgiaytamvang.ForeColor = Color.Gray;
            txttimkiemgiaytamvang.Text = "Tìm kiếm theo mã giấy tạm vắng";

            txttimkiemgiaytamvang.Enter += Txttimkiemgiaytamvang_Enter;
            txttimkiemgiaytamvang.Leave += Txttimkiemgiaytamvang_Leave;

            pnl1giaytamvang.BackColor = Color.SkyBlue;
            btntimkiemgiaytamvang.BackColor = Color.LightYellow;
            btnthemgiaytamvang.BackColor = Color.SkyBlue;
            btnthemanhnhankhau1.BackColor = Color.SkyBlue;
            btnthemanhnhanhankhau.BackColor = Color.SkyBlue;
            btnsuagiaytamvang.BackColor = Color.SkyBlue;
            btnxuatdon.BackColor = Color.SkyBlue;
            btnxoagiaytamvang.BackColor = Color.SkyBlue;
            btnlammoigiaytamvang.BackColor = Color.SkyBlue;
            btnback1giaytamvang.BackColor = Color.SkyBlue;
            grbgiaytamvang5.BackColor = Color.LightGoldenrodYellow;
            grb3giaytamvang.BackColor = Color.LightGoldenrodYellow;
            LoadData();
            
        }
        private void Txttimkiemgiaytamvang_Enter(object sender, EventArgs e)
        {
            if (txttimkiemgiaytamvang.Text == "Tìm kiếm theo mã giấy tạm vắng")
            {
                txttimkiemgiaytamvang.Text = "";
                txttimkiemgiaytamvang.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemgiaytamvang_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemgiaytamvang.Text))
            {
                txttimkiemgiaytamvang.Text = "Tìm kiếm theo mã giấy tạm vắng";
                txttimkiemgiaytamvang.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<GiayTamVangDTO> danhSach = giaytamvangbll.LayDanhSachGiayTamVang();
            dtvgiaytamvang.DataSource = danhSach;
            dtvgiaytamvang.Columns["AnhDinhKem4"].Visible = false;
            dtvgiaytamvang.Columns["AnhDinhKem5"].Visible = false;
        }

        private void btnthemgiaytamvang_Click(object sender, EventArgs e)
        {
            GiayTamVangDTO gtv = new GiayTamVangDTO
            {
                MaGiayTamVang = txtmagiaytamvang.Text.Trim(),
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                NgaySinh = DateTime.TryParse(dtpngaysinh.Text.Trim(), out DateTime ns) ? ns : DateTime.MinValue,
                GioiTinh = txtgioitinh.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                NoiDi = txtnoidi.Text.Trim(),
                NgayDi = dtpngaydi.Value,
                NgayVe = dtpngayve.Value,
                LyDo = txtlydo.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim(),
                SoNgay = (dtpngayve.Value - dtpngaydi.Value).Days
            };

            string ketQua = giaytamvangbll.ThemGiayTamVang(gtv);
            MessageBox.Show(ketQua);

            if (ketQua == "Thêm Giấy Tạm Vắng Thành Công !.")
            {
                LoadData(); // load lại DataGridView
            }
        }

        private void btnback1giaytamvang_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvgiaytamvang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvgiaytamvang.Rows[e.RowIndex];

                txtmagiaytamvang.Text = row.Cells["MaGiayTamVang"].Value?.ToString();
                txtmanhankhau.Text = row.Cells["MaNhanKhau"].Value?.ToString();
                txthoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtcccd.Text = row.Cells["CCCD"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                    dtpngaysinh.Value = ns;

                txtgioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtsodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtnoidi.Text = row.Cells["NoiDi"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayDi"].Value?.ToString(), out DateTime ngaydi))
                    dtpngaydi.Value = ngaydi;

                if (DateTime.TryParse(row.Cells["NgayVe"].Value?.ToString(), out DateTime ngayve))
                    dtpngayve.Value = ngayve;

                txtlydo.Text = row.Cells["LyDo"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmagiaytamvang.ReadOnly = true;

                string maGiayTamVang = txtmagiaytamvang.Text;

                byte[] imageBytes = giaytamvangbll.LayAnhNhanKhau1(maGiayTamVang);
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picgiaytamvang.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picgiaytamvang.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }

                byte[] imageBytes2 = giaytamvangbll.LayAnhNhaNhanKhau1(maGiayTamVang);
                if (imageBytes2 != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes2))
                    {
                        pic2giaytamvang.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pic2giaytamvang.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }
            }
        }

        private void btnsuagiaytamvang_Click(object sender, EventArgs e)
        {
            GiayTamVangDTO gtv = new GiayTamVangDTO
            {
                MaGiayTamVang = txtmagiaytamvang.Text.Trim(),
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                GioiTinh = txtgioitinh.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                NoiDi = txtnoidi.Text.Trim(),
                NgayDi = dtpngaydi.Value,
                NgayVe = dtpngayve.Value,
                LyDo = txtlydo.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };

            string kq = giaytamvangbll.SuaGiayTamVang(gtv);
            MessageBox.Show(kq);
            if (kq == "Sửa giấy tạm vắng thành công!")
            {
                LoadData(); // load lại DataGridView
            }
        }

        private void btnxoagiaytamvang_Click(object sender, EventArgs e)
        {
            string maGiayTamVang = txtmagiaytamvang.Text.Trim();

            if (string.IsNullOrWhiteSpace(maGiayTamVang))
            {
                MessageBox.Show("Vui lòng chọn giấy tạm vắng cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa giấy tạm vắng có mã [{maGiayTamVang}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = giaytamvangbll.XoaGiayTamVang(maGiayTamVang);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa giấy tạm vắng thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btnthemanhnhankhau1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagiaytamvang.Text))
            {
                MessageBox.Show("Vui lòng chọn giấy tạm vắng để thêm ảnh cho nhân khẩu !", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh Nhân Khẩu";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                        string filePath = openFileDialog.FileName;
                        byte[] imageBytes = File.ReadAllBytes(filePath);
                        string maGiayTamVang = txtmagiaytamvang.Text;

                        bool ketQua = giaytamvangbll.CapNhatAnhNhanKhau1(maGiayTamVang, imageBytes);

                        if (ketQua)
                        {
                            MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                            picgiaytamvang.Image = Image.FromStream(new MemoryStream(imageBytes)); // hiển thị ảnh ngay lập tức
                        }
                        else
                        {
                            MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                        }
                }
            }
        }
        private void btnthemanhnhanhankhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagiaytamvang.Text))
            {
                MessageBox.Show("Vui lòng chọn giấy tạm vắng để thêm ảnh cho nhà nhân khẩu !", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh Nhân Khẩu";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes2 = File.ReadAllBytes(filePath);
                    string maGiayTamVang = txtmagiaytamvang.Text;

                    bool ketQua = giaytamvangbll.CapNhatAnhNhaNhanKhau1(maGiayTamVang, imageBytes2);

                    if (ketQua)
                    {
                        MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                        pic2giaytamvang.Image = Image.FromStream(new MemoryStream(imageBytes2)); // hiển thị ảnh ngay lập tức
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                    }
                }
            }
        }

        private void btntimkiemgiaytamvang_Click(object sender, EventArgs e)
        {
            txttimkiemgiaytamvang.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaGiayTamVang = txttimkiemgiaytamvang.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaGiayTamVang))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = giaytamvangbll.TimKiemGiayTamVang(MaGiayTamVang);

            if (ketQua.Count > 0)
            {
                dtvgiaytamvang.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoigiaytamvang_Click(object sender, EventArgs e)
        {
            txtmagiaytamvang.Text = "";
            txtmanhankhau.Text = "";
            txthoten.Text = "";
            txtcccd.Text = "";
            dtpngaysinh.Value = DateTime.Now;
            txtgioitinh.Text = "";
            txtsodienthoai.Text = "";
            txtnoidi.Text = "";
            dtpngaydi.Value = DateTime.Now;
            dtpngayve.Value = DateTime.Now;
            txtlydo.Text = "";
            txttrangthai.Text = "";
            txtmagiaytamvang.ReadOnly = false;

            // Nếu có DataGridView hiển thị giấy tạm vắng thì reset luôn:
            dtvgiaytamvang.DataSource = null;
            dtvgiaytamvang.Rows.Clear();
            LoadData();
        }

        private void btnxuatdon_Click(object sender, EventArgs e)
        {
            if (dtvgiaytamvang.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtvgiaytamvang.SelectedRows[0];

                string maNhanKhau = row.Cells["MaNhanKhau"].Value.ToString();
                string hoTen = row.Cells["HoTen"].Value.ToString();
                string cccd = row.Cells["CCCD"].Value.ToString();
                string ngaySinh = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                string soDienThoai = row.Cells["SoDienThoai"].Value.ToString();
                string noiDi = row.Cells["NoiDi"].Value.ToString();
                string ngayDi = Convert.ToDateTime(row.Cells["NgayDi"].Value).ToString("dd/MM/yyyy");
                string ngayVe = Convert.ToDateTime(row.Cells["NgayVe"].Value).ToString("dd/MM/yyyy");
                string lyDo = row.Cells["LyDo"].Value.ToString();
                string trangThai = row.Cells["TrangThai"].Value.ToString();
                int soNgay = Convert.ToInt32(row.Cells["SoNgay"].Value);

                // Gọi form GiayTamVangForm với các thông tin
                DonGiayTamVang formGiayTamVang = new DonGiayTamVang(maNhanKhau, hoTen, cccd, ngaySinh, gioiTinh,
                    soDienThoai, noiDi, ngayDi, ngayVe, lyDo, trangThai, soNgay);
                formGiayTamVang.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xuất giấy tạm vắng.");
            }
        }
    }
}
