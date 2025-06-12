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
    public partial class DonThuPhiDongGop : Form
    {
        public DonThuPhiDongGop(string tenKhoanThu, string hanDong, string soTien, string lyDo)
        {
            InitializeComponent();

            // Gán dữ liệu vào các label
            lbltenkhoanthu.Text = tenKhoanThu;
            lblhandong.Text = hanDong;
            lblsotien.Text = soTien;
            lbllydothu.AutoSize = true;
            lbllydothu.MaximumSize = new Size(300, 0); // Chiều rộng cố định 400px, chiều cao tự giãn
            lbllydothu.TextAlign = ContentAlignment.TopLeft;
            lbllydothu.Text = lyDo;
        }

        public DonThuPhiDongGop()
        {
            InitializeComponent();
        }


        private void DonThuPhiDongGop_Load(object sender, EventArgs e)
        {
        }

        private void btnxuatwword_Click(object sender, EventArgs e)
        {
            XuatThongTinDonThuRaWord();
        }
        private void XuatThongTinDonThuRaWord()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveFileDialog.Title = "Chọn nơi lưu file Word";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;

                    // Tạo tài liệu Word
                    var doc = DocX.Create(path);

                    // Tiêu đề
                    doc.InsertParagraph("Thông Tin Đơn Khoản Thu")
                        .FontSize(20).Bold().Alignment = Alignment.center;
                    doc.InsertParagraph("Khu Dân Cư Phù Đổng")
                        .FontSize(14).Italic().Alignment = Alignment.center;
                    doc.InsertParagraph("\n");

                    // Nội dung chính
                    doc.InsertParagraph("Tên Khoản Thu: " + lbltenkhoanthu.Text);
                    doc.InsertParagraph("Hạn Đóng: " + lblhandong.Text);
                    doc.InsertParagraph("Số Tiền: " + lblsotien.Text);
                    doc.InsertParagraph("Lý Do Thu: " + lbllydothu.Text);
                    doc.InsertParagraph("\n");

                    // Hình thức thanh toán với checkbox
                    string checkboxTrucTiep = ckctructiep.Checked ? "[x] Trực Tiếp" : "[ ] Trực Tiếp";
                    string checkboxChuyenKhoan = ckcchuyenkhoan.Checked ? "[x] Chuyển Khoản" : "[ ] Chuyển Khoản";
                    doc.InsertParagraph("Hình Thức Thanh Toán:");
                    doc.InsertParagraph(checkboxTrucTiep);
                    doc.InsertParagraph(checkboxChuyenKhoan);
                    doc.InsertParagraph("\n");

                    // Mục chữ ký và mã hộ khẩu
                    doc.InsertParagraph("Chữ Ký Người Đóng\t\t\tMã Hộ Khẩu");

                    // Chèn ảnh QR từ PictureBox
                    if (pictureBox1.Image != null)
                    {
                        try
                        {
                            string tempPath = Path.Combine(Application.StartupPath, "qr_temp.png");
                            pictureBox1.Image.Save(tempPath);

                            var img = doc.AddImage(tempPath);
                            var pic = img.CreatePicture(100, 100);
                            doc.InsertParagraph().AppendPicture(pic);

                            File.Delete(tempPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi chèn ảnh QR: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không có ảnh QR để chèn vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    doc.InsertParagraph("\n"); // thêm dòng trống cho thoáng
                    doc.InsertParagraph("Cần phải ghi mã hộ khẩu vào để đánh dấu là đã đóng")
                        .FontSize(10).Italic();
                    // Lưu file

                        doc.Save();
                        MessageBox.Show("Xuất file Word thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
