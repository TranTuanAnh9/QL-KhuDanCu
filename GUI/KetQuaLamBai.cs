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
    public partial class KetQuaLamBai : Form
    {
        private KetQuaLamBaiBLL bll = new KetQuaLamBaiBLL();
        public KetQuaLamBai()
        {
            InitializeComponent();
        }

        private void KetQuaLamBai_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.AliceBlue;
            // Cấu hình hiển thị đẹp
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKetQua.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKetQua.RowTemplate.Height = 30; // tùy chỉnh nếu cần
        }

        private void btnxemkq_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaUser.Text) || string.IsNullOrWhiteSpace(txtMaKhaoSat.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã User và Mã Khảo Sát.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaUser.Text, out int maUser) || !int.TryParse(txtMaKhaoSat.Text, out int maKhaoSat))
            {
                MessageBox.Show("Mã User và Mã Khảo Sát phải là số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<KetQuaLamBaiDTO> ketQua = bll.LayKetQuaTheoUserVaKhaoSat(maUser, maKhaoSat);

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào với thông tin đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKetQua.DataSource = null;
            }
            else
            {
                dgvKetQua.DataSource = ketQua;
                dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
