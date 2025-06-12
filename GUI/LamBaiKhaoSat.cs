using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class LamBaiKhaoSat : Form
    {
        private int maKhaoSat;
        private int maUser;
        private string tenKhaoSat;
        private CauHoiBLL cauHoiBLL = new CauHoiBLL();
        private DapAnBLL dapAnBLL = new DapAnBLL();
        private List<TraLoiDTO> danhSachTraLoi; // Đây là danh sách các câu trả lời người dùng đã chọn
        private BaiLamBLL baiLamBLL = new BaiLamBLL();

        public LamBaiKhaoSat(int maKhaoSat, string tenKhaoSat)
        {
            InitializeComponent();
            this.maKhaoSat = maKhaoSat;
            this.tenKhaoSat = tenKhaoSat;
        }
        public LamBaiKhaoSat(int maUser, int maKhaoSat)
        {
            InitializeComponent();
            this.maUser = maUser;
            this.maKhaoSat = maKhaoSat;
            danhSachTraLoi = new List<TraLoiDTO>();
        }

        public LamBaiKhaoSat()
        {
            InitializeComponent();
        }
        private void LamBaiKhaoSat_Load(object sender, EventArgs e)
        {
            label1.Text = tenKhaoSat;
            flowLayoutPanel1.Enabled = true;
            flowLayoutPanel1.AutoScroll = true; // Cho phép cuộn nếu quá dài
            LoadCacCauHoi();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadCacCauHoi()
        {
            var danhSachCauHoi = cauHoiBLL.LayDanhSachCauHoiTheoKhaoSat(maKhaoSat);
            flowLayoutPanel1.Controls.Clear();
            if (danhSachTraLoi == null)
                danhSachTraLoi = new List<TraLoiDTO>();
            else
                danhSachTraLoi.Clear();

            int soThuTu = 1;

            foreach (var cauHoi in danhSachCauHoi)
            {
                var panelCauHoi = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(10),
                    Margin = new Padding(10),
                    BackColor = Color.WhiteSmoke,
                    Width = 650
                };
                var lblCauHoi = new Label
                {
                    Text = $"Câu {soThuTu}: {cauHoi.NoiDung}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                panelCauHoi.Controls.Add(lblCauHoi);

                if (cauHoi.Kieu == "Trắc nghiệm")
                {
                    var flpDapAn = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.TopDown,
                        AutoSize = true
                    };
                    var dapAns = dapAnBLL.LayDanhSachDapAnTheoCauHoi(cauHoi.MaCauHoi);
                    foreach (var da in dapAns)
                    {
                        var rb = new RadioButton
                        {
                            Text = da.NoiDungDapAn,
                            Tag = da.MaDapAn,
                            AutoSize = true
                        };
                        rb.CheckedChanged += (s, e) =>
                        {
                            if (rb.Checked)
                            {
                                // Thay câu trả lời cũ
                                danhSachTraLoi.RemoveAll(x => x.MaCauHoi == cauHoi.MaCauHoi);
                                danhSachTraLoi.Add(new TraLoiDTO
                                {
                                    MaCauHoi = cauHoi.MaCauHoi,
                                    MaDapAn = (int)rb.Tag,
                                    TraLoiTuLuan = null
                                });
                            }
                        };
                        flpDapAn.Controls.Add(rb);
                    }
                    panelCauHoi.Controls.Add(flpDapAn);
                }
                else // Tự luận
                {
                    var txtTraLoi = new TextBox
                    {
                        Width = 600,
                        Height = 100,
                        Multiline = true,
                        ScrollBars = ScrollBars.Vertical
                    };
                    txtTraLoi.Leave += (s, e) =>
                    {
                        var text = txtTraLoi.Text.Trim();
                        danhSachTraLoi.RemoveAll(x => x.MaCauHoi == cauHoi.MaCauHoi);
                        danhSachTraLoi.Add(new TraLoiDTO
                        {
                            MaCauHoi = cauHoi.MaCauHoi,
                            MaDapAn = null,
                            TraLoiTuLuan = text
                        });
                    };
                    panelCauHoi.Controls.Add(txtTraLoi);
                }

                flowLayoutPanel1.Controls.Add(panelCauHoi);
                soThuTu++;
            }
        }
        private void btnnopbai_Click(object sender, EventArgs e)
        {
            // Bước 1: Lưu bài làm
            var baiLam = new BaiLamKhaoSatDTO
            {
                MaUser = maUser,
                MaKhaoSat = maKhaoSat,
                NgayNop = DateTime.Now,
                TrangThai = true
            };
            int maBaiLam = baiLamBLL.ThemBaiLamKhaoSat(baiLam);

            // Bước 2: Lưu câu trả lời
            var listCT = danhSachTraLoi.Select(tra => new CauTraLoiDTO
            {
                MaBaiLam = maBaiLam,
                MaCauHoi = tra.MaCauHoi,
                MaDapAn = tra.MaDapAn,
                TraLoiTuLuan = tra.TraLoiTuLuan
            }).ToList();
            baiLamBLL.ThemDanhSachCauTraLoi(listCT);
            MessageBox.Show("Nộp bài thành công!");
            // Gọi lại form cha để cập nhật số lượng khảo sát chưa làm
            if (this.Owner is Trangchucudan tcForm)
            {
                tcForm.CapNhatSoLuongKhaoSatChuaLam();
            }
            Close();
        }
    }
}
