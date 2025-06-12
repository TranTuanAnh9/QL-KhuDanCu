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

namespace GUI
{
    public partial class ChonTinNhan : Form
    {
        private string tenDangNhap;
        private ThongBaoBLL thongBaoBLL = new ThongBaoBLL();
        public ChonTinNhan(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }
        private void ChonTinNhan_Load(object sender, EventArgs e)
        {
            LoadThongBao();
        }
        private void LoadThongBao()
        {
            flowLayoutPanel1.Controls.Clear();

            var danhSach = thongBaoBLL.LayThongBaoTheoNguoiNhan(tenDangNhap);
            foreach (var tb in danhSach)
            {
                bool daXem = thongBaoBLL.KiemTraDaXem(tb.MaThongBao, tenDangNhap);

                Panel panelItem = new Panel
                {
                    Width = flowLayoutPanel1.ClientSize.Width - 20,
                    Height = 50,
                    Margin = new Padding(3),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = daXem ? Color.White : Color.LightYellow // Màu nổi bật cho chưa xem
                };

                Label lblTrangThai = new Label
                {
                    Text = daXem ? "Đã xem" : "Chưa xem",
                    Width = 100,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ForeColor = daXem ? Color.Gray : Color.Red,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    Location = new Point(10, 15)
                };

                Label lblTieuDe = new Label
                {
                    Text = tb.TieuDe,
                    AutoSize = false,
                    Width = panelItem.Width - 130,
                    Location = new Point(110, 15),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    ForeColor = Color.Black
                };

                panelItem.Controls.Add(lblTrangThai);
                panelItem.Controls.Add(lblTieuDe);
                panelItem.Tag = tb;

                panelItem.Click += PanelThongBao_Click;
                lblTieuDe.Click += (s, e) => PanelThongBao_Click(panelItem, e);
                lblTrangThai.Click += (s, e) => PanelThongBao_Click(panelItem, e);

                flowLayoutPanel1.Controls.Add(panelItem);
            }
        }
        private void PanelThongBao_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is ThongBaoDTO tb)
            {
                MessageBox.Show(tb.NoiDung, "Nội dung thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!thongBaoBLL.KiemTraDaXem(tb.MaThongBao, tenDangNhap))
                {
                    thongBaoBLL.CapNhatDaXem(tb.MaThongBao, tenDangNhap);
                    LoadThongBao(); // refresh lại UI
                }
            }
        }
    }
}
