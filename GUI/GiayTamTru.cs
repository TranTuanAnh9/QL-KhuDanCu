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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class GiayTamTru : Form
    {
        private GiayTamTruBLL giaytamtrubll = new GiayTamTruBLL();
        public GiayTamTru()
        {
            InitializeComponent();
        }

        private void GiayTamTru_Load(object sender, EventArgs e)
        {
            dtvgiaytamtru.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvgiaytamtru.MultiSelect = false;
            txttimkiemgiaytamtru.ForeColor = Color.Gray;
            txttimkiemgiaytamtru.Text = "Tìm kiếm theo mã giấy tạm trú";

            txttimkiemgiaytamtru.Enter += Txttimkiemgiaytamtru_Enter;
            txttimkiemgiaytamtru.Leave += Txttimkiemgiaytamtru_Leave;
            pnl1giaytamtru.BackColor = Color.Turquoise;
            btntimkiemgiaytamtru.BackColor = Color.LemonChiffon;
            btnthemgiaytamtru.BackColor = Color.LightCyan;
            btnthemanhkhutro.BackColor = Color.LightCyan;
            btnthemanhnguoixincap.BackColor = Color.LightCyan;
            btnsuagiaytamtru.BackColor = Color.LightCyan;
            btnxoagiaytamtru.BackColor = Color.LightCyan;
            btnback1giaytamtru.BackColor = Color.LightCyan;
            btnlammoigiaytamtru.BackColor= Color.LightCyan;
            grbgiaytamtru.BackColor = Color.AliceBlue;
            grb3giaytamtru.BackColor =Color.AliceBlue;
            btnxuatdon.BackColor = Color.LightCyan;
            cbbthognkegiaytamtru.SelectedIndexChanged += CmbThongKegiaytamtru_SelectedIndexChanged;
            cbbthognkegiaytamtru.SelectedIndexChanged += CmbThongKegiaytamtru2_SelectedIndexChanged;
            cbbthognkegiaytamtru.Items.Add("Thống kê giấy tạm trú theo giới tính");
            cbbthognkegiaytamtru.Items.Add("Thống kê giấy tạm trú theo số ngày");
            chartthongketheogioitin.Visible = false;
            chart2.Visible = false;
            LoadData();
        }
        private void CmbThongKegiaytamtru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkegiaytamtru.SelectedItem.ToString() == "Thống kê giấy tạm trú theo giới tính")
            {
                ThongKeGiayTamTruTheoGioiTinh();
                chartthongketheogioitin.Visible = true;
            }
        }
        private void CmbThongKegiaytamtru2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkegiaytamtru.SelectedItem.ToString() == "Thống kê giấy tạm trú theo số ngày")
            {
                ThongKeGiayTamTruTheoSoNgay();
                chart2.Visible=true;
            }
        }
        private void ThongKeGiayTamTruTheoSoNgay()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeGiayTamTruTheoSoNgayDTO> thongKeList = giaytamtrubll.ThongKeGiayTamTruTheoSoNgay();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị dữ liệu lên DataGridView
                dtvgiaytamtru.DataSource = null;
                dtvgiaytamtru.DataSource = thongKeList;

                // Cấu hình biểu đồ
                chart2.Series.Clear();
                chart2.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chart2.ChartAreas.Add(chartArea);

                // Tắt khoảng trắng đầu cuối trục X
                chartArea.AxisX.IsMarginVisible = false;

                // Series cho biểu đồ đường
                Series series = new Series
                {
                    Name = "Số lượng giấy",
                    Color = System.Drawing.Color.MediumPurple,
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8
                };

                // Thêm dữ liệu vào series
                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.NhomSoNgay, item.SoLuong);
                }

                chart2.Series.Add(series);

                // Tùy chỉnh trục
                chartArea.AxisX.Title = "Nhóm số ngày tạm trú";
                chartArea.AxisY.Title = "Số lượng giấy";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void ThongKeGiayTamTruTheoGioiTinh()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeGiayTamTruTheoGioiTinhDTO> thongKeList = giaytamtrubll.ThongKeGiayTamTruTheoGioiTinh();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị lên DataGridView
                dtvgiaytamtru.DataSource = null;
                dtvgiaytamtru.DataSource = thongKeList;

                // Cấu hình lại biểu đồ
                chartthongketheogioitin.Series.Clear();
                chartthongketheogioitin.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chartthongketheogioitin.ChartAreas.Add(chartArea);

                // Tạo Series cho biểu đồ tròn
                Series series = new Series
                {
                    Name = "Giới tính",
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelForeColor = System.Drawing.Color.Black
                };

                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.GioiTinh, item.SoLuong);
                }

                chartthongketheogioitin.Series.Add(series);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }

        private void Txttimkiemgiaytamtru_Enter(object sender, EventArgs e)
        {
            if (txttimkiemgiaytamtru.Text == "Tìm kiếm theo mã giấy tạm trú")
            {
                txttimkiemgiaytamtru.Text = "";
                txttimkiemgiaytamtru.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemgiaytamtru_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemgiaytamtru.Text))
            {
                txttimkiemgiaytamtru.Text = "Tìm kiếm theo mã giấy tạm trú";
                txttimkiemgiaytamtru.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<GiayTamTruDTO> danhSach = giaytamtrubll.LayDanhSachGiayTamTru();
            dtvgiaytamtru.DataSource = danhSach;
            dtvgiaytamtru.Columns["AnhDinhKem9"].Visible = false;
            dtvgiaytamtru.Columns["AnhDinhKem10"].Visible = false;
        }
        private void btnthemgiaytamtru_Click(object sender, EventArgs e)
        {
            GiayTamTruDTO gtt = new GiayTamTruDTO
            {
                MaGiayTamTru = txtmagiaytamtru.Text.Trim(),
                MaNguoiThue = txtmanguoithue.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                GioiTinh = txtgioitinh.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                CCCD = txtcccd.Text.Trim(),
                QueQuan = txtquequan.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                NoiTamTru = txtnoidi.Text.Trim(),
                NgayBatDau = dtpngaybatdau.Value,
                NgayKetThuc = dtpngayketthuc.Value,
                LyDo = txtlydo.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };
            string ketqua = giaytamtrubll.ThemGiayTamTru(gtt);
            MessageBox.Show(ketqua);
            if (ketqua == "Thêm Giấy Tạm Trú thành công!.")
            {
                LoadData(); // load lại DataGridView
            }
        }

        private void btnback1giaytamtru_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvgiaytamtru_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvgiaytamtru.Rows[e.RowIndex];

                txtmagiaytamtru.Text = row.Cells["MaGiayTamTru"].Value?.ToString();
                txtmanguoithue.Text = row.Cells["MaNguoiThue"].Value?.ToString();
                txthoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtgioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtcccd.Text = row.Cells["CCCD"].Value?.ToString();
                txtsodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtquequan.Text = row.Cells["QueQuan"].Value?.ToString();
                txtnoidi.Text = row.Cells["NoiTamTru"].Value?.ToString();
                txtlydo.Text = row.Cells["LyDo"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmagiaytamtru.ReadOnly = true;

                DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaysinh);
                dtpngaysinh.Value = ngaysinh;

                DateTime.TryParse(row.Cells["NgayBatDau"].Value?.ToString(), out DateTime ngaybd);
                dtpngaybatdau.Value = ngaybd;

                DateTime.TryParse(row.Cells["NgayKetThuc"].Value?.ToString(), out DateTime ngaykt);
                dtpngayketthuc.Value = ngaykt;
                string maGiayTamTru = txtmagiaytamtru.Text;

                byte[] imageBytes = giaytamtrubll.LayAnhNguoiXinCapTamTru(maGiayTamTru);
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pickhutro.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pickhutro.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }

                byte[] imageBytes2 = giaytamtrubll.LayAnhKhuTroTamTru(maGiayTamTru);
                if (imageBytes2 != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes2))
                    {
                        pic2khutro.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pic2khutro.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }
            }
        }

        private void btnsuagiaytamtru_Click(object sender, EventArgs e)
        {
            GiayTamTruDTO gtt = new GiayTamTruDTO
            {
                MaGiayTamTru = txtmagiaytamtru.Text.Trim(),
                MaNguoiThue = txtmanguoithue.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                GioiTinh = txtgioitinh.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                CCCD = txtcccd.Text.Trim(),
                QueQuan = txtquequan.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                NoiTamTru = txtnoidi.Text.Trim(),
                NgayBatDau = dtpngaybatdau.Value,
                NgayKetThuc = dtpngayketthuc.Value,
                LyDo = txtlydo.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };
            string ketqua = giaytamtrubll.SuaGiayTamTru(gtt);
            MessageBox.Show(ketqua);
            if (ketqua == "Sửa Giấy Tạm Trú thành công!")
            {
                LoadData(); // load lại DataGridView
            }
        }

        private void btnxoagiaytamtru_Click(object sender, EventArgs e)
        {
            string maGiayTamTru = txtmagiaytamtru.Text.Trim();

            if (!string.IsNullOrEmpty(maGiayTamTru))
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa giấy tạm trú có mã [{maGiayTamTru}] này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string ketQua = giaytamtrubll.XoaGiayTamTru(maGiayTamTru);
                    MessageBox.Show(ketQua);
                    LoadData(); // cập nhật lại danh sách
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giấy tạm trú cần xóa.");
            }
        }

        private void btnthemanhnguoixincap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagiaytamtru.Text))
            {
                MessageBox.Show("Vui lòng chọn giấy tạm trú để thêm ảnh người xin cấp !", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh người thuê trọ";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes = File.ReadAllBytes(filePath);
                    string maGiayTamTru = txtmagiaytamtru.Text;

                    bool ketQua = giaytamtrubll.CapNhatAnhNguoixincapTamtru(maGiayTamTru, imageBytes);

                    if (ketQua)
                    {
                        MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                        pickhutro.Image = Image.FromStream(new MemoryStream(imageBytes)); // hiển thị ảnh ngay lập tức
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                    }
                }
            }
        }
        private void btnthemanhkhutro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmagiaytamtru.Text))
            {
                MessageBox.Show("Vui lòng chọn giấy tạm trú để thêm ảnh khu trọ người xin cấp đang tạm trú !", "Thông báo");
                return;
            }

            // Chọn ảnh từ File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh người thuê trọ";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes2 = File.ReadAllBytes(filePath);
                    string maGiayTamTru = txtmagiaytamtru.Text;

                    bool ketQua = giaytamtrubll.CapNhapAnhKhuTroTamTru(maGiayTamTru, imageBytes2);

                    if (ketQua)
                    {
                        MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                        pic2khutro.Image = Image.FromStream(new MemoryStream(imageBytes2)); // hiển thị ảnh ngay lập tức
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                    }
                }
            }
        }

        private void btntimkiemgiaytamtru_Click(object sender, EventArgs e)
        {
            txttimkiemgiaytamtru.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaGiayTamTru = txttimkiemgiaytamtru.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaGiayTamTru))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = giaytamtrubll.TimKiemGiayTamTru(MaGiayTamTru);

            if (ketQua.Count > 0)
            {
                dtvgiaytamtru.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoigiaytamtru_Click(object sender, EventArgs e)
        {
            txtmagiaytamtru.Text = "";
            txtmanguoithue.Text = "";
            txthoten.Text = "";
            txtgioitinh.Text = "";
            dtpngaysinh.Value = DateTime.Now;
            txtcccd.Text = "";
            txtquequan.Text = "";
            txtsodienthoai.Text = "";
            txtnoidi.Text = "";
            dtpngaybatdau.Value = DateTime.Now;
            dtpngayketthuc.Value = DateTime.Now;
            txtlydo.Text = "";
            txttrangthai.Text = "";
            txtmagiaytamtru.ReadOnly = false;

            // Nếu có DataGridView giấy tạm trú, làm mới luôn:
            dtvgiaytamtru.DataSource = null;
            dtvgiaytamtru.Rows.Clear();
            LoadData();
        }

        private void btnxuatdon_Click(object sender, EventArgs e)
        {
            if (dtvgiaytamtru.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtvgiaytamtru.SelectedRows[0];

                string maNguoiThue = row.Cells["MaNguoiThue"].Value.ToString();
                string hoTen = row.Cells["HoTen"].Value.ToString();
                string cccd = row.Cells["CCCD"].Value.ToString();
                string ngaySinh = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                string soDienThoai = row.Cells["SoDienThoai"].Value.ToString();
                string quequan = row.Cells["QueQuan"].Value.ToString();
                string ngaybatdau = Convert.ToDateTime(row.Cells["NgayBatDau"].Value).ToString("dd/MM/yyyy");
                string ngayketthuc = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value).ToString("dd/MM/yyyy");
                string lyDo = row.Cells["LyDo"].Value.ToString();
                string trangThai = row.Cells["TrangThai"].Value.ToString();
                int soNgay = Convert.ToInt32(row.Cells["SoNgay"].Value);
                string noitamtru = row.Cells["NoiTamTru"].Value.ToString();


                // Gọi form GiayTamVangForm với các thông tin
                DonGiayTamTru formGiayTamtru = new DonGiayTamTru(maNguoiThue, hoTen, cccd, ngaySinh, gioiTinh,
                    soDienThoai, quequan, ngaybatdau, ngayketthuc, lyDo, trangThai, soNgay,noitamtru);
                formGiayTamtru.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xuất giấy tạm vắng.");
            }
        }
    }
}
