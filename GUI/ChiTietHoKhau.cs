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
    public partial class ChiTietHoKhau : Form
    {
        private readonly HoKhauDTO _hokhau;
        public ChiTietHoKhau(HoKhauDTO hokhau)
        {
            _hokhau = hokhau;
            InitializeComponent();
            lbldiachi.MaximumSize = new Size(100, 0); // Chiều rộng cố định 400px, chiều cao tự giãn
            lbldiachi.TextAlign = ContentAlignment.TopLeft;
            lbldiachi.Text = _hokhau.DiaChi;
            lbldiachi.MaximumSize = new Size(250, 0);
        }

        private void ChiTietHoKhau_Load(object sender, EventArgs e)
        {
            // Gán dữ liệu lên các controls
            lblmahokhau.Text = _hokhau.MaHoKhau;
            lbltenchuho.Text = _hokhau.TenChuHo;
            lbldiachi.Text = _hokhau.DiaChi;
            lblsothanhvien.Text = _hokhau.SoThanhVien.ToString();
            lblcccdchuho.Text = _hokhau.CCCDChuHo;
            lbltrangthai.Text = _hokhau.TrangThai;
            lblmota.Text = _hokhau.MoTa;
            lblngaylap.Text = _hokhau.NgayLap.ToString();


            if (_hokhau.AnhDinhKem != null)
            {
                using (var ms = new MemoryStream(_hokhau.AnhDinhKem))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnthemnhankhau1_Click(object sender, EventArgs e)
        {

            NhanKhau frm = new NhanKhau(_hokhau.MaHoKhau);
            frm.ShowDialog();
        }
    }
}
