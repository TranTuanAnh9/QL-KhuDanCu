using BLL;
using DTO;
using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class CauHoi : Form
    {
        private KhaoSatBLL ksBLL = new KhaoSatBLL();
        private CauHoiBLL cauHoiBLL = new CauHoiBLL();
        private int maKhaoSat;
        private bool isFormLoaded = false;
        public CauHoi(int maKhaoSat)
        {
            InitializeComponent();
            this.maKhaoSat = maKhaoSat;
        }

        public CauHoi()
        {
            InitializeComponent();
        }

        private void CauHoi_Load(object sender, EventArgs e)
        {
            btnthem.BackColor = Color.MediumAquamarine;
            btnsua.BackColor = Color.MediumAquamarine;
            btnxoa.BackColor = Color.MediumAquamarine;
            btnlammoi.BackColor = Color.MediumAquamarine;
            btnback.BackColor = Color.MediumAquamarine;
            btntaodapan.BackColor = Color.LemonChiffon;


            List<KhaoSatDTO> danhSachKS = ksBLL.LayDanhSachKhaoSat();
            cbbcauhoi.DisplayMember = "TieuDe";
            cbbcauhoi.ValueMember = "MaKhaoSat";
            cbbcauhoi.DataSource = danhSachKS;
            cbbcauhoi.SelectedIndex = -1;

            txtmakhaosat.Text = maKhaoSat.ToString();
            txtmakhaosat.ReadOnly = true;
            panel2.BackColor = Color.AliceBlue;
            btnthem.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btntaodapan.Enabled = false;

            cbbcauhoi.DrawMode = DrawMode.OwnerDrawFixed;
            cbbcauhoi.DrawItem += cbbcauhoi_DrawItem;
            dgvauhoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvauhoi.MultiSelect = false; // Chỉ chọn 1 dòng tại 1 thời điểm\
            isFormLoaded = true;

        }

        private void cbbcauhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded || cbbcauhoi.SelectedIndex == -1)
                return;

            int selectedMaKS = (int)cbbcauhoi.SelectedValue;

            if (selectedMaKS != maKhaoSat)
            {
                string tieuDeDung = ksBLL.LayDanhSachKhaoSat()
                                        .FirstOrDefault(ks => ks.MaKhaoSat == maKhaoSat)?.TieuDe ?? "Không rõ";

                MessageBox.Show($"Bạn đang chọn sai bài khảo sát!\n\n" +
                                $"Vui lòng chọn đúng khảo sát có mã: {maKhaoSat}\n" +
                                $"Tiêu đề: {tieuDeDung}",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnthem.Enabled = false;
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
                btntaodapan.Enabled = false;
                dgvauhoi.DataSource = null;
                return;
            }
            // ✅ Gán dữ liệu
            dgvauhoi.DataSource = cauHoiBLL.LayDanhSachCauHoiTheoKhaoSat(selectedMaKS);

            // ✅ Sau khi có dữ liệu, đặt AutoSizeMode cho cột "NoiDung"
            if (dgvauhoi.Columns["NoiDung"] != null)
            {
                dgvauhoi.Columns["NoiDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvauhoi.Columns["NoiDung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dgvauhoi.DataSource = cauHoiBLL.LayDanhSachCauHoiTheoKhaoSat(selectedMaKS);
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btntaodapan.Enabled = true;
        }

        private void cbbcauhoi_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox cb = sender as ComboBox;
            var item = (KhaoSatDTO)cb.Items[e.Index];
            string displayText = item.TieuDe;

            bool isMatch = item.MaKhaoSat == maKhaoSat;

            e.DrawBackground();
            Color backColor = isMatch ? Color.LightCoral : e.BackColor;
            using (SolidBrush backgroundBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            using (SolidBrush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(displayText, e.Font, textBrush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnoidung.Text) || string.IsNullOrWhiteSpace(txtthutu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtthutu.Text, out int thuTu))
            {
                MessageBox.Show("Thứ tự phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string kieu = rdbtracnghiem.Checked ? "Trắc nghiệm" :
                          rdbtuluan.Checked ? "Tự luận" : "";

            if (string.IsNullOrEmpty(kieu))
            {
                MessageBox.Show("Vui lòng chọn kiểu câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cauHoiBLL.KiemTraTrungNoiDung(maKhaoSat, txtnoidung.Text.Trim()))
            {
                MessageBox.Show("Nội dung câu hỏi này đã tồn tại!", "Trùng nội dung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CauHoiDTO ch = new CauHoiDTO
            {
                MaKhaoSat = maKhaoSat,
                NoiDung = txtnoidung.Text.Trim(),
                Kieu = kieu,
                ThuTu = thuTu
            };

            int maMoi = cauHoiBLL.ThemCauHoi(ch);
            if (maMoi > 0)
            {
                MessageBox.Show("Thêm câu hỏi thành công!", "Thông báo");
                dgvauhoi.DataSource = cauHoiBLL.LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm câu hỏi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhaoSat khaoSat = new KhaoSat();
            khaoSat.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Chưa cần xử lý gì tại đây
        }

        private void dgvauhoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
             {
        DataGridViewRow row = dgvauhoi.Rows[e.RowIndex];
        txtnoidung.Text = row.Cells["NoiDung"].Value.ToString();
        txtthutu.Text = row.Cells["ThuTu"].Value.ToString();

        string kieu = row.Cells["Kieu"].Value.ToString();
        if (kieu == "Trắc nghiệm")
            rdbtracnghiem.Checked = true;
        else if (kieu == "Tự luận")
            rdbtuluan.Checked = true;
             }
        }
        private void ClearForm()
        {
            txtnoidung.Clear();
            txtthutu.Clear();
            rdbtracnghiem.Checked = true; // chọn mặc định
            rdbtuluan.Checked = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvauhoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCauHoi = Convert.ToInt32(dgvauhoi.SelectedRows[0].Cells["MaCauHoi"].Value);

            if (string.IsNullOrWhiteSpace(txtnoidung.Text) || string.IsNullOrWhiteSpace(txtthutu.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtthutu.Text, out int thuTu))
            {
                MessageBox.Show("Thứ tự phải là số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string kieu = rdbtracnghiem.Checked ? "Trắc nghiệm" :
                          rdbtuluan.Checked ? "Tự luận" : "";

            if (string.IsNullOrEmpty(kieu))
            {
                MessageBox.Show("Vui lòng chọn kiểu câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cauHoiBLL.KiemTraTrungNoiDung(maKhaoSat, txtnoidung.Text.Trim()))
            {
                MessageBox.Show("Nội dung câu hỏi này đã tồn tại!", "Trùng nội dung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CauHoiDTO ch = new CauHoiDTO
            {
                MaCauHoi = maCauHoi,
                NoiDung = txtnoidung.Text.Trim(),
                Kieu = kieu,
                ThuTu = thuTu
            };

            bool kq = cauHoiBLL.SuaCauHoi(ch);
            if (kq)
            {
                MessageBox.Show("Sửa thành công!", "Thông báo");
                dgvauhoi.DataSource = cauHoiBLL.LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmakhaosat.Text = "";
            txtnoidung.Text = "";
            txtthutu.Text = "";
            rdbtracnghiem.Checked = false; // chọn mặc định
            rdbtuluan.Checked = false;
        }
        private void btntaodapan_Click(object sender, EventArgs e)
        {
            if (dgvauhoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một câu hỏi để tạo đáp án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvauhoi.SelectedRows[0];

            string kieu = selectedRow.Cells["Kieu"].Value.ToString();
            if (kieu != "Trắc nghiệm")
            {
                MessageBox.Show("Chỉ những câu hỏi kiểu 'Trắc nghiệm' mới được tạo đáp án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy mã câu hỏi từ dòng được chọn
            int maCauHoi = Convert.ToInt32(selectedRow.Cells["MaCauHoi"].Value);
            string noiDung = selectedRow.Cells["NoiDung"].Value.ToString(); // Lấy nội dung câu hỏi

            DapAn frmDapAn = new DapAn(maCauHoi, noiDung); // Truyền cả mã và nội dung
            frmDapAn.ShowDialog();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dgvauhoi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã câu hỏi từ dòng đang chọn
            int maCauHoi = Convert.ToInt32(dgvauhoi.SelectedRows[0].Cells["MaCauHoi"].Value);

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này không?", "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string ketQua = cauHoiBLL.XoaCauHoi(maCauHoi.ToString());

                MessageBox.Show(ketQua, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại danh sách câu hỏi
                dgvauhoi.DataSource = cauHoiBLL.LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);
            }
        }
    }
}
