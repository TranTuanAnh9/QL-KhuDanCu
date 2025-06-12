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
    public partial class ChonBaiKhaoSat : Form
    {
        private int maUser; // nhận mã user từ form gọi
        private KhaoSatBLL khaoSatBLL; // đổi tên biến thành chữ thường đúng chuẩn C#

        public ChonBaiKhaoSat(int maUser)
        {
            InitializeComponent();
            this.maUser = maUser;
            this.khaoSatBLL = new KhaoSatBLL(); // ✅ KHỞI TẠO BLL
        }

        public ChonBaiKhaoSat()
        {
            InitializeComponent();
            this.khaoSatBLL = new KhaoSatBLL(); // ✅ cũng nên khởi tạo ở constructor này
        }

        private void ChonBaiKhaoSat_Load(object sender, EventArgs e)
        {
            LoadKhaoSat();
        }

        private void LoadKhaoSat()
        {
            flowLayoutPanel1.Controls.Clear();

            var danhSach = khaoSatBLL.LayDanhSachKhaoSatDaDang(); // ✅ sử dụng đối tượng đã khởi tạo
            foreach (var ks in danhSach)
            {
                Panel panelItem = new Panel
                {
                    Width = flowLayoutPanel1.ClientSize.Width - 20,
                    Height = 50,
                    Margin = new Padding(3),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblTrangThai = new Label
                {
                    Width = 100,
                    Dock = DockStyle.Left,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = khaoSatBLL.DaLamBaiKhaoSat(maUser, ks.MaKhaoSat) ? Color.Green : Color.Red,
                    Text = khaoSatBLL.DaLamBaiKhaoSat(maUser, ks.MaKhaoSat) ? "Đã làm" : "Chưa làm"
                };

                Label lblTieuDe = new Label
                {
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = ks.TieuDe,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                panelItem.Controls.Add(lblTieuDe);
                panelItem.Controls.Add(lblTrangThai);

                panelItem.Tag = ks;

                // Gán sự kiện click cho cả panel và các label con
                panelItem.Click += PanelItem_Click;
                lblTieuDe.Click += (s, e) => PanelItem_Click(panelItem, e);
                lblTrangThai.Click += (s, e) => PanelItem_Click(panelItem, e);

                flowLayoutPanel1.Controls.Add(panelItem);
            }
        }

        private void PanelItem_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is KhaoSatDTO ks)
            {
                // Kiểm tra đã làm chưa
                bool daLam = khaoSatBLL.DaLamBaiKhaoSat(maUser, ks.MaKhaoSat);
                if (daLam)
                {
                    MessageBox.Show("Bạn đã làm khảo sát này rồi. Không thể làm lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    LamBaiKhaoSat form = new LamBaiKhaoSat(this.maUser, ks.MaKhaoSat);
                    form.ShowDialog();
                    LoadKhaoSat(); // refresh lại trạng thái
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở bài khảo sát: " + ex.Message);
                }
            }
        }
    }
}

