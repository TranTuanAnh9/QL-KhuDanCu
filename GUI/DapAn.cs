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
    public partial class DapAn : Form
    {
        private int maCauHoi;
        private string noiDungCauHoi;
        private DapAnBLL dapAnBLL = new DapAnBLL();
        public DapAn(int maCauHoi , string noiDungCauHoi)
        {
            InitializeComponent();
            this.maCauHoi = maCauHoi;
            this.noiDungCauHoi = noiDungCauHoi;
        }
        public DapAn()
        {
            InitializeComponent();
        }

        private void DapAn_Load(object sender, EventArgs e)
        {
            txtmacauhoi.Text = maCauHoi.ToString();
            txtmacauhoi.ReadOnly = true;
            label1.Text = noiDungCauHoi;
            panel2.BackColor = Color.AliceBlue;
            btnthem.BackColor = Color.LightCoral;
            btnsua.BackColor = Color.LightCoral;
            btnxoa.BackColor = Color.LightCoral;
            btnlammoi.BackColor = Color.LightCoral;
            btnback.BackColor = Color.LightCoral;
            LoadDanhSachDapAn();
        }
        private void LoadDanhSachDapAn()
        {
            List<DapAnDTO> danhSach = dapAnBLL.LayDanhSachDapAnTheoCauHoi(maCauHoi);
            dgvdapan.DataSource = null;
            dgvdapan.DataSource = danhSach;

            dgvdapan.Columns["MaDapAn"].HeaderText = "Mã Đáp Án";
            dgvdapan.Columns["NoiDungDapAn"].HeaderText = "Nội Dung Đáp Án";
            dgvdapan.Columns["MaCauHoi"].Visible = false;
        }

        private void dgvdapan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdapan.CurrentRow != null)
            {
                txtnoidungdapan.Text = dgvdapan.CurrentRow.Cells["NoiDungDapAn"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DapAnDTO da = new DapAnDTO
            {
                MaCauHoi = maCauHoi,
                NoiDungDapAn = txtnoidungdapan.Text.Trim()
            };

            string ketQua = dapAnBLL.ThemDapAn(da);
            MessageBox.Show(ketQua);

            if (ketQua == "Thêm thành công.")
            {
                txtnoidungdapan.Clear();
                LoadDanhSachDapAn();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvdapan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đáp án cần sửa.", "Thông báo");
                return;
            }

            DapAnDTO da = new DapAnDTO
            {
                MaDapAn = Convert.ToInt32(dgvdapan.CurrentRow.Cells["MaDapAn"].Value),
                MaCauHoi = maCauHoi,
                NoiDungDapAn = txtnoidungdapan.Text.Trim()
            };

            string ketQua = dapAnBLL.SuaDapAn(da);
            MessageBox.Show(ketQua);

            if (ketQua == "Cập nhật thành công.")
            {
                LoadDanhSachDapAn();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            CauHoi cauHoi = new CauHoi();
            cauHoi.ShowDialog();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtnoidungdapan.Text = "";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvdapan.SelectedRows.Count > 0)
            {
                // Lấy MaDapAn từ dòng đang chọn
                string maDapAn = dgvdapan.SelectedRows[0].Cells["MaDapAn"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đáp án này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string ketQua = dapAnBLL.XoaDapAn(maDapAn);
                    MessageBox.Show(ketQua);

                    // Tải lại danh sách sau khi xóa
                    TaiLaiDanhSachDapAn();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đáp án để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TaiLaiDanhSachDapAn()
        {
            // Giả sử bạn đang có mã câu hỏi hiện tại (ví dụ maCauHoiDuocChon)
            int maCauHoiDuocChon = int.Parse(maCauHoi.ToString()); 
            dgvdapan.DataSource = dapAnBLL.LayDanhSachDapAnTheoCauHoi(maCauHoiDuocChon);
        }
    }
 }
