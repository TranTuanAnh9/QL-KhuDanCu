using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DonGiayTamTru : Form
    {
        public DonGiayTamTru(string maNguoiThue, string hoTen, string cccd, string ngaySinh,
                            string gioiTinh, string soDienThoai, string quequan,
                            string ngaybatdau, string ngayketthuc, string lyDo, string trangThai, int soNgay,string noitamtru)
        {
            InitializeComponent();
            lblmanguoithue.Text = maNguoiThue;
            lblhoten.Text = hoTen;
            lblcccd.Text = cccd;
            lblngaysinh.Text = ngaySinh;
            lblgioitinh.Text = gioiTinh;
            lblsodienthoai.Text = soDienThoai;
            lblquequan.Text = quequan;
            lblngaybatdau.Text = ngaybatdau;
            lblngayketthuc.Text = ngayketthuc;
            lbllydo.Text = lyDo;
            lbltrangthai.Text = trangThai;
            lblsongay.Text = soNgay.ToString();
            lblnoitamtru.Text = noitamtru;
        }

        private void DonGiayTamTru_Load(object sender, EventArgs e)
        {

        }
        private void ExportGiayTamTruToWord()
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
                    doc.InsertParagraph("Thông Tin Giấy Tạm Trú")
                        .FontSize(20).Bold().Alignment = Alignment.center;
                    doc.InsertParagraph("Khu Dân Cư Phù Đổng luxury")
                        .FontSize(14).Italic().Alignment = Alignment.center;
                    doc.InsertParagraph("\n");

                    // Nội dung giấy tạm vắng
                    doc.InsertParagraph("Mã Người Thuê:\t" + lblmanguoithue.Text + "\t\t\tNgày sinh:\t\t " + lblngaysinh.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Họ và tên:\t\t" + lblhoten.Text + "\t\tGiới tính:\t\t" + lblgioitinh.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("CCCD:\t\t\t" + lblcccd.Text + "\t\tSố điện thoại:\t\t" + lblsodienthoai.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Quê Quán:\t\t" + lblquequan.Text + "\t\tLý do tạm trú ở đây:\t " + lbllydo.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Ngày bắt đầu:\t\t" + lblngaybatdau.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Ngày kết thúc:\t\t" + lblngayketthuc.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Nơi tạm trú:\t\t" + lblnoitamtru.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Trạng thái:\t\t" + lbltrangthai.Text);
                    doc.InsertParagraph("\n");
                    doc.InsertParagraph("Số ngày:\t\t" + lblsongay.Text);
                    doc.InsertParagraph("\n\n\n");

                    // Mục chữ ký và mã hộ khẩu
                    doc.InsertParagraph("Con Dấu Xác Nhận\t\t\t\t\tChữ Kí Người Cấp");
                    doc.InsertParagraph("\n\n\n\n\n\n");

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
            ExportGiayTamTruToWord();
        }
    }
}
