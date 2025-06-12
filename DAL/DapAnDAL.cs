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
    public class DapAnDAL
    {
        private string connectionString = @"Data Source=TANH\SQLEXPRESS01;Initial Catalog=QLKhuDanCu;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        // Lấy danh sách đáp án theo mã câu hỏi
        public List<DapAnDTO> LayDanhSachDapAnTheoCauHoi(int maCauHoi)
        {
            List<DapAnDTO> list = new List<DapAnDTO>();

            string query = "SELECT * FROM DapAn WHERE MaCauHoi = @MaCauHoi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCauHoi", maCauHoi);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DapAnDTO da = new DapAnDTO
                    {
                        MaDapAn = Convert.ToInt32(reader["MaDapAn"]),
                        MaCauHoi = Convert.ToInt32(reader["MaCauHoi"]),
                        NoiDungDapAn = reader["NoiDungDapAn"].ToString()
                    };
                    list.Add(da);
                }
            }
            return list;
        }
        // Thêm đáp án
        public int ThemDapAn(DapAnDTO da)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThemDapAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaCauHoi", da.MaCauHoi);
                cmd.Parameters.AddWithValue("@NoiDungDapAn", da.NoiDungDapAn);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }
        // Sửa đáp án
        public bool SuaDapAn(DapAnDTO da)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SuaDapAn", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaDapAn", da.MaDapAn);
                cmd.Parameters.AddWithValue("@NoiDungDapAn", da.NoiDungDapAn);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public bool XoaDapAn(string madapan)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("proc_XoaDapAn", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDapAn", madapan);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
