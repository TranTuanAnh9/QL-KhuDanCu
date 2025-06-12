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
    public partial class LoiNhan : Form
    {
        NhanKhauBLL NhanKhauBLL = new NhanKhauBLL();
        ThongBaoBLL thongBaoBLL = new ThongBaoBLL();
        public LoiNhan()
        {
            InitializeComponent();
        }

        private void LoiNhan_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Azure;
            btnthem.BackColor = Color.LemonChiffon;
            btntimkiem.BackColor = Color.LemonChiffon;
            btnxoa.BackColor = Color.LemonChiffon;
            btngui.BackColor = Color.LightCoral;
            txtloinhan.Height = 100;
            dgvdanhsach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvdanhsach.MultiSelect = true;
            // Thêm 2 lựa chọn vào ComboBox
            cbbdoituong.Items.Add("Tất cả");
            cbbdoituong.Items.Add("Tùy chọn");

            // Chọn mặc định là "Tất cả"
            cbbdoituong.SelectedIndex = 0;
            LoadDanhSachNhanKhau();
        }
        private void LoadDanhSachNhanKhau()
        {
            var danhSach = NhanKhauBLL.LayDanhSachNhanKhau();

            dgvdanhsach.DataSource = danhSach.Select(nk => new
            {
                nk.MaNhanKhau,
                nk.HoTen,
                nk.CCCD
            }).ToList();

            dgvdanhsach.Columns[0].HeaderText = "Mã nhân khẩu";
            dgvdanhsach.Columns[1].HeaderText = "Họ tên";
            dgvdanhsach.Columns[2].HeaderText = "CCCD";
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txttimkiem.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            var ketQua = NhanKhauBLL.TimKiemNhanKhau(tuKhoa);

            if (ketQua == null || !ketQua.Any())
            {
                MessageBox.Show("Thông tin không tồn tại.");
                // Không reset DataGridView, giữ nguyên dữ liệu cũ
                return;
            }

            dgvdanhsach.DataSource = ketQua.Select(nk => new
            {
                nk.MaNhanKhau,
                nk.HoTen,
                nk.CCCD
            }).ToList();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (cbbdoituong.SelectedItem == null) return;

            string doiTuong = cbbdoituong.SelectedItem.ToString();

            if (doiTuong == "Tất cả")
            {
                var danhSach = NhanKhauBLL.LayDanhSachNhanKhau();
                lsb.Items.Clear(); // Xóa trước khi thêm lại

                foreach (var nk in danhSach)
                {
                    if (!lsb.Items.Contains(nk.MaNhanKhau))
                    {
                        lsb.Items.Add(nk.MaNhanKhau);
                    }
                }
            }
            else if (doiTuong == "Tùy chọn")
            {
                foreach (DataGridViewRow row in dgvdanhsach.SelectedRows)
                {
                    if (row.Cells["MaNhanKhau"].Value != null)
                    {
                        string maNK = row.Cells["MaNhanKhau"].Value.ToString();

                        if (!lsb.Items.Contains(maNK))
                        {
                            lsb.Items.Add(maNK);
                        }
                    }
                }
            }
        }
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            lsb.Items.Clear();
            LoadDanhSachNhanKhau();
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            // Nếu không có phần tử nào được chọn thì thoát
            if (lsb.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phần tử để xóa.");
                return;
            }

            // Lưu danh sách các mục được chọn vào danh sách tạm
            List<object> itemsToRemove = new List<object>();
            foreach (var item in lsb.SelectedItems)
            {
                itemsToRemove.Add(item);
            }

            // Xóa từng mục trong danh sách tạm khỏi ListBox
            foreach (var item in itemsToRemove)
            {
                lsb.Items.Remove(item);
            }
        }
        private void btngui_Click(object sender, EventArgs e)
        {
            string tieuDe = txttieude.Text.Trim();
            string noiDung = txtloinhan.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề và nội dung.");
                return;
            }

            if (lsb.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người nhận.");
                return;
            }

            // 1. Gửi Thông báo (Lưu vào bảng ThongBao)
            ThongBaoDTO tb = new ThongBaoDTO
            {
                TieuDe = tieuDe,
                NoiDung = noiDung,
                NgayGui = DateTime.Now
            };

            int maThongBao = thongBaoBLL.ThemThongBao(tb); // Hàm này trả về ID vừa thêm

            // 2. Gửi tới từng người nhận
            foreach (var item in lsb.Items)
            {
                ThongBaoNguoiNhanDTO nguoiNhan = new ThongBaoNguoiNhanDTO
                {
                    MaThongBao = maThongBao,
                    MaNguoiNhan = item.ToString(),
                    DaXem = false
                };
                thongBaoBLL.ThemThongBaoNguoiNhan(nguoiNhan);
            }

            MessageBox.Show("Gửi thành công.");
            txttieude.Clear();
            txtloinhan.Clear();
        }
    }
}
