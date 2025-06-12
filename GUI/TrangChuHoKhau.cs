using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TrangChuHoKhau : Form
    {
        private readonly HoKhauBLL _hokhauBll;
        public TrangChuHoKhau()
        {
            InitializeComponent();
            _hokhauBll = new HoKhauBLL();
        }

        private void TrangChuHoKhau_Load(object sender, EventArgs e)
        {
            LoadHoKhauCards();
            panel1.BackColor = Color.LightSteelBlue;
            panel2.BackColor = Color.LightSteelBlue;
            btnback.FlatStyle = FlatStyle.Flat;
            btnback.FlatAppearance.BorderSize = 0;
            btnback.BackColor = Color.White;
            btnback.ForeColor = Color.LightSteelBlue;
            btnqlhokhau.FlatStyle = FlatStyle.Flat;
            btnqlhokhau.FlatAppearance.BorderSize = 0;
            btnqlhokhau.BackColor = Color.White;
            btnqlhokhau.ForeColor = Color.LightSteelBlue;
        }
        private void LoadHoKhauCards()
        {
            flowLayoutPanel1.Controls.Clear();

            List<HoKhauDTO> ds = _hokhauBll.LayDanhSachHoKhau();

            foreach (var hk in ds)
            {
                var pnl = new Panel
                {
                    Width = 180,
                    Height = 260, // Tăng chiều cao nếu cần
                    Margin = new Padding(8),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // 1) Ảnh
                var pic = new PictureBox
                {
                    Width = pnl.Width - 4,
                    Height = 120,
                    Location = new Point(2, 2),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.None
                };
                if (hk.AnhDinhKem != null && hk.AnhDinhKem.Length > 0)
                {
                    using (var ms = new MemoryStream(hk.AnhDinhKem))
                        pic.Image = Image.FromStream(ms);
                }
                else
                {
                    pic.BackColor = Color.LightGray;
                }
                pnl.Controls.Add(pic);
                int currentY = pic.Bottom + 4;

                // 2) Mã hộ khẩu
                var lblmahokhau = new Label
                {
                    Text = hk.MaHoKhau,
                    AutoSize = false,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    MaximumSize = new Size(pnl.Width - 4, 0),
                    Width = pnl.Width - 4,
                    Location = new Point(2, currentY),
                    TextAlign = ContentAlignment.TopCenter
                };
                var measured = TextRenderer.MeasureText(
                    lblmahokhau.Text,
                    lblmahokhau.Font,
                    new Size(lblmahokhau.MaximumSize.Width, int.MaxValue),
                    TextFormatFlags.WordBreak
                );
                lblmahokhau.Height = measured.Height;
                pnl.Controls.Add(lblmahokhau);
                currentY = lblmahokhau.Bottom + 4;

                // 4) Tên chủ hộ
                var lbltenchuho = new Label
                {
                    Text = " Tên chủ hộ: " + hk.TenChuHo,
                    AutoSize = false,
                    Width = pnl.Width - 10,
                    Height = 18,
                    Location = new Point(5, currentY)
                };
                pnl.Controls.Add(lbltenchuho);
                currentY = lbltenchuho.Bottom + 6;

                // 3) CCCD chủ hộ
                var lblcccdchuho = new Label
                {
                    Text = "CCCD chủ hộ: " + hk.CCCDChuHo,
                    AutoSize = false,
                    Width = pnl.Width - 10,
                    Height = 18,
                    Location = new Point(5, currentY)
                };
                pnl.Controls.Add(lblcccdchuho);
                currentY = lblcccdchuho.Bottom + 4;


                // 5) Nút Xem thông tin
                var btn = new Button
                {
                    Text = "Xem thông tin",
                    Width = pnl.Width - 20,
                    Height = 30,
                    Location = new Point(10, currentY)
                };
                btn.BackColor = Color.LightGreen;
                pnl.Controls.Add(btn);

                btn.Click += (s, e) =>
                {
                    var chiTietForm = new ChiTietHoKhau(hk);
                    chiTietForm.ShowDialog();
                };

                flowLayoutPanel1.Controls.Add(pnl);
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trangchu trangchu = new Trangchu();
            trangchu.ShowDialog();
        }
        private void btnqlhokhau_Click(object sender, EventArgs e)
        {
            this.Close();
            HoKhau hoKhau = new HoKhau();   
            hoKhau.ShowDialog();
        }
    }
}
