using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class HoKhau : Form
    {
        private HoKhauBLL hoKhauBLL = new HoKhauBLL();
        public HoKhau()
        {
            InitializeComponent();
        }
        private void HoKhau_Load(object sender, EventArgs e)
        {
            txttimkiemhokhau.ForeColor = Color.Gray;
            txttimkiemhokhau.Text = "Tìm kiếm theo mã hộ khẩu";
            txttimkiemhokhau.Enter += Txttimkiemhokhau_Enter;
            txttimkiemhokhau.Leave += Txttimkiemhokhau_Leave;
            btnthemhokhau.BackColor = Color.DarkCyan;
            btntimkiemhokhau.BackColor = Color.Tomato;
            btnsuahokhau.BackColor = Color.DarkCyan;
            btnxoahokhau.BackColor = Color.DarkCyan;
            btnlammoihokhau.BackColor = Color.DarkCyan;
            pnlhokhau1.BackColor = Color.DarkCyan;
            btnquaylai.BackColor = Color.DarkCyan;
            grbthongtinnhapvao.BackColor = Color.MintCream;
            grbchucnanghokhau.BackColor = Color.MintCream;
            btnthemanh.BackColor = Color.MintCream;
            cbbthongkehokhau.Items.Add("Thống kê hộ khẩu theo năm");
            cbbthongkehokhau.Items.Add("Thống kê hộ khẩu theo trạng thái");
            cbbthongkehokhau.SelectedIndexChanged += CmbThongKe_SelectedIndexChanged;
            cbbthongkehokhau.SelectedIndexChanged += CmbThongKe1_SelectedIndexChanged;
            chartthongkehokhautheonam.Visible = false;
            chartthongkehokhautheotrangthai.Visible = false;
            LoadData();
        }
        private void CmbThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthongkehokhau.SelectedItem.ToString() == "Thống kê hộ khẩu theo năm")
            {
                ThongKeHoKhauTheoNam();
                chartthongkehokhautheonam.Visible=true;
            }
        }
        private void CmbThongKe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthongkehokhau.SelectedItem.ToString() == "Thống kê hộ khẩu theo trạng thái")
            {
                ThongKeHoKhauTheoTrangThai();
                chartthongkehokhautheotrangthai.Visible = true;
            }
        }
        private void ThongKeHoKhauTheoNam()
        {
            // Lấy dữ liệu thống kê từ BLL
            List<ThongKeHoKhauTheoNamDTO> thongKeList = hoKhauBLL.ThongKeHoKhauTheoNam();

            // Kiểm tra dữ liệu có hợp lệ không
            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị dữ liệu lên DataGridView
                dtvhokhau.DataSource = thongKeList;

                // Cập nhật biểu đồ cột
                chartthongkehokhautheonam.Series.Clear();
                chartthongkehokhautheonam.ChartAreas.Clear();

                // Thêm ChartArea vào biểu đồ
                ChartArea chartArea = new ChartArea();
                chartthongkehokhautheonam.ChartAreas.Add(chartArea);
                // Tắt margin tự động
                chartArea.AxisX.IsMarginVisible = false;
                // Tính toán giá trị min và max cho trục X dựa trên dữ liệu
                int minYear = thongKeList.Min(x => x.Nam);
                int maxYear = thongKeList.Max(x => x.Nam);

                // Thêm một Series cho biểu đồ cột
                Series series = new Series
                {
                    Name = "Số hộ khẩu",
                    Color = System.Drawing.Color.Blue,
                    ChartType = SeriesChartType.Column, // Biểu đồ cột
                    BorderWidth = 3
                };

                // Thêm các điểm dữ liệu vào series từ danh sách thongKeList
                foreach (var item in thongKeList)
                {
                    // Thêm các cột X (Năm) và Y (Số lượng hộ khẩu)
                    series.Points.AddXY(item.Nam, item.TongSoHoKhau);
                }

                // Thêm series vào biểu đồ
                chartthongkehokhautheonam.Series.Add(series);

                // Đảm bảo rằng dữ liệu trên biểu đồ và DataGridView là đồng bộ
                // Cập nhật DataGridView với chính dữ liệu từ thongKeList, nếu có sự thay đổi trong dữ liệu
                dtvhokhau.DataSource = null;  // Dọn sạch DataGridView trước khi gán lại
                dtvhokhau.DataSource = thongKeList;
            }
            else
            {
                // Trường hợp không có dữ liệu
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void ThongKeHoKhauTheoTrangThai()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeHoKhauTheoTrangThaiDTO> thongKeList = hoKhauBLL.ThongKeHoKhauTheoTrangThai();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị dữ liệu lên DataGridView
                dtvhokhau.DataSource = null;
                dtvhokhau.DataSource = thongKeList;

                // Cập nhật biểu đồ
                chartthongkehokhautheotrangthai.Series.Clear();
                chartthongkehokhautheotrangthai.ChartAreas.Clear();
                chartthongkehokhautheotrangthai.Titles.Clear();

                ChartArea chartArea = new ChartArea();
                chartthongkehokhautheotrangthai.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "Trạng thái hộ khẩu",
                    ChartType = SeriesChartType.Pie, // Biểu đồ tròn
                    IsValueShownAsLabel = true,
                    LabelForeColor = Color.Black
                };

                foreach (var item in thongKeList)
                {
                    DataPoint dp = new DataPoint();
                    dp.AxisLabel = item.TrangThai;
                    dp.YValues = new double[] { item.TongSoHoKhau };
                    dp.LegendText = item.TrangThai + $" ({item.TongSoHoKhau})";
                    series.Points.Add(dp);
                }

                chartthongkehokhautheotrangthai.Series.Add(series);
                chartthongkehokhautheotrangthai.Titles.Add("Thống kê hộ khẩu theo trạng thái");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để thống kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Txttimkiemhokhau_Enter(object sender, EventArgs e)
        {
            if (txttimkiemhokhau.Text == "Tìm kiếm theo mã hộ khẩu")
            {
                txttimkiemhokhau.Text = "";
                txttimkiemhokhau.ForeColor = Color.Black;
            }
        }
        private void Txttimkiemhokhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemhokhau.Text))
            {
                txttimkiemhokhau.Text = "Tìm kiếm theo mã hộ khẩu";
                txttimkiemhokhau.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<HoKhauDTO> danhSach = hoKhauBLL.LayDanhSachHoKhau();
            dtvhokhau.DataSource = danhSach;
            // Ẩn cột hình ảnh
            dtvhokhau.Columns["AnhDinhKem"].Visible = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void btnthemhokhau_Click(object sender, EventArgs e)
        {
            HoKhauDTO hk = new HoKhauDTO
            {
                MaHoKhau = txtmahokhau.Text,
                TenChuHo = txttenchuho.Text,
                CCCDChuHo = txtcccdchuho.Text,
                DiaChi = txtdiachi.Text,
                SoThanhVien = int.TryParse(txtsothanhvien.Text, out int soTV) ? soTV : -1,
                NgayLap = dtpngaylap.Value,
                TrangThai = txttrangthai.Text,
                MoTa = txtmota.Text
            };

            string ketQua = hoKhauBLL.ThemHoKhau(hk);
            MessageBox.Show(ketQua);

            if (ketQua == "Thêm Hộ Khẩu Thành Công !")
            {
                LoadData(); // load lại danh sách lên datagridview
            }
        }
        private void btnquaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChuHoKhau trangChuHoKhau = new TrangChuHoKhau();
            trangChuHoKhau.ShowDialog();
        }
        private void dtvhokhau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh lỗi khi click tiêu đề cột
            {
                DataGridViewRow row = dtvhokhau.Rows[e.RowIndex];

                txtmahokhau.Text = row.Cells["MaHoKhau"].Value?.ToString();
                txttenchuho.Text = row.Cells["TenChuHo"].Value?.ToString();
                txtcccdchuho.Text = row.Cells["CCCDChuHo"].Value?.ToString();
                txtdiachi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtsothanhvien.Text = row.Cells["SoThanhVien"].Value?.ToString();
                dtpngaylap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmota.Text = row.Cells["MoTa"].Value?.ToString();
                txtmahokhau.ReadOnly = true;
                txtsothanhvien.ReadOnly = true;
                string maHoKhau = txtmahokhau.Text;

                byte[] imageBytes = hoKhauBLL.LayAnhHoKhau(maHoKhau);

                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pichinhanhhokhau.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pichinhanhhokhau.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }

                txtmahokhau.ReadOnly = true;
            }
        }
        private void btnsuahokhau_Click(object sender, EventArgs e)
        {
            HoKhauDTO hk = new HoKhauDTO
            {
                MaHoKhau = txtmahokhau.Text,
                TenChuHo = txttenchuho.Text,
                CCCDChuHo = txtcccdchuho.Text,
                DiaChi = txtdiachi.Text,
                SoThanhVien = int.TryParse(txtsothanhvien.Text, out int soTV) ? soTV : -1,
                NgayLap = dtpngaylap.Value,
                TrangThai = txttrangthai.Text,
                MoTa = txtmota.Text
            };

            string ketQua = hoKhauBLL.SuaHoKhau(hk);
            MessageBox.Show(ketQua);

            if (ketQua == "Sửa Hộ Khẩu Thành Công !")
            {
                LoadData(); // cập nhật lại datagridview
            }
        }
        private void btnxoahokhau_Click(object sender, EventArgs e)
        {
            string maHoKhau = txtmahokhau.Text;

            if (string.IsNullOrWhiteSpace(maHoKhau))
            {
                MessageBox.Show("Vui lòng chọn hộ khẩu cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hộ khẩu có má [{maHoKhau}] này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string ketQua = hoKhauBLL.XoaHoKhau(maHoKhau);
                MessageBox.Show(ketQua);

                if (ketQua == "Xóa Hộ Khẩu Thành Công !")
                {
                    LoadData();
                }
            }
        }
        private void btntimkiemhokhau_Click(object sender, EventArgs e)
        {
            txttimkiemhokhau.Focus(); // Đảm bảo text mới nhất được cập nhật
            string tuKhoa = txttimkiemhokhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = hoKhauBLL.TimKiemHoKhau(tuKhoa);

            if (ketQua.Count > 0)
            {
                dtvhokhau.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }
        private void btnthemanh_Click(object sender, EventArgs e)
        {// Kiểm tra chọn hộ khẩu trước khi thêm ảnh
            if (string.IsNullOrWhiteSpace(txtmahokhau.Text))
            {
                MessageBox.Show("Vui lòng chọn hộ khẩu để thêm ảnh!", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh hộ khẩu";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        byte[] imageBytes = File.ReadAllBytes(filePath);
                        string maHoKhau = txtmahokhau.Text;

                        bool ketQua = hoKhauBLL.CapNhatAnhHoKhau(maHoKhau, imageBytes);

                        if (ketQua)
                        {
                            MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                            pichinhanhhokhau.Image = Image.FromStream(new MemoryStream(imageBytes)); // hiển thị ảnh ngay lập tức
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
        private void btnlammoihokhau_Click(object sender, EventArgs e)
        {
            // Xóa nội dung TextBox
            txtmahokhau.Text = "";
            txttenchuho.Text = "";
            txtsothanhvien.Text = "";
            txtmota.Text = "";
            txtcccdchuho.Text = "";
            txtdiachi.Text = "";
            txttrangthai.Text = "";
            txtmahokhau.ReadOnly = false;
            txtsothanhvien.ReadOnly = false;

            // Reset DateTimePicker
            dtpngaylap.Value = DateTime.Now;

            // Làm trống DataGridView
            dtvhokhau.DataSource = null;
            dtvhokhau.Rows.Clear();
            LoadData();
        }

    }
}

