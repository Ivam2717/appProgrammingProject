using QLDKHP.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKHP.DAL
{
    public class MonHocDAL
    {
        Database db = new Database();
        public List<MonHocDTO> GetAll()
        {
            List<MonHocDTO> list = new List<MonHocDTO>();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM MonHoc";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MonHocDTO mh = new MonHocDTO
                    {
                        MaMon = (int)reader["MaMon"],
                        TenMon = reader["TenMon"].ToString(),
                        SoTinChi = (int)reader["SoTinChi"]
                    };
                    list.Add(mh);
                }
            }
            return list;
        }
        public bool ExistsByName(string tenMon)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT COUNT(*) 
                FROM MonHoc 
                WHERE LOWER(TenMon) = LOWER(@TenMon)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ExistsByNameExceptId(string tenMon, int maMon)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT COUNT(*) 
                FROM MonHoc 
                WHERE LOWER(TenMon) = LOWER(@TenMon)
                AND MaMon != @MaMon
                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool HasLopHocPhan(int maMon)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM LopHocPhan WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }        
        public bool Insert(string tenMon, int soTinChi)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO MonHoc (TenMon, SoTinChi) VALUES (@TenMon, @SoTinChi)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int maMon)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM MonHoc WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Update(int maMon, string tenMon, int soTinChi)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                UPDATE MonHoc 
                SET TenMon = @TenMon, SoTinChi = @SoTinChi
                WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
