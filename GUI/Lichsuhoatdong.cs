using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Lichsuhoatdong : Form
    {
        private LichsuhoatdongBLL LichsuhoatdongBLL = new LichsuhoatdongBLL();
        public Lichsuhoatdong()
        {
            InitializeComponent();
        }
        private void Lichsuhoatdong_Load(object sender, EventArgs e)
        {
            LoadData();
            panel1.BackColor = Color.MistyRose;
        }
        private void LoadData()
        {
            List<LichsuhoatdongDTO> danhSach = LichsuhoatdongBLL.LayDanhSachLichSu();
            dataGridView1.DataSource = danhSach;

            // Tự động điều chỉnh độ rộng cột theo nội dung
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tự động điều chỉnh chiều cao hàng để hiển thị nội dung nhiều dòng
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Nếu muốn cụ thể chỉ với cột "NoiDung" và "HanhDong"
            // thì dùng tên thuộc tính đúng như trong DTO (viết hoa/thường chuẩn):
            dataGridView1.Columns["NoiDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["HanhDong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime ngayChon = dateTimePicker1.Value.Date;

            // Gọi BLL để lấy danh sách đã lọc
            List<LichsuhoatdongDTO> danhSachLoc = LichsuhoatdongBLL.LayLichSuTheoNgay(ngayChon);

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = danhSachLoc;

            // Cập nhật lại hiển thị cho đẹp (nếu muốn)
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns["NoiDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["HanhDong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
