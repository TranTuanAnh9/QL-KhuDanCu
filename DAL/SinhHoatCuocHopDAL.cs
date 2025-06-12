using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SinhHoatCuocHopDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<SinhHoatCuocHopDTO> LayDanhSachSinhHoat()
        {
            List<SinhHoatCuocHopDTO> danhSach = new List<SinhHoatCuocHopDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SinhHoat";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SinhHoatCuocHopDTO sh = new SinhHoatCuocHopDTO
                    {
                        MaSinhHoat = reader["MaSinhHoat"].ToString(),
                        TenSinhHoat = reader["TenSinhHoat"].ToString(),
                        NgayToChuc = Convert.ToDateTime(reader["NgayToChuc"]),
                        DiaDiem = reader["DiaDiem"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        NguoiToChuc = reader["NguoiToChuc"].ToString(),
                        SoDienThoaiNguoiToChuc = reader["SoDienThoaiNguoiToChuc"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(sh);
                }

                reader.Close();
            }

            return danhSach;
        }
        public bool KiemTraMaSinhHoatTonTai(string maSinhHoat)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM SinhHoat WHERE MaSinhHoat = @MaSinhHoat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSinhHoat", maSinhHoat);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ThemSinhHoat(SinhHoatCuocHopDTO sh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemSinhHoat", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaSinhHoat", sh.MaSinhHoat);
                cmd.Parameters.AddWithValue("@TenSinhHoat", sh.TenSinhHoat);
                cmd.Parameters.AddWithValue("@NgayToChuc", sh.NgayToChuc);
                cmd.Parameters.AddWithValue("@DiaDiem", sh.DiaDiem);
                cmd.Parameters.AddWithValue("@NoiDung", sh.NoiDung);
                cmd.Parameters.AddWithValue("@MoTa", sh.MoTa);
                cmd.Parameters.AddWithValue("@NguoiToChuc", sh.NguoiToChuc);
                cmd.Parameters.AddWithValue("@SoDienThoaiNguoiToChuc", sh.SoDienThoaiNguoiToChuc);
                cmd.Parameters.AddWithValue("@TrangThai", sh.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaSinhHoat(SinhHoatCuocHopDTO sh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaSinhHoat", conn); // tên proc bạn đã có
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaSinhHoat", sh.MaSinhHoat);
                cmd.Parameters.AddWithValue("@TenSinhHoat", sh.TenSinhHoat);
                cmd.Parameters.AddWithValue("@NgayToChuc", sh.NgayToChuc);
                cmd.Parameters.AddWithValue("@DiaDiem", sh.DiaDiem);
                cmd.Parameters.AddWithValue("@NoiDung", sh.NoiDung);
                cmd.Parameters.AddWithValue("@MoTa", sh.MoTa);
                cmd.Parameters.AddWithValue("@NguoiToChuc", sh.NguoiToChuc);
                cmd.Parameters.AddWithValue("@SoDienThoaiNguoiToChuc", sh.SoDienThoaiNguoiToChuc);
                cmd.Parameters.AddWithValue("@TrangThai", sh.TrangThai);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool XoaSinhHoatCuocHop(string maSinhHoatCuocHop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaSinhHoatCuocHop", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSinhHoat", maSinhHoatCuocHop);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<SinhHoatCuocHopDTO> TimKiemSinhHoat(string MaSinhHoat)
        {
            List<SinhHoatCuocHopDTO> ketQua = new List<SinhHoatCuocHopDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemSinhHoat", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSinhHoat", MaSinhHoat);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SinhHoatCuocHopDTO sh = new SinhHoatCuocHopDTO
                    {
                        MaSinhHoat = reader["MaSinhHoat"].ToString(),
                        TenSinhHoat = reader["TenSinhHoat"].ToString(),
                        NgayToChuc = Convert.ToDateTime(reader["NgayToChuc"]),
                        DiaDiem = reader["DiaDiem"].ToString(),
                        NoiDung = reader["NoiDung"].ToString(),
                        MoTa = reader["MoTa"] == DBNull.Value ? "" : reader["MoTa"].ToString(),
                        NguoiToChuc = reader["NguoiToChuc"].ToString(),
                        SoDienThoaiNguoiToChuc = reader["SoDienThoaiNguoiToChuc"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    ketQua.Add(sh);
                }
                reader.Close();
            }
            return ketQua;
        }
    }
}
