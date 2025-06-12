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
    public partial class ChiTietKhuTro : Form
    {
        private readonly KhuTroDTO _khuTro;
        public ChiTietKhuTro(KhuTroDTO khuTro)
        {
            _khuTro = khuTro;
            InitializeComponent();
            lbldiachi.MaximumSize = new Size(100, 0); // Chiều rộng cố định 400px, chiều cao tự giãn
            lbldiachi.TextAlign = ContentAlignment.TopLeft;
            lbldiachi.Text = _khuTro.DiaChi;
            lbldiachi.MaximumSize = new Size(250, 0);


        }
        private void ChiTietKhuTro_Load(object sender, EventArgs e)
        {
            // Gán dữ liệu lên các controls
            lblmakhutro.Text = _khuTro.MaKhuTro;
            lbltenkhutro.Text = _khuTro.TenKhuTro;
            lbldiachi.Text = _khuTro.DiaChi;
            lblhotenchutro.Text = _khuTro.HoTenChuTro;
            lblsodienthoaichutro.Text = _khuTro.SoDienThoaiChuTro;
            lblsophong.Text = _khuTro.SoPhong.ToString();
            lblsophongtrong.Text = _khuTro.SoPhongTrong.ToString();
            lblmanhankhau.Text = _khuTro.MaNhanKhau;
            lbltrangthai.Text = _khuTro.TrangThai;


            if (_khuTro.AnhDinhKem8 != null)
            {
                using (var ms = new MemoryStream(_khuTro.AnhDinhKem8))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }
        private void btnthemnguoithuetro_Click(object sender, EventArgs e)
        {
            NguoiThueTro frm = new NguoiThueTro(_khuTro.MaKhuTro);
            frm.ShowDialog();
        }
    }
}
