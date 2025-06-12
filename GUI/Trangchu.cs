using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace GUI
{
    public partial class Trangchu : Form
    {
        private HoKhauBLL hoKhauBLL = new HoKhauBLL();
        private NhanKhauBLL nhankhauBLL = new NhanKhauBLL();
        private KhuTroBLL khutroBLL = new KhuTroBLL();
        private NguoiThueTroBLL nguoithuetroBLL = new NguoiThueTroBLL();
        // Thêm vào đầu class Trangchu
        string[] imageFiles;
        int currentImageIndex = 0;
        Timer imageTimer = new Timer();
        string[] tieuBieuFiles;
        int tieuBieuIndex = 0;
        Timer tieuBieuTimer = new Timer();
        string[] hdtieuBieuFiles;
        int hdtieuBieuIndex = 0;
        Timer hdtieuBieuTimer = new Timer();

        public Trangchu()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog;
        bool isLoading = true;
        string[] filePaths;
        string[] fileName;
        private void Trangchu_Load(object sender, EventArgs e)
        {
            // === Ảnh Cá Nhân Tiêu Biểu ===
            string hdtieuBieuFolderPath = Path.Combine(Application.StartupPath, "Images3");
            hdtieuBieuFiles = Directory.GetFiles(hdtieuBieuFolderPath, "*.png");

            if (hdtieuBieuFiles.Length > 0)
            {
                ptbhinhanhcachoatdong.Image = Image.FromFile(hdtieuBieuFiles[0]);

                hdtieuBieuTimer.Interval = 1000; // 3 giây
                hdtieuBieuTimer.Tick += hdTieuBieuTimer_Tick;
                hdtieuBieuTimer.Start();
            }
            // === Ảnh Cá Nhân Tiêu Biểu ===
            string tieuBieuFolderPath = Path.Combine(Application.StartupPath, "Images2");
            tieuBieuFiles = Directory.GetFiles(tieuBieuFolderPath, "*.png");

            if (tieuBieuFiles.Length > 0)
            {
                ptbcanhantieubieu.Image = Image.FromFile(tieuBieuFiles[0]);

                tieuBieuTimer.Interval = 2000; // 3 giây
                tieuBieuTimer.Tick += TieuBieuTimer_Tick;
                tieuBieuTimer.Start();
            }
            // Đường dẫn thư mục chứa ảnh
            string imageFolderPath = Path.Combine(Application.StartupPath, "Images");

            // Lấy tất cả ảnh .png
            imageFiles = Directory.GetFiles(imageFolderPath, "*.png");

            // Nếu có ảnh thì bắt đầu hiển thị
            if (imageFiles.Length > 0)
            {
                ptbgiadinhvanhoa.Image = Image.FromFile(imageFiles[0]);

                imageTimer.Interval = 3000; // 3000ms = 3 giây
                imageTimer.Tick += ImageTimer_Tick;
                imageTimer.Start();
            }
            pnltrangchu.BackColor = Color.LightSlateGray;
            lblhome.BackColor = Color.LightSlateGray;
            pnldanhmucqul.BackColor = Color.White;
            grbqlthongtin.BackColor = Color.LightSlateGray;
            grbqlhoatdong.BackColor = Color.LightSlateGray;
            grbqlghinhan.BackColor = Color.LightSlateGray;
            grbqlthongtingiayto.BackColor = Color.LightSlateGray;
            cbbthongtincudan.Items.Add("Nhân Khẩu");
            cbbthongtincudan.Items.Add("Trang Chủ Hộ Khẩu");

            cbbthongtincudan.SelectedIndex = 0; // chọn mặc định "Nhân Khẩu"

            cbbthongtingiayto.Items.Add("Giấy Tạm Vắng");
            cbbthongtingiayto.Items.Add("Giấy Tạm Trú");

            cbbthongtingiayto.SelectedIndex = 0; // chọn mặc định

            cbbhoatdong.Items.Add("Sinh Hoạt Cuộc Họp");
            cbbhoatdong.Items.Add("Thu Phí Đóng Góp");
            cbbhoatdong.Items.Add("Phòng Chống Dịch");
            cbbhoatdong.Items.Add("Phản Ánh Kiến Nghị");
            cbbhoatdong.Items.Add("Trang Chủ Khu trọ");

            cbbhoatdong.SelectedIndex = 0; // chọn mặc định

            cbbghinhan.Items.Add("Ghi Nhận Tham Gia");
            cbbghinhan.Items.Add("Ghi Nhận Đóng Góp");
            cbbghinhan.Items.Add("Ghi Nhận Bệnh Nhân");
            cbbghinhan.Items.Add("Người Thuê Trọ");
            cbbghinhan.Items.Add("User");

            cbbghinhan.SelectedIndex = 0;
            isLoading = false;
            lblsohokhau.Text = hoKhauBLL.DemTongHoKhau().ToString();
            lblsonhankhau.Text = nhankhauBLL.DemTongNhanKhau().ToString();
            lblsokhutro.Text = khutroBLL.DemTongkhutro().ToString();
            lblsonguoitamtru.Text = nguoithuetroBLL.DemTongnguoithuetro().ToString();
            lblsokhutro.ForeColor = Color.Red;
            lblsonguoitamtru.ForeColor = Color.Red;
            lblsohokhau.ForeColor = Color.Red;
            lblsonhankhau.ForeColor = Color.Red;
            lblsoohokhau.ForeColor = Color.LightGreen;
            lblsoonhankhau.ForeColor = Color.LightGreen;
            lblsookhutro.ForeColor = Color.LightGreen;
            lblsoonguoitamtru.ForeColor = Color.LightGreen;


        }
        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= imageFiles.Length)
            {
                currentImageIndex = 0; // Lặp lại từ đầu
            }
            using (var stream = new FileStream(imageFiles[currentImageIndex], FileMode.Open, FileAccess.Read))
            {
                Image img = Image.FromStream(stream);
                ptbgiadinhvanhoa.Image?.Dispose();
                ptbgiadinhvanhoa.Image = new Bitmap(img);
            }
        }
        private void TieuBieuTimer_Tick(object sender, EventArgs e)
        {
            tieuBieuIndex++;
            if (tieuBieuIndex >= tieuBieuFiles.Length)
            {
                tieuBieuIndex = 0;
            }
            using (var stream = new FileStream(tieuBieuFiles[tieuBieuIndex], FileMode.Open, FileAccess.Read))
            {
                Image img = Image.FromStream(stream);
                ptbcanhantieubieu.Image?.Dispose();
                ptbcanhantieubieu.Image = new Bitmap(img);
            }
        }
        private void hdTieuBieuTimer_Tick(object sender, EventArgs e)
        {
            hdtieuBieuIndex++;
            if (hdtieuBieuIndex >= hdtieuBieuFiles.Length)
            {
                hdtieuBieuIndex = 0;
            }
            using (var stream = new FileStream(hdtieuBieuFiles[hdtieuBieuIndex], FileMode.Open, FileAccess.Read))
            {
                Image img = Image.FromStream(stream);
                ptbhinhanhcachoatdong.Image?.Dispose();
                ptbhinhanhcachoatdong.Image = new Bitmap(img);
            }
        }
        private void grbthongtin_Enter(object sender, EventArgs e)
        {

        }
        private void lbltrangchu_Click(object sender, EventArgs e)
        {

        }
        private void cbbthongtincudan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading || cbbthongtincudan.SelectedIndex == -1) return;
            string luaChon = cbbthongtincudan.SelectedItem.ToString();
            this.Hide(); // Ẩn form chính

            switch (luaChon)
            {
                case "Trang Chủ Hộ Khẩu":
                   TrangChuHoKhau trangChuHoKhau = new TrangChuHoKhau();
                    trangChuHoKhau.FormClosed += (s, args) => this.Show(); // Hiện lại khi đóng
                    trangChuHoKhau.ShowDialog();
                    break;

                case "Nhân Khẩu":
                    NhanKhau formNhanKhau = new NhanKhau();
                    formNhanKhau.FormClosed += (s, args) => this.Show();
                    formNhanKhau.ShowDialog();
                    break;
            }
            cbbthongtincudan.SelectedIndex = -1; // Reset lại sau khi mở form
        }

        private void cbbthongtingiayto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading || cbbthongtingiayto.SelectedIndex == -1) return;
            string luaChon1 = cbbthongtingiayto.SelectedItem.ToString();
            this.Hide(); // Ẩn form chính

            switch (luaChon1)
            {
                case "Giấy Tạm Vắng":
                    GiayTamVang gtv = new GiayTamVang();
                    gtv.FormClosed += (s, args) => this.Show(); // Hiện lại khi đóng
                    gtv.ShowDialog();
                    break;

                case "Giấy Tạm Trú":
                    GiayTamTru gtt = new GiayTamTru();
                    gtt.FormClosed += (s, args) => this.Show();
                    gtt.ShowDialog();
                    break;
            }
            cbbthongtingiayto.SelectedIndex = -1; // Reset lại sau khi mở form
        }

        private void cbbhoatdong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading || cbbhoatdong.SelectedIndex == -1) return;

            string luaChon2 = cbbhoatdong.SelectedItem.ToString();

            switch (luaChon2)
            {
                case "Sinh Hoạt Cuộc Họp":
                    this.Hide();
                    SinhHoatCuocHop shch = new SinhHoatCuocHop();
                    shch.FormClosed += (s, args) => this.Show();
                    shch.ShowDialog();
                    break;

                case "Thu Phí Đóng Góp":
                    ThuPhiDongGop tpdg = new ThuPhiDongGop();
                    tpdg.Show();
                    break;

                case "Phòng Chống Dịch":
                    PhongChongDich pcd = new PhongChongDich();
                    pcd.Show(); // không ẩn form chính
                    break;

                case "Phản Ánh Kiến Nghị":
                    PhanAnhKienNghi pakn = new PhanAnhKienNghi();
                    pakn.Show(); // không ẩn form chính
                    break;

                case "Trang Chủ Khu trọ":
                    this.Hide();
                    TrangChuKhuTro kt = new TrangChuKhuTro();   
                    kt.FormClosed += (s, args) => this.Show();
                    kt.ShowDialog();
                    break;
            }

            cbbhoatdong.SelectedIndex = -1; // Reset lại sau khi mở form
        }

        private void cbbghinhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading || cbbghinhan.SelectedIndex == -1) return;

            string luaChon = cbbghinhan.SelectedItem.ToString();

            switch (luaChon)
            {
                case "Ghi Nhận Tham Gia":
                    GhiNhanThamGia gntg = new GhiNhanThamGia();          
                    gntg.Show();
                    break;

                case "Ghi Nhận Đóng Góp":
                    GhiNhanThuPhi gntt = new GhiNhanThuPhi();
                    gntt.Show();
                    break;

                case "Ghi Nhận Bệnh Nhân":
                    this.Hide();
                    GhiNhanBenhNhan gnbn = new GhiNhanBenhNhan();
                    gnbn.FormClosed += (s, args) => this.Show();
                    gnbn.ShowDialog(); // không ẩn form chính
                    break;

                case "Người Thuê Trọ":
                    this.Hide();
                    NguoiThueTro ntt = new NguoiThueTro();
                    ntt.FormClosed += (s, args) => this.Show();
                    ntt.ShowDialog(); // không ẩn form chính
                    break;

                case "User":
                    User us = new User();
                    us.Show();
                    break;
            }

            cbbhoatdong.SelectedIndex = -1; // Reset lại sau khi mở form
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mp4)|*.mp3;*.mp4";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Chọn file media";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths = openFileDialog.FileNames;
                fileName = openFileDialog.SafeFileNames;

                lstvd.Items.Clear(); // xóa danh sách cũ trước khi thêm mới

                for (int i = 0; i < fileName.Length; i++)
                {
                    lstvd.Items.Add(fileName[i]);
                }
            }
        }
        private void lstvd_DoubleClick(object sender, EventArgs e)
        {
            int choose = lstvd.SelectedIndex;

            if (filePaths != null && choose >= 0 && choose < filePaths.Length)
            {
                axWindowsMediaPlayer1.URL = filePaths[choose];
                txtvd.Text = filePaths[choose];
            }
            else
            {
                MessageBox.Show("Không tìm thấy file tương ứng hoặc dữ liệu chưa được tải đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void lstvd_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcome = new Welcome();
            welcome.ShowDialog();
        }

        private void btntinnhan_Click(object sender, EventArgs e)
        {
            LoiNhan loiNhan = new LoiNhan();
            loiNhan.ShowDialog();
        }
    }
}
