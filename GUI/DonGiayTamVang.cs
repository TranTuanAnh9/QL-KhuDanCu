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

namespace GUI
{
    public partial class DonGiayTamVang : Form
    {
        public DonGiayTamVang(string maNhanKhau, string hoTen, string cccd, string ngaySinh,
                            string gioiTinh, string soDienThoai, string noiDi,
                            string ngayDi, string ngayVe, string lyDo, string trangThai, int soNgay)
        {
            InitializeComponent();
            lblmanhankhau.Text = maNhanKhau;
            lblhoten.Text = hoTen;
            lblcccd.Text = cccd;
            lblngaysinh.Text = ngaySinh;
            lblgioitinh.Text = gioiTinh;
            lblsodienthoai.Text = soDienThoai;
            lblnoidi.Text = noiDi;
            lblngaydi.Text = ngayDi;
            lblngayve.Text = ngayVe;
            lbllydo.Text = lyDo;
            lbltrangthai.Text = trangThai;
            lblsongay.Text = soNgay.ToString();
        }

        private void DonGiayTamVang_Load(object sender, EventArgs e)
        {

        }
        private void ExportGiayTamVangToWord()
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
                    doc.InsertParagraph("Giấy Tạm Vắng")
                        .FontSize(20).Bold().Alignment = Alignment.center;
                    doc.InsertParagraph("Khu Dân Cư Phù Đổng luxury")
                        .FontSize(14).Italic().Alignment = Alignment.center;
                    doc.InsertParagraph("\n");

                    // Nội dung giấy tạm vắng
                    doc.InsertParagraph("Mã Nhân Khẩu:\t\t" + lblmanhankhau.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Họ và tên:\t\t" + lblhoten.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("CCCD:\t\t\t" + lblcccd.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Ngày sinh:\t\t " + lblngaysinh.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Giới tính:\t\t" + lblgioitinh.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Số điện thoại:\t\t" + lblsodienthoai.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Nơi đi:\t\t\t" + lblnoidi.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Ngày đi:\t\t" + lblngaydi.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Ngày về:\t\t" + lblngayve.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Lý do tạm vắng:\t\t " + lbllydo.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Trạng thái:\t\t" + lbltrangthai.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Số ngày:\t\t" + lblsongay.Text);
                    doc.InsertParagraph("\n\n\n");

                    // Mục chữ ký và mã hộ khẩu
                    doc.InsertParagraph("Con Dấu Xác Nhận\t\t\t\t\tChữ Kí Người Cấp");
                    doc.InsertParagraph("\n\n\n\n");

                    doc.InsertParagraph("Ghi chú")
                    .FontSize(10).Italic();

                    // Lưu file
                    doc.Save();
                    MessageBox.Show("Xuất file Word thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnxuatfile_Click(object sender, EventArgs e)
        {
            ExportGiayTamVangToWord();
        }
    }
}
