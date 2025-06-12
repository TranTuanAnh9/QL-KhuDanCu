using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Novacode;
using System.IO;


namespace GUI
{
    public partial class DonSinhHoatCuocHop : Form
    {
        public DonSinhHoatCuocHop(
        string tenBuoi,
        string ngayToChuc,
        string diaDiem,
        string noiDung,
        string moTa,
        string nguoiToChuc,
        string soDienThoai,
        string trangThai)
        {
            InitializeComponent();

            // Gán lên các Label
            lbltenbuoisinhhoat.Text = tenBuoi;
            lblngaytochuc.Text = ngayToChuc;
            lbldiadiemtochuc.Text = diaDiem;
            lblnoidung.Text = noiDung;

            lblmota.Text = moTa;
            lblnguoitochuc.Text = nguoiToChuc;
            lblsodienthoainguoitochuc.Text = soDienThoai;
            lbltrangthai.Text = trangThai;
            lblnoidung.AutoSize = true;
            lblnoidung.MaximumSize = new Size(250, 0); // Chiều rộng cố định 400px, chiều cao tự giãn
            lblnoidung.TextAlign = ContentAlignment.TopLeft;
            lblnoidung.Text = noiDung;
            lblmota.MaximumSize = new Size(250, 0);
        }
        public DonSinhHoatCuocHop()
        {
            InitializeComponent();
        }

        private void DonSinhHoatCuocHop_Load(object sender, EventArgs e)
        {

        }

        private void btnxuatfileword_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Word Documents (*.docx)|*.docx";
                sfd.Title = "Chọn nơi lưu file Word";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string path = sfd.FileName;
                // Tạo document
                var doc = DocX.Create(path);

                // TIÊU ĐỀ
                doc.InsertParagraph("PHIẾU MỜI THAM DỰ CUỘC HỌP")
                   .FontSize(20).Bold().Alignment = Alignment.center;
                doc.InsertParagraph("Khu Dân Cư Phù Đồng")
                   .FontSize(14).Italic().Alignment = Alignment.center;
                doc.InsertParagraph("\n");

                // NỘI DUNG CHI TIẾT
                doc.InsertParagraph("Tên Buổi Sinh Hoạt:       " + lbltenbuoisinhhoat.Text);
                doc.InsertParagraph("Ngày Tổ Chức:            " + lblngaytochuc.Text);
                doc.InsertParagraph("Địa Điểm Tổ Chức:        " + lbldiadiemtochuc.Text);
                doc.InsertParagraph("Nội Dung Sinh Hoạt:      " + lblnoidung.Text);
                doc.InsertParagraph("\n");
                doc.InsertParagraph("Mô Tả:                   " + lblmota.Text);
                doc.InsertParagraph("Người Tổ Chức:           " + lblnguoitochuc.Text);
                doc.InsertParagraph("Số ĐT Người Tổ Chức:     " + lblsodienthoainguoitochuc.Text);
                doc.InsertParagraph("Trạng Thái Cuộc Họp:      " + lbltrangthai.Text);
                doc.InsertParagraph("\n");

                // CHỮ KÝ VÀ MÃ HỘ KHẨU
                doc.InsertParagraph("Chữ Ký Người Tổ Chức\t\t\t\t\tMã Hộ Khẩu & Chữ Ký Người Tham Gia");
                doc.InsertParagraph("\n\n\n\n\n\n");

                // GHI CHÚ CUỐI
                doc.InsertParagraph("Lưu ý: Mang theo giấy mời và CMND/CCCD để được xác nhận tham dự.")
                   .FontSize(10).Italic();

                // LƯU VÀ THÔNG BÁO
                try
                {
                    doc.Save();
                    MessageBox.Show("Xuất file Word thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                      "Không thể ghi file (có thể đang mở ở nơi khác).\n\n" + ex.Message,
                      "Lỗi ghi file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }   
    }
}
