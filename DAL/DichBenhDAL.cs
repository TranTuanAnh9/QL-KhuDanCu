using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DichBenhDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        public List<DichBenhDTO> LayDanhSachDichBenh()
        {
            List<DichBenhDTO> danhSach = new List<DichBenhDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM DichBenh";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DichBenhDTO db = new DichBenhDTO
                    {
                        MaDich = reader["MaDich"].ToString(),
                        TenDich = reader["TenDich"].ToString(),
                        NgayBungPhat = Convert.ToDateTime(reader["NgayBungPhat"]),
                        MucDoNguyHiem = reader["MucDoNguyHiem"].ToString(),
                        NoiBungPhat = reader["NoiBungPhat"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    danhSach.Add(db);
                }
                reader.Close();
            }
            return danhSach;
        }
        public bool KiemTraTrungMaDich(string maDich)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM DichBenh WHERE MaDich = @MaDich";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDich", maDich);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ThemDichBenh(DichBenhDTO db)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ThemDichBenh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaDich", db.MaDich);
                cmd.Parameters.AddWithValue("@TenDich", db.TenDich);
                cmd.Parameters.AddWithValue("@NgayBungPhat", db.NgayBungPhat);
                cmd.Parameters.AddWithValue("@MucDoNguyHiem", db.MucDoNguyHiem);
                cmd.Parameters.AddWithValue("@NoiBungPhat", db.NoiBungPhat);
                cmd.Parameters.AddWithValue("@MoTa", db.MoTa);
                cmd.Parameters.AddWithValue("@TrangThai", db.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool SuaDichBenh(DichBenhDTO db)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SuaDichBenh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaDich", db.MaDich);
                cmd.Parameters.AddWithValue("@TenDich", db.TenDich);
                cmd.Parameters.AddWithValue("@NgayBungPhat", db.NgayBungPhat);
                cmd.Parameters.AddWithValue("@MucDoNguyHiem", db.MucDoNguyHiem);
                cmd.Parameters.AddWithValue("@NoiBungPhat", db.NoiBungPhat);
                cmd.Parameters.AddWithValue("@MoTa", db.MoTa);
                cmd.Parameters.AddWithValue("@TrangThai", db.TrangThai);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool XoaDichBenh(string maDichBenh)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("XoaDichBenh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDich", maDichBenh);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public List<DichBenhDTO> TimKiemDichBenh(string MaDich)
        {
            List<DichBenhDTO> ketQua = new List<DichBenhDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("TimKiemDichBenh", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDich", MaDich);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DichBenhDTO dichBenh = new DichBenhDTO
                    {
                        MaDich = reader["MaDich"].ToString(),
                        TenDich = reader["TenDich"].ToString(),
                        NgayBungPhat = Convert.ToDateTime(reader["NgayBungPhat"]),
                        MucDoNguyHiem = reader["MucDoNguyHiem"].ToString(),
                        NoiBungPhat = reader["NoiBungPhat"].ToString(),
                        MoTa = reader["MoTa"] == DBNull.Value ? "" : reader["MoTa"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };

                    ketQua.Add(dichBenh);
                }

                reader.Close();
            }
            return ketQua;
        }
    }
}
