using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NguoiThueTroDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<NguoiThueTroDTO> LayDanhSachNguoiThueTro()
        {
            List<NguoiThueTroDTO> danhSach = new List<NguoiThueTroDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NguoiThueTro";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NguoiThueTroDTO nt = new NguoiThueTroDTO
                    {
                        MaNguoiThue = reader["MaNguoiThue"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        QueQuan = reader["QueQuan"].ToString(),
                        NgayBatDauThue = Convert.ToDateTime(reader["NgayBatDauThue"]),
                        MaKhuTro = reader["MaKhuTro"].ToString(),
                        SoPhong = reader["SoPhong"].ToString()
                    };
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem6"] != DBNull.Value)
                    {
                        nt.AnhDinhKem6 = (byte[])reader["AnhDinhKem6"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        nt.AnhDinhKem6 = null;
                    }
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem7"] != DBNull.Value)
                    {
                        nt.AnhDinhKem7 = (byte[])reader["AnhDinhKem7"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        nt.AnhDinhKem7 = null;
                    }
                    danhSach.Add(nt);
                }

                reader.Close();
            }
            return danhSach;
        }
        public bool ThemNguoiThue(NguoiThueTroDTO nt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemNguoiThueTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaNguoiThue", nt.MaNguoiThue);
                cmd.Parameters.AddWithValue("@MaKhuTro", nt.MaKhuTro);
                cmd.Parameters.AddWithValue("@HoTen", nt.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nt.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nt.GioiTinh);
                cmd.Parameters.AddWithValue("@CCCD", nt.CCCD);
                cmd.Parameters.AddWithValue("@SoDienThoai", nt.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", nt.Email);
                cmd.Parameters.AddWithValue("@QueQuan", nt.QueQuan);
                cmd.Parameters.AddWithValue("@NgayBatDauThue", nt.NgayBatDauThue);
                cmd.Parameters.AddWithValue("@SoPhong", nt.SoPhong);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool CapNhatNguoiThue(NguoiThueTroDTO nt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaNguoiThueTro", conn); // nhớ tạo stored procedure này
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaNguoiThue", nt.MaNguoiThue);
                cmd.Parameters.AddWithValue("@MaKhuTro", nt.MaKhuTro);
                cmd.Parameters.AddWithValue("@HoTen", nt.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", nt.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", nt.GioiTinh);
                cmd.Parameters.AddWithValue("@CCCD", nt.CCCD);
                cmd.Parameters.AddWithValue("@SoDienThoai", nt.SoDienThoai);
                cmd.Parameters.AddWithValue("@Email", nt.Email);
                cmd.Parameters.AddWithValue("@QueQuan", nt.QueQuan);
                cmd.Parameters.AddWithValue("@NgayBatDauThue", nt.NgayBatDauThue);
                cmd.Parameters.AddWithValue("@SoPhong", nt.SoPhong);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool XoaNguoiThueTro(string maNguoiThueTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaNguoiThueTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNguoiThue", maNguoiThueTro);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<NguoiThueTroDTO> TimKiemNguoiThueTro(string MaNguoiThueTro)
        {
            List<NguoiThueTroDTO> ketQua = new List<NguoiThueTroDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemNguoiThueTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNguoiThue", MaNguoiThueTro);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NguoiThueTroDTO nt = new NguoiThueTroDTO
                    {
                        MaNguoiThue = reader["MaNguoiThue"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        QueQuan = reader["QueQuan"].ToString(),
                        NgayBatDauThue = Convert.ToDateTime(reader["NgayBatDauThue"]),
                        MaKhuTro = reader["MaKhuTro"].ToString(),
                        SoPhong = reader["SoPhong"].ToString()
                    };

                    ketQua.Add(nt);
                }

                reader.Close();
            }
            return ketQua;
        }
        // 1. Kiểm tra trùng mã người thuê
        public bool KiemTraTrungMaNguoiThue(string ma)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE MaNguoiThue = @Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", ma);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // 2. Kiểm tra trùng CCCD
        public bool KiemTraTrungCCCD(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE CCCD = @CCCD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CCCD", cccd);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // 3. Kiểm tra trùng Số điện thoại
        public bool KiemTraTrungSoDienThoai(string sdt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE SoDienThoai = @SDT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SDT", sdt);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // 4. Kiểm tra trùng Email
        public bool KiemTraTrungEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // 5. Kiểm tra mã khu trọ có tồn tại
        public bool KiemTraTonTaiMaKhuTro(string maKhuTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM KhuTro WHERE MaKhuTro = @Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", maKhuTro);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        // 6. Kiểm tra khu trọ còn phòng trống không
        public bool KiemTraKhuTroConPhong(string maKhuTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SoPhongTrong FROM KhuTro WHERE MaKhuTro = @MaKhuTro";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhuTro", maKhuTro);

                conn.Open();
                object result = cmd.ExecuteScalar(); // Trả về object thay vì ép kiểu trực tiếp

                if (result != null && int.TryParse(result.ToString(), out int soPhongTrong)) // Kiểm tra xem giá trị có thể chuyển thành int không
                {
                    return soPhongTrong > 0; // Nếu có phòng trống, trả về true
                }

                return false; // Trả về false nếu không có phòng trống hoặc dữ liệu không hợp lệ
            }
        }
        public bool CapNhatAnhNguoiThueTro(string maNguoiThueTro, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE NguoiThueTro SET AnhDinhKem6 = @AnhDinhKem6 WHERE MaNguoiThue = @MaNguoiThue";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiThue", maNguoiThueTro);
                cmd.Parameters.Add("@AnhDinhKem6", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy ảnh đính kèm theo mã Nhân Khẩu
        public byte[] LayAnhNguoiThueTro(string maNguoiThueTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem6 FROM NguoiThueTro WHERE MaNguoiThue = @MaNguoiThue";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiThue", maNguoiThueTro);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public bool CapNhatAnhKhuTro(string maNguoiThueTro, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE NguoiThueTro SET AnhDinhKem7 = @AnhDinhKem7 WHERE MaNguoiThue = @MaNguoiThue";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiThue", maNguoiThueTro);
                cmd.Parameters.Add("@AnhDinhKem7", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public byte[] LayAnhNhaKhuTro(string maNguoiThueTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem7 FROM NguoiThueTro WHERE MaNguoiThue = @MaNguoiThue";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNguoiThue", maNguoiThueTro);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public List<ThongKeNguoiThueTheoKhuTroDTO> ThongKeNguoiThueTheoKhuTro()
        {
            List<ThongKeNguoiThueTheoKhuTroDTO> list = new List<ThongKeNguoiThueTheoKhuTroDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeNguoiThueTheoKhuTro", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new ThongKeNguoiThueTheoKhuTroDTO
                    {
                        MaKhuTro = reader["MaKhuTro"].ToString(),
                        SoLuongNguoiThue = Convert.ToInt32(reader["SoLuongNguoiThue"])
                    });
                }
                reader.Close();
            }

            return list;
        }
        public List<ThongKeNguoiThueTheoGioiTinhDTO> ThongKeTheoGioiTinh()
        {
            List<ThongKeNguoiThueTheoGioiTinhDTO> danhSach = new List<ThongKeNguoiThueTheoGioiTinhDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeNguoiThueTheoGioiTinh", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeNguoiThueTheoGioiTinhDTO dto = new ThongKeNguoiThueTheoGioiTinhDTO
                    {
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    };
                    danhSach.Add(dto);
                }

                reader.Close();
            }

            return danhSach;
        }
        public List<ThongKeNguoiThueTheoDoTuoiDTO> ThongKeTheoDoTuoi()
        {
            List<ThongKeNguoiThueTheoDoTuoiDTO> danhSach = new List<ThongKeNguoiThueTheoDoTuoiDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeNguoiThueTheoDoTuoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeNguoiThueTheoDoTuoiDTO dto = new ThongKeNguoiThueTheoDoTuoiDTO
                    {
                        DoTuoi = reader["DoTuoi"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    };
                    danhSach.Add(dto);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool KiemTraCCCDNhanKhau(string cccd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE CCCD = @CCCD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CCCD", cccd);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraSoDienThoaiNhanKhau(string sdt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", sdt);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool KiemTraEmailNhanKhau(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public int DemTongnguoithuetro()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiThueTro";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count;
            }
        }
    }
}
