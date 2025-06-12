using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PhongChongDich : Form
    {
        private DichBenhBLL dichbenhbll = new DichBenhBLL();
        public PhongChongDich()
        {
            InitializeComponent();
        }

        private void PhongChongDich_Load(object sender, EventArgs e)
        {
            dtvdichbenh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvdichbenh.MultiSelect = false;
            txttimkiemdichbenh.ForeColor = Color.Gray;
            txttimkiemdichbenh.Text = "Tìm kiếm theo mã dịch";

            txttimkiemdichbenh.Enter += Txttimkiemdichbenh_Enter;
            txttimkiemdichbenh.Leave += Txttimkiemdichbenh_Leave;
            btnthemdichbenh.BackColor = Color.LightGreen;
            btnsuadichbenh.BackColor = Color.LightGreen;
            btnxoadichbenh.BackColor = Color.LightGreen;
            btnlammoidichbenh.BackColor = Color.LightGreen;
            btnxuatdon.BackColor = Color.LightGreen;
            btntimkiemdichbenh.BackColor = Color.LightCyan;
            pnlphongchongdich.BackColor = Color.LightGreen;
            grb3dichbenh.BackColor = Color.AliceBlue;
            grbghinhan.BackColor = Color.AliceBlue;
            LoadData();
        }
        private void Txttimkiemdichbenh_Enter(object sender, EventArgs e)
        {
            if (txttimkiemdichbenh.Text == "Tìm kiếm theo mã dịch")
            {
                txttimkiemdichbenh.Text = "";
                txttimkiemdichbenh.ForeColor = Color.Black;
            }
        }

        private void Txttimkiemdichbenh_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txttimkiemdichbenh.Text))
            {
                txttimkiemdichbenh.Text = "Tìm kiếm theo mã dịch";
                txttimkiemdichbenh.ForeColor = Color.Gray;
            }
        }
        private void LoadData()
        {
            List<DichBenhDTO> danhSach = dichbenhbll.LayDanhSachDichBenh();
            dtvdichbenh.DataSource = danhSach;
        }

        private void btnthemdichbenh_Click(object sender, EventArgs e)
        {
            DichBenhDTO db = new DichBenhDTO
            {
                MaDich = txtmadich.Text.Trim(),
                TenDich = txttendich.Text.Trim(),
                NgayBungPhat = dtpngaybungphat.Value,
                MucDoNguyHiem = txtmucdonguyhiem.Text.Trim(),
                NoiBungPhat = txtnoibungphat.Text.Trim(),
                MoTa = txtmota.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };

            string thongBao = dichbenhbll.ThemDichBenh(db);
            MessageBox.Show(thongBao);

            if (thongBao == "Thêm dịch bệnh thành công!")
            {
                LoadData();
            }
        }

        private void dtvdichbenh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtvdichbenh.Rows[e.RowIndex];

                txtmadich.Text = row.Cells["MaDich"].Value?.ToString();
                txttendich.Text = row.Cells["TenDich"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayBungPhat"].Value?.ToString(), out DateTime ngay))
                {
                    dtpngaybungphat.Value = ngay;
                }

                txtmucdonguyhiem.Text = row.Cells["MucDoNguyHiem"].Value?.ToString();
                txtnoibungphat.Text = row.Cells["NoiBungPhat"].Value?.ToString();
                txtmota.Text = row.Cells["MoTa"].Value?.ToString();
                txttrangthai.Text = row.Cells["TrangThai"].Value?.ToString();
                txtmadich.ReadOnly= true;
            }
        }

        private void btnsuadichbenh_Click(object sender, EventArgs e)
        {
            DichBenhDTO db = new DichBenhDTO
            {
                MaDich = txtmadich.Text.Trim(),
                TenDich = txttendich.Text.Trim(),
                NgayBungPhat = dtpngaybungphat.Value,
                MucDoNguyHiem = txtmucdonguyhiem.Text.Trim(),
                NoiBungPhat = txtnoibungphat.Text.Trim(),
                MoTa = txtmota.Text.Trim(),
                TrangThai = txttrangthai.Text.Trim()
            };

            string thongBao = dichbenhbll.SuaDichBenh(db);
            MessageBox.Show(thongBao);

            if (thongBao == "Cập nhật dịch bệnh thành công!")
            {
                LoadData();
            }
        }

        private void btnxoadichbenh_Click(object sender, EventArgs e)
        {
            string maDichBenh = txtmadich.Text.Trim();

            if (string.IsNullOrWhiteSpace(maDichBenh))
            {
                MessageBox.Show("Vui lòng chọn dịch bệnh cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa dịch bệnh có mã [{maDichBenh}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string ketQua = dichbenhbll.XoaDichBenh(maDichBenh);
                MessageBox.Show(ketQua);

                if (ketQua.Contains("Xóa dịch bệnh thành công!"))
                {
                    LoadData(); // Load lại danh sách
                }
            }
        }

        private void btntimkiemdichbenh_Click(object sender, EventArgs e)
        {
            txttimkiemdichbenh.Focus(); 
            string MaDich = txttimkiemdichbenh.Text.Trim();

            if (string.IsNullOrWhiteSpace(MaDich))
            {
                MessageBox.Show("Hãy nhập thông tin muốn tìm kiếm", "Thông báo");
                return;
            }

            var ketQua = dichbenhbll.TimKiemDichBenh(MaDich);

            if (ketQua.Count > 0)
            {
                dtvdichbenh.DataSource = ketQua;
            }
            else
            {
                MessageBox.Show("Thông tin không tồn tại!", "Thông báo");
                // Không reset lại dữ liệu gốc, giữ nguyên
            }
        }

        private void btnxuatdon_Click(object sender, EventArgs e)
        {
            if (dtvdichbenh.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtvdichbenh.SelectedRows[0];

                string tenDich = row.Cells["TenDich"].Value?.ToString();
                string ngayBungPhat = Convert.ToDateTime(row.Cells["NgayBungPhat"].Value).ToString("dd/MM/yyyy");
                string mucDoNguyHiem = row.Cells["MucDoNguyHiem"].Value?.ToString();
                string noiBungPhat = row.Cells["NoiBungPhat"].Value?.ToString();
                string moTa = row.Cells["MoTa"].Value?.ToString();
                string trangThai = row.Cells["TrangThai"].Value?.ToString();

                // Gọi form đơn chống dịch và truyền dữ liệu sang
                DonPhongChongDich formDon = new DonPhongChongDich(
                    tenDich, ngayBungPhat, mucDoNguyHiem, noiBungPhat, moTa, trangThai
                );
                formDon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xuất đơn.", "Thông báo");
            }
        }

        private void btnlammoidichbenh_Click(object sender, EventArgs e)
        {
            txtmadich.Text = "";
            txttendich.Text = "";
            dtpngaybungphat.Value = DateTime.Now; // Reset về ngày hiện tại
            txtmucdonguyhiem.Text = "";
            txtnoibungphat.Text = "";
            txtmota.Text = "";
            txttrangthai.Text = "";
            txtmadich.ReadOnly = false;

            // Nếu có DataGridView dịch bệnh
            dtvdichbenh.DataSource = null;
            dtvdichbenh.Rows.Clear();
            LoadData();
        }
    }
}
