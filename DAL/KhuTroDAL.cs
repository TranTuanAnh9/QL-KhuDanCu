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
    public class KhuTroDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<KhuTroDTO> LayDanhSachKhuTro()
        {
            List<KhuTroDTO> danhSach = new List<KhuTroDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KhuTro";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhuTroDTO kt = new KhuTroDTO
                    {
                        MaKhuTro = reader["MaKhuTro"].ToString(),
                        TenKhuTro = reader["TenKhuTro"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        HoTenChuTro = reader["HoTenChuTro"].ToString(),
                        SoDienThoaiChuTro = reader["SoDienThoaiChuTro"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        SoPhong = Convert.ToInt32(reader["SoPhong"]),
                        SoPhongTrong = Convert.ToInt32(reader["SoPhongTrong"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    // Lấy ảnh (nếu có)
                    if (reader["AnhDinhKem8"] != DBNull.Value)
                    {
                        kt.AnhDinhKem8 = (byte[])reader["AnhDinhKem8"]; // Lưu ảnh dưới dạng byte[]
                    }
                    else
                    {
                        kt.AnhDinhKem8 = null;
                    }
                    danhSach.Add(kt);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool ThemKhuTro(KhuTroDTO kt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemKhuTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaKhuTro", kt.MaKhuTro);
                cmd.Parameters.AddWithValue("@TenKhuTro", kt.TenKhuTro);
                cmd.Parameters.AddWithValue("@DiaChi", kt.DiaChi);
                cmd.Parameters.AddWithValue("@HoTenChuTro", kt.HoTenChuTro);
                cmd.Parameters.AddWithValue("@SoDienThoaiChuTro", kt.SoDienThoaiChuTro);
                cmd.Parameters.AddWithValue("@MaNhanKhau", kt.MaNhanKhau);
                cmd.Parameters.AddWithValue("@SoPhong", kt.SoPhong);
                cmd.Parameters.AddWithValue("@SoPhongTrong", kt.SoPhongTrong);
                cmd.Parameters.AddWithValue("@TrangThai", kt.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaKhuTro(KhuTroDTO kt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaKhuTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaKhuTro", kt.MaKhuTro);
                cmd.Parameters.AddWithValue("@TenKhuTro", kt.TenKhuTro);
                cmd.Parameters.AddWithValue("@DiaChi", kt.DiaChi);
                cmd.Parameters.AddWithValue("@HoTenChuTro", kt.HoTenChuTro);
                cmd.Parameters.AddWithValue("@SoDienThoaiChuTro", kt.SoDienThoaiChuTro);
                cmd.Parameters.AddWithValue("@MaNhanKhau", kt.MaNhanKhau);
                cmd.Parameters.AddWithValue("@SoPhong", kt.SoPhong);
                cmd.Parameters.AddWithValue("@SoPhongTrong", kt.SoPhongTrong);
                cmd.Parameters.AddWithValue("@TrangThai", kt.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaKhuTro(string maKhuTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaKhuTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKhuTro", maKhuTro);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<KhuTroDTO> TimKiemKhuTro(string MaKhuTro)
        {
            List<KhuTroDTO> ketQua = new List<KhuTroDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemKhuTro", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKhuTro", MaKhuTro);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhuTroDTO kt = new KhuTroDTO
                    {
                        MaKhuTro = reader["MaKhuTro"].ToString(),
                        TenKhuTro = reader["TenKhuTro"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        HoTenChuTro = reader["HoTenChuTro"].ToString(),
                        SoDienThoaiChuTro = reader["SoDienThoaiChuTro"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        SoPhong = Convert.ToInt32(reader["SoPhong"]),
                        SoPhongTrong = Convert.ToInt32(reader["SoPhongTrong"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };

                    ketQua.Add(kt);
                }

                reader.Close();
            }
            return ketQua;
        }
        public List<NhanKhauDTO> LayDanhSachNhanKhau()
        {
            List<NhanKhauDTO> list = new List<NhanKhauDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new NhanKhauDTO
                    {
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString()
                    });
                }
                reader.Close();
            }
            return list;
        }
        public bool CapNhatAnhKhuTro2(string maKhuTro, byte[] anhBytes)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE KhuTro SET AnhDinhKem8 = @AnhDinhKem8 WHERE MaKhuTro = @MaKhuTro";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhuTro", maKhuTro);
                cmd.Parameters.Add("@AnhDinhKem8", SqlDbType.VarBinary).Value = (object)anhBytes ?? DBNull.Value;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Lấy ảnh đính kèm theo mã Nhân Khẩu
        public byte[] LayAnhKhuTro2(string maKhuTro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnhDinhKem8 FROM KhuTro WHERE MaKhuTro = @MaKhuTro";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhuTro", maKhuTro);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (byte[])result : null;
            }
        }
        public KhuTroDTO LayKhuTroTheoMa(string maKhuTro)
        {
            KhuTroDTO khuTro = null;
            string query = "SELECT * FROM KhuTro WHERE MaKhuTro = @MaKhuTro";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhuTro", maKhuTro);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    khuTro = new KhuTroDTO
                    {
                        MaKhuTro = reader["MaKhuTro"].ToString(),
                        TenKhuTro = reader["TenKhuTro"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        HoTenChuTro = reader["HoTenChuTro"].ToString(),
                        SoDienThoaiChuTro = reader["SoDienThoaiChuTro"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        SoPhong = Convert.ToInt32(reader["SoPhong"]),
                        SoPhongTrong = Convert.ToInt32(reader["SoPhongTrong"]),
                        TrangThai = reader["TrangThai"].ToString()
                        // Nếu bạn cần thêm các cột ảnh thì có thể xử lý thêm ở đây
                    };
                }
                reader.Close();
            }

            return khuTro;
        }
        public int DemTongkhutro()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM KhuTro";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count;
            }
        }
    }
}
