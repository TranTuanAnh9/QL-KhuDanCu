using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Novacode;

namespace GUI
{
    public partial class DonPhongChongDich : Form
    {
        public DonPhongChongDich(string tenDich, string ngayBungPhat, string mucDoNguyHiem, string noiBungPhat, string moTa, string trangThai)
        {
            InitializeComponent();

            lbltendich.Text = tenDich;
            lblngaybungphat.Text = ngayBungPhat;
            lblmucdonguyhiem.Text = mucDoNguyHiem;
            lblnoibungphat.Text = noiBungPhat;
            lblmota.Text = moTa;
            lbltrangthai.Text = trangThai;
            lblmota.AutoSize = true;
            lblmota.MaximumSize = new Size(250, 0); // Chiều rộng cố định 400px, chiều cao tự giãn
            lblmota.TextAlign = ContentAlignment.TopLeft;
            lblmota.Text = moTa;
        }

        public DonPhongChongDich()
        {
            InitializeComponent();
        }

        private void DonPhongChongDich_Load(object sender, EventArgs e)
        {

        }

        private void btninfilewwor_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Word Documents (*.docx)|*.docx";
                sfd.Title = "Chọn nơi lưu file Word";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string path = sfd.FileName;
                var doc = Novacode.DocX.Create(path);

                // 1. Tiêu đề
                doc.InsertParagraph("Thông Tin Đơn Phòng Chống Dịch")
                    .FontSize(20).Bold().Alignment = Novacode.Alignment.center;
                doc.InsertParagraph("Khu Dân Cư Phù Đổng Luxury")
                    .FontSize(14).Italic().Alignment = Novacode.Alignment.center;
                doc.InsertParagraph("\n");

                // 2. Thông tin chính
                doc.InsertParagraph("Tên Dịch Bệnh: " + lbltendich.Text);
                doc.InsertParagraph("\n");
                doc.InsertParagraph("Ngày Bùng Phát: " + lblngaybungphat.Text);
                doc.InsertParagraph("\n");
                doc.InsertParagraph("Mức Độ Nguy Hiểm: " + lblmucdonguyhiem.Text);
                doc.InsertParagraph("\n");
                doc.InsertParagraph("Nơi Bùng Phát: " + lblnoibungphat.Text);
                doc.InsertParagraph("\n");
                doc.InsertParagraph("Mô Tả: " + lblmota.Text);
                doc.InsertParagraph("\n");
                doc.InsertParagraph("Trạng Thái: " + lbltrangthai.Text);
                doc.InsertParagraph("\n\n");

                // 3. Chữ ký
                doc.InsertParagraph("Chữ Kĩ Và Họ Tên Người Ban Bố Đơn Phòng Tránh Bệnh\t\t\tCon Dấu Uỷ Ban");
                doc.InsertParagraph("\n\n\n\n\n\n\n");

                // 4. Ghi chú
                doc.InsertParagraph("Ghi chú: Mỗi trường hợp cần được theo dõi và báo cáo theo chỉ đạo của cán bộ y tế.")
                    .FontSize(10).Italic();

                // 5. Lưu
                try
                {
                    doc.Save();
                    MessageBox.Show("Xuất file Word thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file Word: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
