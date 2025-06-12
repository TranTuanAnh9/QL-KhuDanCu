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
    public class GhiNhanBenhNhanDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<GhiNhanBenhNhanDTO> LayDanhSachBenhNhan()
        {
            List<GhiNhanBenhNhanDTO> danhSach = new List<GhiNhanBenhNhanDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM BenhNhan";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GhiNhanBenhNhanDTO bn = new GhiNhanBenhNhanDTO
                    {
                        MaBenhNhan = reader["MaBenhNhan"].ToString(),
                        MaDichBenh = reader["MaDichBenh"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        MucDoNghiemTrong = reader["MucDoNghiemTrong"].ToString(),
                        TenBenh = reader["TenBenh"].ToString(),
                        MoTa = reader["MoTa"].ToString()
                    };

                    danhSach.Add(bn);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool KiemTraTrungMaBenhNhan(string maBenhNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM BenhNhan WHERE MaBenhNhan = @MaBenhNhan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool KiemTraTonTaiMaDichBenh(string maDichBenh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM DichBenh WHERE MaDich = @MaDich";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDich", maDichBenh);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool KiemTraTonTaiMaNhanKhau(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NhanKhau WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public (string HoTen, string CCCD, DateTime NgaySinh, string GioiTinh, string SoDienThoai) LayThongTinNhanKhau(string maNhanKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT HoTen, CCCD, NgaySinh, GioiTinh, SoDienThoai FROM NhanKhau WHERE MaNhanKhau = @MaNhanKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNhanKhau", maNhanKhau);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return (
                        reader["HoTen"].ToString(),
                        reader["CCCD"].ToString(),
                        Convert.ToDateTime(reader["NgaySinh"]),
                        reader["GioiTinh"].ToString(),
                        reader["SoDienThoai"].ToString()
                    );
                }
                else
                {
                    return ("", "", DateTime.MinValue, "", "");
                }
            }
        }
        public string LayThongTinDichBenh(string maDichBenh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TenDich FROM DichBenh WHERE MaDich = @MaDich";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDich", maDichBenh);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader["TenDich"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public bool ThemBenhNhan(GhiNhanBenhNhanDTO benhNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemBenhNhan", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaBenhNhan", benhNhan.MaBenhNhan);
                cmd.Parameters.AddWithValue("@MaNhanKhau", benhNhan.MaNhanKhau);
                cmd.Parameters.AddWithValue("@HoTen", benhNhan.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", benhNhan.CCCD);
                cmd.Parameters.AddWithValue("@NgaySinh", benhNhan.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", benhNhan.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", benhNhan.SoDienThoai);
                cmd.Parameters.AddWithValue("@MaDichBenh", benhNhan.MaDichBenh);
                cmd.Parameters.AddWithValue("@TenBenh", benhNhan.TenBenh);
                cmd.Parameters.AddWithValue("@MucDoNghiemTrong", benhNhan.MucDoNghiemTrong);
                cmd.Parameters.AddWithValue("@MoTa", benhNhan.MoTa);
                cmd.Parameters.AddWithValue("@DiaChi", benhNhan.DiaChi);
                cmd.Parameters.AddWithValue("@TrangThai", benhNhan.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool CapNhatBenhNhan(GhiNhanBenhNhanDTO benhNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaBenhNhan", conn); // tên stored procedure sửa
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaBenhNhan", benhNhan.MaBenhNhan);
                cmd.Parameters.AddWithValue("@MaNhanKhau", benhNhan.MaNhanKhau);
                cmd.Parameters.AddWithValue("@HoTen", benhNhan.HoTen);
                cmd.Parameters.AddWithValue("@CCCD", benhNhan.CCCD);
                cmd.Parameters.AddWithValue("@NgaySinh", benhNhan.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", benhNhan.GioiTinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", benhNhan.SoDienThoai);
                cmd.Parameters.AddWithValue("@MaDichBenh", benhNhan.MaDichBenh);
                cmd.Parameters.AddWithValue("@TenBenh", benhNhan.TenBenh);
                cmd.Parameters.AddWithValue("@MucDoNghiemTrong", benhNhan.MucDoNghiemTrong);
                cmd.Parameters.AddWithValue("@MoTa", benhNhan.MoTa);
                cmd.Parameters.AddWithValue("@DiaChi", benhNhan.DiaChi);
                cmd.Parameters.AddWithValue("@TrangThai", benhNhan.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaBenhNhan(string maBenhNhan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaBenhNhan", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<GhiNhanBenhNhanDTO> TimKiemBenhNhan(string MaBenhNhan)
        {
            List<GhiNhanBenhNhanDTO> ketQua = new List<GhiNhanBenhNhanDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemBenhNhan", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaBenhNhan", MaBenhNhan);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GhiNhanBenhNhanDTO benhNhan = new GhiNhanBenhNhanDTO
                    {
                        MaBenhNhan = reader["MaBenhNhan"].ToString(),
                        MaDichBenh = reader["MaDichBenh"].ToString(),
                        MaNhanKhau = reader["MaNhanKhau"].ToString(),
                        HoTen = reader["HoTen"].ToString(),
                        CCCD = reader["CCCD"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        TrangThai = reader["TrangThai"].ToString(),
                        MucDoNghiemTrong = reader["MucDoNghiemTrong"].ToString(),
                        TenBenh = reader["TenBenh"].ToString(),
                        MoTa = reader["MoTa"] == DBNull.Value ? "" : reader["MoTa"].ToString()
                    };

                    ketQua.Add(benhNhan);
                }

                reader.Close();
            }
            return ketQua;
        }
        public List<ThongKeBenhNhanTheoLoaiBenhDTO> ThongKeBenhNhanTheoLoaiBenh()
        {
            List<ThongKeBenhNhanTheoLoaiBenhDTO> danhSach = new List<ThongKeBenhNhanTheoLoaiBenhDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeBenhNhanTheoLoaiBenh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeBenhNhanTheoLoaiBenhDTO item = new ThongKeBenhNhanTheoLoaiBenhDTO
                    {
                        TenBenh = reader["TenBenh"].ToString(),
                        SoLuongBenhNhan = Convert.ToInt32(reader["SoLuongBenhNhan"])
                    };

                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
        public List<ThongKeBenhNhanTheoTinhTrangDTO> ThongKeBenhNhanTheoTinhTrang()
        {
            List<ThongKeBenhNhanTheoTinhTrangDTO> danhSach = new List<ThongKeBenhNhanTheoTinhTrangDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThongKeBenhNhanTheoTinhTrang", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongKeBenhNhanTheoTinhTrangDTO item = new ThongKeBenhNhanTheoTinhTrangDTO
                    {
                        TrangThai = reader["TrangThai"].ToString(),
                        SoLuongBenhNhan = Convert.ToInt32(reader["SoLuongBenhNhan"])
                    };

                    danhSach.Add(item);
                }

                reader.Close();
            }

            return danhSach;
        }
    }
}
