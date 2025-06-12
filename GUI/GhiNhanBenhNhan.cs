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
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class GhiNhanBenhNhan : Form
    {
        private GhiNhanBenhNhanBLL ghinhanbenhnhanbll = new GhiNhanBenhNhanBLL();
        public GhiNhanBenhNhan()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void GhiNhanBenhNhan_Load(object sender, EventArgs e)
        {
            txttimkiemghinhanbenhnhan.ForeColor = Color.Gray;
            txttimkiemghinhanbenhnhan.Text = "Tìm kiếm theo mã bệnh nhân";

            txttimkiemghinhanbenhnhan.Enter += Txttimkiembenhnhan_Enter;
            txttimkiemghinhanbenhnhan.Leave += Txttimkiembenhnhan_Leave;
            btnthemghinhanbenhnhan.BackColor = Color.LightPink;
            btnsuaghinhanbenhnhan.BackColor = Color.LightPink;
            btnxoaghinhanbenhnhan.BackColor = Color.LightPink;
            btnlammoighinhanbenhnhan.BackColor = Color.LightPink;
            btnback1ghinhanbenhnhan.BackColor = Color.LightPink;
            btntimkiemghinhanbenhnhan.BackColor = Color.LightSeaGreen;
            pnlghinhanbenhnhan.BackColor = Color.LightPink;
            grbghinhanbenhnhan.BackColor = Color.AliceBlue;
            grb3ghinhanbenhnhan.BackColor = Color.AliceBlue;
            cbbthognkeghinhanbenhnhan.Items.Add("Thống kê bệnh nhân theo loại bệnh");
            cbbthognkeghinhanbenhnhan.Items.Add("Thống kê bệnh nhân theo tình trạng");
            cbbthognkeghinhanbenhnhan.SelectedIndexChanged += CmbThongKebenhnhan_SelectedIndexChanged;
            cbbthognkeghinhanbenhnhan.SelectedIndexChanged += CmbThongKebenhnhan2_SelectedIndexChanged;
            chart1.Visible = false;
            chart2.Visible = false;
            LoadData();
        }
        private void CmbThongKebenhnhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkeghinhanbenhnhan.SelectedItem.ToString() == "Thống kê bệnh nhân theo loại bệnh")
            {
                ThongKeBenhNhanTheoLoaiBenh();
                chart1.Visible = true;
            }
        }
        private void CmbThongKebenhnhan2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbthognkeghinhanbenhnhan.SelectedItem.ToString() == "Thống kê bệnh nhân theo tình trạng")
            {
                ThongKeBenhNhanTheoTinhTrang();
                chart2.Visible = true;
            }
        }
        private void ThongKeBenhNhanTheoTinhTrang()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeBenhNhanTheoTinhTrangDTO> thongKeList = ghinhanbenhnhanbll.ThongKeBenhNhanTheoTinhTrang();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị lên DataGridView
                dtvghinhanbenhnhan.DataSource = null;
                dtvghinhanbenhnhan.DataSource = thongKeList;

                // Xóa và cấu hình lại biểu đồ
                chart2.ChartAreas.Clear();
                chart2.Series.Clear();

                ChartArea chartArea = new ChartArea();
                chart2.ChartAreas.Add(chartArea);

                // Tạo biểu đồ tròn
                Series series = new Series
                {
                    Name = "Số lượng",
                    Color = System.Drawing.Color.Blue,
                    ChartType = SeriesChartType.Pie,
                    BorderWidth = 2
                };

                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.TrangThai, item.SoLuongBenhNhan);
                }

                chart2.Series.Add(series);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void ThongKeBenhNhanTheoLoaiBenh()
        {
            // Lấy dữ liệu từ BLL
            List<ThongKeBenhNhanTheoLoaiBenhDTO> thongKeList = ghinhanbenhnhanbll.ThongKeBenhNhanTheoLoaiBenh();

            if (thongKeList != null && thongKeList.Count > 0)
            {
                // Hiển thị lên DataGridView
                dtvghinhanbenhnhan.DataSource = null;
                dtvghinhanbenhnhan.DataSource = thongKeList;

                // Cấu hình biểu đồ cột
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                // Series cho biểu đồ cột
                Series series = new Series
                {
                    Name = "Số lượng bệnh nhân",
                    Color = System.Drawing.Color.Crimson,
                    ChartType = SeriesChartType.Column,
                    BorderWidth = 3
                };

                // Thêm dữ liệu vào series
                foreach (var item in thongKeList)
                {
                    series.Points.AddXY(item.TenBenh, item.SoLuongBenhNhan);
                }

                chart1.Series.Add(series);

                // Tùy chỉnh trục
                chartArea.AxisX.Title = "Tên bệnh";
                chartArea.AxisY.Title = "Số lượng bệnh nhân";
            }
            else
            {
                MessageBox.Show("Không có dữ liệu thống kê để hiển thị.", "Thông báo");
            }
        }
        private void Txttimkiembenhnhan_Enter(object sender, EventArgs e)
        {
            if (txttimkiemghinhanbenhnhan.Text == "Tìm kiếm theo mã bệnh nhân")
            {
                txttimkiemghinhanbenhnhan.Text = "";
                txttimkiemghinhanbenhnhan.ForeColor = Color.Black;
            }
        }

        private void Txttimkiembenhnhan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemghinhanbenhnhan.Text))
            {
                txttimkiemghinhanbenhnhan.Text = "Tìm kiếm theo mã bệnh nhân";
                txttimkiemghinhanbenhnhan.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<GhiNhanBenhNhanDTO> danhSach = ghinhanbenhnhanbll.LayDanhSachBenhNhan();
            dtvghinhanbenhnhan.DataSource = danhSach;
        }
        private void btnthemghinhanbenhnhan_Click(object sender, EventArgs e)
        {
            GhiNhanBenhNhanDTO bn = new GhiNhanBenhNhanDTO
            {
                MaBenhNhan = txtmabenhnhan.Text.Trim(),
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                NgaySinh = dtpngaysinh.Value.Date,
                GioiTinh = txtgioitinh.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                MaDichBenh = txtmadichbenh.Text.Trim(),
                TenBenh = txttenbenh.Text.Trim(),
                MucDoNghiemTrong = txtmucdonghiemtrong.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim(),
                MoTa = txtmota.Text.Trim(),
                DiaChi = txtdiachi.Text.Trim(),
            };
            string ketQua = ghinhanbenhnhanbll.ThemBenhNhan(bn);
            MessageBox.Show(ketQua);
            if (ketQua == "Thêm bệnh nhân thành công !.")
            {
                LoadData();
            }
        }


        private void btnback1ghinhanbenhnhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvghinhanbenhnhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvghinhanbenhnhan.Rows[e.RowIndex];

                txtmabenhnhan.Text = row.Cells["MaBenhNhan"].Value?.ToString();
                txtmanhankhau.Text = row.Cells["MaNhanKhau"].Value?.ToString();
                txthoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtcccd.Text = row.Cells["CCCD"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                {
                    dtpngaysinh.Value = ngaySinh;
                }

                txtgioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                txtsodienthoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtmadichbenh.Text = row.Cells["MaDichBenh"].Value?.ToString();
                txttenbenh.Text = row.Cells["TenBenh"].Value?.ToString();
                txtmucdonghiemtrong.Text = row.Cells["MucDoNghiemTrong"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmota.Text = row.Cells["MoTa"].Value?.ToString();
                txtmabenhnhan.ReadOnly = true;
                txtdiachi.Text = row.Cells["DiaChi"].Value?.ToString();
            }
        }

        private void btnsuaghinhanbenhnhan_Click(object sender, EventArgs e)
        {
            GhiNhanBenhNhanDTO bn = new GhiNhanBenhNhanDTO
            {
                MaBenhNhan = txtmabenhnhan.Text.Trim(),
                MaNhanKhau = txtmanhankhau.Text.Trim(),
                HoTen = txthoten.Text.Trim(),
                CCCD = txtcccd.Text.Trim(),
                NgaySinh = dtpngaysinh.Value.Date,
                GioiTinh = txtgioitinh.Text.Trim(),
                SoDienThoai = txtsodienthoai.Text.Trim(),
                MaDichBenh = txtmadichbenh.Text.Trim(),
                TenBenh = txttenbenh.Text.Trim(),
                MucDoNghiemTrong = txtmucdonghiemtrong.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim(),
                MoTa = txtmota.Text.Trim(),
                DiaChi = txtdiachi.Text.Trim(),
            };
            string ketQua = ghinhanbenhnhanbll.CapNhatBenhNhan(bn);
            MessageBox.Show(ketQua);
            if (ketQua == "Cập nhật bệnh nhân thành công.")
            {
                LoadData();
            }
        }

        private void btnxoaghinhanbenhnhan_Click(object sender, EventArgs e)
        {
            string maBenhNhan = txtmabenhnhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(maBenhNhan))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bệnh nhân có mã [{maBenhNhan}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = ghinhanbenhnhanbll.XoaBenhNhan(maBenhNhan);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa bệnh nhân thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btntimkiemghinhanbenhnhan_Click(object sender, EventArgs e)
        {
            txttimkiemghinhanbenhnhan.Focus(); // Đảm bảo text mới nhất được cập nhật
            string MaDich = txttimkiemghinhanbenhnhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaDich))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = ghinhanbenhnhanbll.TimKiemBenhNhan(MaDich);

            if (ketQua.Count > 0)
            {
                dtvghinhanbenhnhan.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnlammoighinhanbenhnhan_Click(object sender, EventArgs e)
        {
            txtmabenhnhan.Text = "";
            txtmadichbenh.Text = "";
            txtmanhankhau.Text = "";
            txthoten.Text = "";
            txtcccd.Text = "";
            dtpngaysinh.Value = DateTime.Now; // Reset ngày sinh về ngày hiện tại
            txtgioitinh.Text = "";
            txtsodienthoai.Text = "";
            txtdiachi.Text = "";
            txttrangthai.Text = "Đang Nhiễm Bệnh"; // Reset trạng thái mặc định
            txtmucdonghiemtrong.Text = "";
            txttenbenh.Text = "";
            txtmota.Text = "";
            txtmabenhnhan.ReadOnly = false;

            // Nếu có DataGridView bệnh nhân
            dtvghinhanbenhnhan.DataSource = null;
            dtvghinhanbenhnhan.Rows.Clear();
            LoadData();
        }
    }
}

