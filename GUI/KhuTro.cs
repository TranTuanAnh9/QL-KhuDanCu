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
    public partial class KhuTro : Form
    {
        private KhuTroBLL khutrobll = new KhuTroBLL();
        public KhuTro()
        {
            InitializeComponent();
        }
        private void KhuTro_Load(object sender, EventArgs e)
        {
            txttimkiemkhutro.ForeColor = Color.Gray;
            txttimkiemkhutro.Text = "Tìm kiếm theo mã khu trọ";

            txttimkiemkhutro.Enter += Txttimkiemkhutro_Enter;
            txttimkiemkhutro.Leave += Txttimkiemkhutro_Leave;

            pnlkhutro.BackColor = Color.LightSlateGray;

           
            btnthemkhutro.BackColor = Color.LightSlateGray;
            btnsuakhutro.BackColor = Color.LightSlateGray;
            btnthemanhkhutro.BackColor= Color.LightSlateGray;
            btnxoakhutro.BackColor = Color.LightSlateGray;
            btnlammoikhutro.BackColor = Color.LightSlateGray;
            btnback1khutro.BackColor = Color.LightSlateGray;
            btntimkiemkhutro.BackColor = Color.MintCream;
            grbthongtinkhutro.BackColor = Color.MintCream;
            grb3khutro.BackColor = Color.MintCream;
            LoadData();
        }
        private void Txttimkiemkhutro_Enter(object sender, EventArgs e)
        {
            if (txttimkiemkhutro.Text == "Tìm kiếm theo mã khu trọ")
            {
                txttimkiemkhutro.Text = "";
                txttimkiemkhutro.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemkhutro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemkhutro.Text))
            {
                txttimkiemkhutro.Text = "Tìm kiếm theo mã khu trọ";
                txttimkiemkhutro.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<KhuTroDTO> danhSach = khutrobll.LayDanhSachKhuTro();
            dtvkhutro.DataSource = danhSach;
            dtvkhutro.Columns["AnhDinhKem8"].Visible = false;
        }
        private void btnthemkhutro_Click(object sender, EventArgs e)
        {
            KhuTroDTO kt = new KhuTroDTO
            {
                MaKhuTro = txtmakhutro.Text.Trim(),
                TenKhuTro = txttenkhutro.Text.Trim(),
                DiaChi = txtdiachikhutro.Text.Trim(),
                HoTenChuTro = txthotenchutro.Text.Trim(),
                SoDienThoaiChuTro = txtsodienthoaichutro.Text.Trim(),
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                SoPhong = int.TryParse(txtsophong.Text, out int sp) ? sp : 0,
                SoPhongTrong = int.TryParse(txtsophongtrong.Text, out int spt) ? spt : -1,
                TrangThai = txttrangthai.Text.Trim()
            };
            string result = khutrobll.ThemKhuTro(kt);
            MessageBox.Show(result);

            if (result == "Thêm Khu Trọ Thành Công !.")
            {
                LoadData();
            }
        }
        private void btnback1khutro_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChuKhuTro trangChuKhuTro = new TrangChuKhuTro();
            trangChuKhuTro.ShowDialog();
        }
        private void dtvkhutro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvkhutro.Rows[e.RowIndex];

                txtmakhutro.Text = row.Cells["MaKhuTro"].Value?.ToString();
                txttenkhutro.Text = row.Cells["TenKhuTro"].Value?.ToString();
                txtdiachikhutro.Text = row.Cells["DiaChi"].Value?.ToString();
                txthotenchutro.Text = row.Cells["HoTenChuTro"].Value?.ToString();
                txtsodienthoaichutro.Text = row.Cells["SoDienThoaiChuTro"].Value?.ToString();
                txtmanhankhau.Text = row.Cells["MaNhanKhau"].Value?.ToString();
                txtsophong.Text = row.Cells["SoPhong"].Value?.ToString();
                txtsophongtrong.Text = row.Cells["SoPhongTrong"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmakhutro.ReadOnly = true;
                string maKhuTro = txtmakhutro.Text;


                byte[] imageBytes = khutrobll.LayAnhKhuTro2(maKhuTro);
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picanhkhutro.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picanhkhutro.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }
            }
        }
        private void btnsuakhutro_Click(object sender, EventArgs e)
        {
            KhuTroDTO kt = new KhuTroDTO
            {
                MaKhuTro = txtmakhutro.Text.Trim(),
                TenKhuTro = txttenkhutro.Text.Trim(),
                DiaChi = txtdiachikhutro.Text.Trim(),
                HoTenChuTro = txthotenchutro.Text.Trim(),
                SoDienThoaiChuTro = txtsodienthoaichutro.Text.Trim(),
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                SoPhong = int.TryParse(txtsophong.Text, out int sp) ? sp : 0,
                SoPhongTrong = int.TryParse(txtsophongtrong.Text, out int spt) ? spt : -1,
                TrangThai = txttrangthai.Text.Trim()
            };

            string result = khutrobll.SuaKhuTro(kt);
            MessageBox.Show(result);

            if (result == "Sửa khu trọ thành công!")
            {
                LoadData();
            }
        }
        private void btnxoakhutro_Click(object sender, EventArgs e)
        {
            string maKhuTro = txtmakhutro.Text.Trim();

            if (string.IsNullOrWhiteSpace(maKhuTro))
            {
                MessageBox.Show("Vui lòng chọn khu trọ cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khu trọ có mã [{maKhuTro}] này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string message = khutrobll.XoaKhuTro(maKhuTro);
                MessageBox.Show(message);
                if (message == "Xóa khu trọ thành công!")
                {
                    LoadData();
                }
            }
        }

        private void btnthemanhkhutro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmakhutro.Text))
            {
                MessageBox.Show("Vui lòng chọn khu trọ để thêm ảnh !", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh khu trọ";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes = File.ReadAllBytes(filePath);
                    string maKhuTro = txtmakhutro.Text;

                    bool ketQua = khutrobll.CapNhatAnhKhuTro2(maKhuTro, imageBytes);

                    if (ketQua)
                    {
                        MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                        picanhkhutro.Image = Image.FromStream(new MemoryStream(imageBytes)); // hiển thị ảnh ngay lập tức
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                    }
                }
            }
        }

        private void btntimkiemkhutro_Click(object sender, EventArgs e)
        {
            txttimkiemkhutro.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaKhuTro = txttimkiemkhutro.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaKhuTro))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = khutrobll.TimKiemKhutro(MaKhuTro);

            if (ketQua.Count > 0)
            {
                dtvkhutro.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoikhutro_Click(object sender, EventArgs e)
        {
            txtmakhutro.Text = "";
            txttenkhutro.Text = "";
            txtdiachikhutro.Text = "";
            txthotenchutro.Text = "";
            txtsodienthoaichutro.Text = "";
            txtmanhankhau.Text = "";
            txtsophong.Text = "";
            txtsophongtrong.Text = "";
            txttrangthai.Text = "";
            txtmakhutro.ReadOnly = false;

            // Nếu có DataGridView khu trọ, làm mới luôn:
            dtvkhutro.DataSource = null;
            dtvkhutro.Rows.Clear();
            LoadData();
        }
    }
}
