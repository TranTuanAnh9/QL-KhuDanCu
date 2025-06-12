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

namespace GUI
{
    public partial class TrangChuKhuTro : Form
    {
        private readonly KhuTroBLL _khuTroBll;
        public TrangChuKhuTro()
        {
            InitializeComponent();
            _khuTroBll = new KhuTroBLL();
        }

        private void TrangChuKhuTro_Load(object sender, EventArgs e)
        {
            LoadKhuTroCards();
            panel1.BackColor = Color.LightSteelBlue;
            panel2.BackColor = Color.LightSteelBlue;
            btnback.FlatStyle = FlatStyle.Flat;
            btnback.FlatAppearance.BorderSize = 0;
            btnback.BackColor = Color.White;
            btnback.ForeColor = Color.LightSteelBlue;
            btnqlkhutro.FlatStyle = FlatStyle.Flat;
            btnqlkhutro.FlatAppearance.BorderSize = 0;
            btnqlkhutro.BackColor = Color.White;
            btnqlkhutro.ForeColor = Color.LightSteelBlue;
        }
        private void LoadKhuTroCards()
        {
            flowLayoutPanel1.Controls.Clear();

            // Lấy danh sách KhuTro
            List<KhuTroDTO> ds = _khuTroBll.LayDanhSachKhuTro();

            foreach (var kt in ds)
            {
                // Panel làm "card"
                var pnl = new Panel
                {
                    Width = 180,
                    Height = 220,
                    Margin = new Padding(8),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // PictureBox ảnh
                var pic = new PictureBox
                {
                    Width = pnl.Width - 4,
                    Height = 120,
                    Location = new Point(2, 2),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.None
                };
                if (kt.AnhDinhKem8 != null && kt.AnhDinhKem8.Length > 0)
                {
                    using (var ms = new MemoryStream(kt.AnhDinhKem8))
                        pic.Image = Image.FromStream(ms);
                }
                else
                {
                    pic.BackColor = Color.LightGray;
                }

                pnl.Controls.Add(pic);
                // Tính vị trí Y tiếp theo
                int currentY = pic.Bottom + 4;

                // 2) Tên (word-wrap)
                var lblTen = new Label
                {
                    Text = kt.TenKhuTro,
                    AutoSize = false,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    MaximumSize = new Size(pnl.Width - 4, 0),
                    Width = pnl.Width - 4,
                    Location = new Point(2, currentY),
                    TextAlign = ContentAlignment.TopCenter
                };
                var measured = TextRenderer.MeasureText(
                    lblTen.Text,
                    lblTen.Font,
                    new Size(lblTen.MaximumSize.Width, int.MaxValue),
                    TextFormatFlags.WordBreak
                );
                lblTen.Height = measured.Height;
                pnl.Controls.Add(lblTen);

                // Cập nhật vị trí Y
                currentY = lblTen.Bottom + 4;

                // 3) Trạng thái
                var lblTrangThai = new Label
                {
                    Text = kt.SoPhongTrong > 0 ? "Còn phòng" : "Đã hết phòng",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8),
                    Width = pnl.Width - 4,
                    Height = 20,
                    Location = new Point(2, currentY),
                    ForeColor = kt.SoPhongTrong > 0 ? Color.Green : Color.Gray
                };
                pnl.Controls.Add(lblTrangThai);

                // Cập nhật vị trí Y
                currentY = lblTrangThai.Bottom + 8;

                // Nút Xem thông tin (chưa gán click)
                var btn = new Button
                {
                    Text = "Xem thông tin",
                    Width = pnl.Width - 20,
                    Height = 30,
                    Location = new Point(10, 180),
                    Enabled = kt.SoPhongTrong > 0
                };
                // Đổi màu theo tình trạng
                btn.BackColor = kt.SoPhongTrong > 0
                    ? Color.LightGreen
                    : Color.LightGray;

                pnl.Controls.Add(btn);
                // Gán sự kiện Click để mở form chi tiết
                btn.Click += (s, e) =>
                {
                    var chiTietForm = new ChiTietKhuTro(kt);
                    chiTietForm.ShowDialog();
                };

                // 4) Cuối cùng, set chiều cao panel để chứa hết nội dung
                pnl.Height = btn.Bottom + 6;

                flowLayoutPanel1.Controls.Add(pnl);


            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trangchu trangchu = new Trangchu();
            trangchu.ShowDialog();
        }

        private void btnqlkhutro_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhuTro khuTro = new KhuTro();
            khuTro.ShowDialog();
        }
    }
}
