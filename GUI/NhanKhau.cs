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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class NhanKhau : Form
    {
        private NhanKhauBLL nhanKhauBLL = new NhanKhauBLL();
        public NhanKhau(string maHoKhau)
        {
            InitializeComponent();

            // Gán mã khu trọ vào textbox
            txtmahokhau.Text = maHoKhau;
            txtmahokhau.ReadOnly = false; // Nếu bạn không muốn cho sửa
        }
        public NhanKhau()
        {
            InitializeComponent();
        }

        private void lbl1nhankhau_Click(object sender, EventArgs e)
        {

        }

        private void NhanKhau_Load(object sender, EventArgs e)
        {
            txttimkiem.Text = "Tìm kiếm theo mã nhân khẩu hoặc CCCD";
            txttimkiem.ForeColor = Color.Gray;
            txttimkiem.Enter += Txttimkiem_Enter;
            txttimkiem.Leave += Txttimkiem_Leave;

            this.ActiveControl = dtvnhankhau;
            pnl1nhankhau.BackColor = Color.DarkCyan;
            btntimkiem.BackColor = Color.Tomato;
            btnthemanhnha.BackColor = Color.DarkCyan;
            btnthemanhfaceid.BackColor = Color.DarkCyan;
            btnthemnhankhau.BackColor = Color.DarkCyan;
            btnsuanhankhau.BackColor = Color.DarkCyan;
            btnxoanhankhau.BackColor = Color.DarkCyan;
            btnlammoinhankhau.BackColor = Color.DarkCyan;
            btnback1.BackColor = Color.DarkCyan;
            grbnhankhau5.BackColor = Color.AliceBlue;
            grb3nhankhau.BackColor = Color.AliceBlue;
            cbbthognke.Items.Add("Thống kê nhân khẩu theo độ tuổi");
            cbbthognke.Items.Add("Thống kê nhân khẩu theo giới tính");
            cbbthognke.SelectedIndexChanged += CmbThongKenhankhau_SelectedIndexChanged;
            cbbthognke.SelectedIndexChanged += CmbThongKenhankhau1_SelectedIndexChanged;
            chartthongkenhankhautheogioitinh.Visible = false;   
            chartthongkenhankhautheotuoi.Visible = false;
            LoadData();
        }
        private void CmbThongKenhankhau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognke.SelectedItem.ToString() == "Thống kê nhân khẩu theo độ tuổi")
            {
                ThongKeNhanKhauTheoDoTuoi();
                chartthongkenhankhautheotuoi.Visible = true;
            }
        }
        private void CmbThongKenhankhau1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognke.SelectedItem.ToString() == "Thống kê nhân khẩu theo giới tính")
            {
                ThongKeNhanKhauTheoGioiTinh();
                chartthongkenhankhautheogioitinh.Visible = true;
            }
        }

        private void ThongKeNhanKhauTheoDoTuoi()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeNhanKhauTheoDoTuoiDTO> thongKeList = nhanKhauBLL.ThongKeNhanKhauTheoDoTuoi();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị lên DataGridView
                dtvnhankhau.DataSource = null;
                dtvnhankhau.DataSource = thongKeList;

                // Xóa và cấu hình lại biểu đồ
                chartthongkenhankhautheotuoi.Series.Clear();
                chartthongkenhankhautheotuoi.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chartthongkenhankhautheotuoi.ChartAreas.Add(chartArea);

                // Tắt khoảng cách giữa các cột để giống histogram
                chartArea.AxisX.IsMarginVisible = false;

                // Series cho histogram
                Series series = new Series
                {
                    Name = "Số lượng",
                    Color = System.Drawing.Color.Orange,
                    ChartType = SeriesChartType.Column,
                    BorderWidth = 2
                };

                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.NhomTuoi, item.SoLuong);
                }

                chartthongkenhankhautheotuoi.Series.Add(series);

                // Tùy chỉnh trục X để dễ nhìn
                chartArea.AxisX.Title = "Nhóm tuổi";
                chartArea.AxisY.Title = "Số lượng nhân khẩu";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void ThongKeNhanKhauTheoGioiTinh()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeNhanKhauTheoGioiTinhDTO> thongKeList = nhanKhauBLL.ThongKeNhanKhauTheoGioiTinh();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị lên DataGridView
                dtvnhankhau.DataSource = null;
                dtvnhankhau.DataSource = thongKeList;

                // Xóa và cấu hình lại biểu đồ
                chartthongkenhankhautheogioitinh.Series.Clear();
                chartthongkenhankhautheogioitinh.ChartAreas.Clear();
                chartthongkenhankhautheogioitinh.Titles.Clear();

                // Thêm ChartArea
                ChartArea chartArea = new ChartArea();
                chartthongkenhankhautheogioitinh.ChartAreas.Add(chartArea);

                // Tạo series mới dạng pie
                Series series = new Series
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10)
                };

                // Thêm dữ liệu vào series
                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.GioiTinh, item.SoLuong);
                }

                // Thêm series vào chart
                chartthongkenhankhautheogioitinh.Series.Add(series);

                // Thêm tiêu đề nếu muốn
                chartthongkenhankhautheogioitinh.Titles.Add("Thống kê nhân khẩu theo giới tính");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void LoadData()
        {
            List<NhanKhauDTO> danhSach = nhanKhauBLL.LayDanhSachNhanKhau();
            dtvnhankhau.DataSource = danhSach;
            dtvnhankhau.Columns["AnhDinhKem2"].Visible = false;
            dtvnhankhau.Columns["AnhDinhKem3"].Visible = false;
        }
        private void Txttimkiem_Enter(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "Tìm kiếm theo mã nhân khẩu hoặc CCCD")
            {
                txttimkiem.Text = "";
                txttimkiem.ForeColor = Color.Black;
            }
        }

        private void Txttimkiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiem.Text))
            {
                txttimkiem.Text = "Tìm kiếm theo mã nhân khẩu hoặc CCCD";
                txttimkiem.ForeColor = Color.Gray;
            }
        }

        private void btnthemnhankhau_Click(object sender, EventArgs e)
        {
            NhanKhauDTO nk = new NhanKhauDTO
            {
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                MaHoKhau = txtmahokhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                GioiTinh = txtgioitinh.Text.Trim(),
                QuanHeVoiChuHo = txtquanhevoichuho.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim(),
                GhiChu = txtghichu.Text.Trim(),
                Email = txtemail.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim()
            };

            string ketQua = nhanKhauBLL.ThemNhanKhau(nk);
            MessageBox.Show(ketQua);

            if (ketQua == "Thêm nhân khẩu thành công !.")
            {
                LoadData(); // load lại dữ liệu
            }

        }

        private void btnback1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvnhankhau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvnhankhau.Rows[e.RowIndex];

                txtmanhankhau.Text = row.Cells["MaNhanKhau"].Value?.ToString();
                txtmahokhau.Text = row.Cells["MaHoKhau"].Value?.ToString();
                txthoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtcccd.Text = row.Cells["CCCD"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaysinh))
                {
                    dtpngaysinh.Value = ngaysinh;
                }

                txtgioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtquanhevoichuho.Text = row.Cells["QuanHeVoiChuHo"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtghichu.Text = row.Cells["GhiChu"].Value?.ToString();
                txtemail.Text = row.Cells["Email"].Value?.ToString();
                txtsodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtmanhankhau.ReadOnly = true;

                string maNhanKhau = txtmanhankhau.Text;

                byte[] imageBytes = nhanKhauBLL.LayAnhNhanKhau(maNhanKhau);
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picnhankhau1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picnhankhau1.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }

                byte[] imageBytes2 = nhanKhauBLL.LayAnhNhaNhanKhau(maNhanKhau);
                if (imageBytes2 != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes2))
                    {
                        picnhankhau.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picnhankhau.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }
            }
        }
        private void btnsuanhankhau_Click(object sender, EventArgs e)
        {
            NhanKhauDTO nk = new NhanKhauDTO
            {
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                MaHoKhau = txtmahokhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                GioiTinh = txtgioitinh.Text.Trim(),
                QuanHeVoiChuHo = txtquanhevoichuho.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim(),
                GhiChu = txtghichu.Text.Trim(),
                Email = txtemail.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim()
            };

            string ketQua = nhanKhauBLL.SuaNhanKhau(nk);  // gọi BLL xử lý
            MessageBox.Show(ketQua);

            if (ketQua == "Sửa nhân khẩu thành công.")
            {
                LoadData(); // Cập nhật lại danh sách
            }
        }

        private void btnxoanhankhau_Click(object sender, EventArgs e)
        {
            string maNhanKhau = txtmanhankhau.Text;

            if (string.IsNullOrWhiteSpace(maNhanKhau))
            {
                MessageBox.Show("Vui lòng chọn nhân khẩu cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân khẩu với mã [{maNhanKhau}] này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string ketQua = nhanKhauBLL.XoaNhanKhau(maNhanKhau);
                MessageBox.Show(ketQua);

                if (ketQua == "Xóa Nhân Khẩu Thành Công !")
                {
                    LoadData();
                }
            }
        }

        private void btnthemanhfaceid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanhankhau.Text))
            {
                MessageBox.Show("Vui lòng chọn Nhân Khẩu để thêm ảnh!", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh Nhân Khẩu";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        byte[] imageBytes = File.ReadAllBytes(filePath);
                        string manNhanKhau = txtmanhankhau.Text;

                        bool ketQua = nhanKhauBLL.CapNhatAnhNhanKhau(manNhanKhau, imageBytes);

                        if (ketQua)
                        {
                            MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                            picnhankhau1.Image = Image.FromStream(new MemoryStream(imageBytes)); // hiển thị ảnh ngay lập tức
                        }
                        else
                        {
                            MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
                    }
                }
            }
        }

        private void btnthemanhnha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmahokhau.Text))
            {
                MessageBox.Show("Vui lòng chọn Nhân Khẩu để thêm ảnh!", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh Nhà Nhân Khẩu";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                        string filePath = openFileDialog.FileName;
                        byte[] imageBytes2 = File.ReadAllBytes(filePath);
                        string manNhanKhau = txtmanhankhau.Text;

                        bool ketQua = nhanKhauBLL.CapNhatAnhNhaNhanKhau(manNhanKhau, imageBytes2);

                        if (ketQua)
                        {
                            MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                            picnhankhau.Image = Image.FromStream(new MemoryStream(imageBytes2)); // hiển thị ảnh ngay lập tức
                        }
                        else
                        {
                            MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                        }
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Focus(); // Đảm bảo text mới nhất được cập nhật
            string tuKhoa1 = txttimkiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa1))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = nhanKhauBLL.TimKiemNhanKhau(tuKhoa1);

            if (ketQua.Count > 0)
            {
                dtvnhankhau.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoinhankhau_Click(object sender, EventArgs e)
        {
            txtmanhankhau.Text = "";
            txtmahokhau.Text = "";
            txthoten.Text = "";
            txtcccd.Text = "";
            dtpngaysinh.Value = DateTime.Now;
            txtgioitinh.Text = "";
            txtquanhevoichuho.Text = "";
            txttrangthai.Text = "";
            txtghichu.Text = "";
            txtemail.Text = "";
            txtsodienthoai.Text = "";
            txtmanhankhau.ReadOnly = false;

            // Nếu bạn có DataGridView muốn làm mới luôn thì thêm:
            dtvnhankhau.DataSource = null;
            dtvnhankhau.Rows.Clear();
            LoadData();
        }

    }
}
