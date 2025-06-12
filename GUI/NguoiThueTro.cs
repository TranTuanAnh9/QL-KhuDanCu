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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class NguoiThueTro : Form
    {
        private NguoiThueTroBLL nguoithuetrobll = new NguoiThueTroBLL();
        // Constructor có tham số — dùng khi truyền mã khu trọ từ chi tiết khu trọ
        public NguoiThueTro(string maKhuTro)
        {
            InitializeComponent();

            // Gán mã khu trọ vào textbox
            txtmakhutro.Text = maKhuTro;
            txtmakhutro.ReadOnly = false; // Nếu bạn không muốn cho sửa
        }
        public NguoiThueTro()
        {
            InitializeComponent();
        }
        private void NguoiThueTro_Load(object sender, EventArgs e)
        {
            txttimkiemnguoithuetro.ForeColor = Color.Gray;
            txttimkiemnguoithuetro.Text = "Tìm kiếm theo mã người thuê trọ";

            txttimkiemnguoithuetro.Enter += Txttimkiemnguoithuetro_Enter;
            txttimkiemnguoithuetro.Leave += Txttimkiemnguoithuetro_Leave;
            btnthemanhkhutronguoithue.BackColor = Color.LightSlateGray;
            btnthemanhnguoithuetro.BackColor = Color.LightSlateGray;
            btnthemnguoithuetro.BackColor = Color.LightSlateGray;
            btnsuanguoithuetro.BackColor = Color.LightSlateGray;
            btnxoanguoithuetro.BackColor = Color.LightSlateGray;
            btnlammoinguoithuetro.BackColor = Color.LightSlateGray;
            btnback1nguoithuetro.BackColor = Color.LightSlateGray;
            btntimkiemnguoithuetro.BackColor = Color.MintCream;
            pnlnguoithuetro.BackColor = Color.LightSlateGray;
            grbthongtinnhapvao.BackColor = Color.MintCream;
            grb3nguoithuetro.BackColor = Color.MintCream;
            cbbthognkenguoithuetro.SelectedIndexChanged += CmbThongKenguoithuetro1_SelectedIndexChanged;
            cbbthognkenguoithuetro.SelectedIndexChanged += CmbThongKenguoithuetro2_SelectedIndexChanged;
            cbbthognkenguoithuetro.SelectedIndexChanged += CmbThongKenguoithuetro3_SelectedIndexChanged;
            cbbthognkenguoithuetro.Items.Add("Thống kê người thuê trọ theo khu trọ");
            cbbthognkenguoithuetro.Items.Add("Thống kê người thuê trọ theo giới tính");
            cbbthognkenguoithuetro.Items.Add("Thống kê người thuê trọ theo độ tuổi");
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            LoadData();
        }
        private void CmbThongKenguoithuetro1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkenguoithuetro.SelectedItem.ToString() == "Thống kê người thuê trọ theo khu trọ")
            {
                ThongKeNguoiThueTheoKhuTro();
                chart1.Visible=true;
            }
        }
        private void CmbThongKenguoithuetro2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkenguoithuetro.SelectedItem.ToString() == "Thống kê người thuê trọ theo giới tính")
            {
                ThongKeNguoiThueTheoGioiTinh();
                chart2.Visible=true;
            }
        }
        private void CmbThongKenguoithuetro3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkenguoithuetro.SelectedItem.ToString() == "Thống kê người thuê trọ theo độ tuổi")
            {
                ThongKeNguoiThueTheoDoTuoi();
                chart3.Visible=true;
            }
        }
        private void ThongKeNguoiThueTheoDoTuoi()
        {
            List<ThongKeNguoiThueTheoDoTuoiDTO> thongKeList = nguoithuetrobll.ThongKeTheoDoTuoi();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị lên DataGridView
                dtvnguoithuetro.DataSource = null;
                dtvnguoithuetro.DataSource = thongKeList;

                // Reset chart
                chart3.Series.Clear();
                chart3.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chart3.ChartAreas.Add(chartArea);

                // Series kiểu cột
                Series series = new Series
                {
                    Name = "Số Người",
                    Color = Color.MediumSeaGreen,
                    ChartType = SeriesChartType.Column,
                    BorderWidth = 2
                };

                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.DoTuoi, item.SoLuong);
                }

                chart3.Series.Add(series);

                // Tuỳ chỉnh trục
                chartArea.AxisX.Title = "Độ Tuổi";
                chartArea.AxisY.Title = "Số Người Thuê";
                chartArea.AxisX.Interval = 1;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê độ tuổi.", "Thông báo");
            }
        }
        private void ThongKeNguoiThueTheoGioiTinh()
        {
            List<ThongKeNguoiThueTheoGioiTinhDTO> thongKeList = nguoithuetrobll.ThongKeTheoGioiTinh();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị DataGridView
                dtvnguoithuetro.DataSource = null;
                dtvnguoithuetro.DataSource = thongKeList;

                // Cấu hình biểu đồ
                chart2.Series.Clear();
                chart2.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chart2.ChartAreas.Add(chartArea);

                Series series = new Series
                {
                    Name = "GioiTinh",
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true
                };

                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.GioiTinh, item.SoLuong);
                }

                chart2.Series.Add(series);
                chart2.Titles.Clear();
                chart2.Titles.Add("Tỉ lệ người thuê theo giới tính");
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê giới tính.", "Thông báo");
            }
        }
        private void ThongKeNguoiThueTheoKhuTro()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeNguoiThueTheoKhuTroDTO> thongKeList = nguoithuetrobll.ThongKeTheoKhuTro();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị dữ liệu lên DataGridView
                dtvnguoithuetro.DataSource = null;
                dtvnguoithuetro.DataSource = thongKeList;

                // Cấu hình biểu đồ
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                // Tắt khoảng trắng đầu cuối trục X
                chartArea.AxisX.IsMarginVisible = false;

                // Series cho biểu đồ đường (line)
                Series series = new Series
                {
                    Name = "Số người thuê",
                    Color = Color.SteelBlue,
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8
                };

                // Thêm dữ liệu vào series
                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.MaKhuTro, item.SoLuongNguoiThue);
                }

                chart1.Series.Add(series);

                // Tùy chỉnh trục
                chartArea.AxisX.Title = "Mã Khu Trọ";
                chartArea.AxisY.Title = "Số Người Thuê";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void Txttimkiemnguoithuetro_Enter(object sender, EventArgs e)
        {
            if (txttimkiemnguoithuetro.Text == "Tìm kiếm theo mã người thuê trọ")
            {
                txttimkiemnguoithuetro.Text = "";
                txttimkiemnguoithuetro.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemnguoithuetro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemnguoithuetro.Text))
            {
                txttimkiemnguoithuetro.Text = "Tìm kiếm theo mã người thuê trọ";
                txttimkiemnguoithuetro.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<NguoiThueTroDTO> danhSach = nguoithuetrobll.LayDanhSachNguoiThueTro();
            dtvnguoithuetro.DataSource = danhSach;
              dtvnguoithuetro.Columns["AnhDinhKem6"].Visible = false;
            dtvnguoithuetro.Columns["AnhDinhKem7"].Visible = false;
        }

        private void btnthemnguoithuetro_Click(object sender, EventArgs e)
        {

            NguoiThueTroDTO nt = new NguoiThueTroDTO
            {
                MaNguoiThue = txtmanguoithue.Text.Trim(),
                MaKhuTro = txtmakhutro.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                GioiTinh = txtgioitinh.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                SoDienThoai = txtsdt.Text.Trim(),
                Email = txtemail.Text.Trim(),
                QueQuan = txtquequan.Text.Trim(),
                NgayBatDauThue = dtpgaybatdau.Value,
                SoPhong = txtsophong.Text.Trim()
            };

            string result = nguoithuetrobll.ThemNguoiThueTro(nt);
            MessageBox.Show(result);
            if (result == "Thêm người thuê trọ thành công!.")
            {
                LoadData();
            }
        }

        private void btnback1nguoithuetro_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dtvnguoithuetro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvnguoithuetro.Rows[e.RowIndex];

                txtmanguoithue.Text = row.Cells["MaNguoiThue"].Value?.ToString();
                txtmakhutro.Text = row.Cells["MaKhuTro"].Value?.ToString();
                txthoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtgioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtcccd.Text = row.Cells["CCCD"].Value?.ToString();
                txtsdt.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtemail.Text = row.Cells["Email"].Value?.ToString();
                txtquequan.Text = row.Cells["QueQuan"].Value?.ToString();
                txtsophong.Text = row.Cells["SoPhong"].Value?.ToString();
                txtmanguoithue.ReadOnly = true;

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaysinh))
                {
                    dtpngaysinh.Value = ngaysinh;
                }

                if (DateTime.TryParse(row.Cells["NgayBatDauThue"].Value?.ToString(), out DateTime ngaybatdau))
                {
                    dtpgaybatdau.Value = ngaybatdau;
                }
                string maNguoiThueTro = txtmanguoithue.Text;
                byte[] imageBytes = nguoithuetrobll.LayAnhNguoiThueTro(maNguoiThueTro);
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picnguoithuetro.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picnguoithuetro.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }

                byte[] imageBytes2 = nguoithuetrobll.LayAnhNhaKhuTro(maNguoiThueTro);
                if (imageBytes2 != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes2))
                    {
                        pic2nguoithuetro.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pic2nguoithuetro.Image = null; // Nếu không có ảnh, xóa ảnh trong PictureBox
                }
            }
        }

        private void btnsuanguoithuetro_Click(object sender, EventArgs e)
        {
            NguoiThueTroDTO dto = new NguoiThueTroDTO
            {
                MaNguoiThue = txtmanguoithue.Text.Trim(),
                MaKhuTro = txtmakhutro.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                NgaySinh = dtpngaysinh.Value,
                GioiTinh = txtgioitinh.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                SoDienThoai = txtsdt.Text.Trim(),
                Email = txtemail.Text.Trim(),
                QueQuan = txtquequan.Text.Trim(),
                NgayBatDauThue = dtpgaybatdau.Value,
                SoPhong = txtsophong.Text.Trim()
            };

            string ketQua = nguoithuetrobll.SuaNguoiThue(dto);
            MessageBox.Show(ketQua);

            if (ketQua == "Cập nhật người thuê trọ thành công!")
            {
                LoadData();
            }

        }

        private void btnxoanguoithuetro_Click(object sender, EventArgs e)
        {
            string maNguoiThueTro = txtmanguoithue.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNguoiThueTro))
            {
                MessageBox.Show("Vui lòng chọn người thuê trọ cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa người thuê trọ có mã [{maNguoiThueTro}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = nguoithuetrobll.XoaNguoiThueTro(maNguoiThueTro);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa người thuê trọ thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btnthemanhnguoithuetro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanguoithue.Text))
            {
                MessageBox.Show("Vui lòng chọn người thuê trọ để thêm ảnh !", "Thông báo");
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
                    string maNguoiThueTro = txtmanguoithue.Text;

                    bool ketQua = nguoithuetrobll.CapNhatAnhNguoiThueTro(maNguoiThueTro, imageBytes);

                    if (ketQua)
                    {
                        MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                        picnguoithuetro.Image = Image.FromStream(new MemoryStream(imageBytes)); // hiển thị ảnh ngay lập tức
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                    }
                }
            }
        }

        private void btnthemanhkhutronguoithue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmanguoithue.Text))
            {
                MessageBox.Show("Vui lòng chọn người thuê trọ để thêm ảnh khu trọ mà người đó đang tạm trú !", "Thông báo");
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
                    string maNguoiThueTro = txtmanguoithue.Text;

                    bool ketQua = nguoithuetrobll.CapNhatAnhKhuTro(maNguoiThueTro, imageBytes2);

                    if (ketQua)
                    {
                        MessageBox.Show("Thêm ảnh thành công!", "Thông báo");
                        pic2nguoithuetro.Image = Image.FromStream(new MemoryStream(imageBytes2)); // hiển thị ảnh ngay lập tức
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại!", "Thông báo");
                    }
                }
            }
        }
        private void btntimkiemnguoithuetro_Click(object sender, EventArgs e)
        {
            txttimkiemnguoithuetro.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaNguoiThueTro = txttimkiemnguoithuetro.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaNguoiThueTro))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = nguoithuetrobll.TimKiemNguoiThueTro(MaNguoiThueTro);

            if (ketQua.Count > 0)
            {
                dtvnguoithuetro.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoinguoithuetro_Click(object sender, EventArgs e)
        {
            txtmanguoithue.Text = "";
            txthoten.Text = "";
            dtpngaysinh.Value = DateTime.Now;
            txtgioitinh.Text = "";
            txtcccd.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtquequan.Text = "";
            dtpgaybatdau.Value = DateTime.Now;
            txtmakhutro.Text = "";
            txtsophong.Text = "";
            txtmanguoithue.ReadOnly = false;

            // Nếu có DataGridView người thuê trọ, làm mới luôn:
            dtvnguoithuetro.DataSource = null;
            dtvnguoithuetro.Rows.Clear();
            LoadData();
        }
    }
}
