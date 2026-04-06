using QLDKHP.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKHP.DAL
{
    
    public class DangKyDAL
    {
        Database db = new Database(); 

        public bool Insert(int maSV, int maLopHP)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO DangKy (MaSV, MaLopHP) VALUES (@MaSV, @MaLopHP)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<LopHocPhanDTO> GetByMaSV(int maSV)
        {
            List<LopHocPhanDTO> list = new List<LopHocPhanDTO>();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT 
                    lhp.MaLopHP,
                    mh.TenMon,
                    lhp.Thu,
                    lhp.GioBatDau,
                    lhp.GioKetThuc
                FROM DangKy dk
                JOIN LopHocPhan lhp ON dk.MaLopHP = lhp.MaLopHP
                JOIN MonHoc mh ON lhp.MaMon = mh.MaMon
                WHERE dk.MaSV = @MaSV
                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LopHocPhanDTO lhp = new LopHocPhanDTO
                    {
                        MaLopHP = (int)reader["MaLopHP"],
                        TenMon = reader["TenMon"].ToString(),
                        Thu = (int)reader["Thu"],
                        GioBatDau = (TimeSpan)reader["GioBatDau"],
                        GioKetThuc = (TimeSpan)reader["GioKetThuc"]
                    };
                    list.Add(lhp);
                }
            }
            return list;
        }
        public bool Exists(int maSV, int maLopHP)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM DangKy WHERE MaSV = @MaSV AND MaLopHP = @MaLopHP";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);

                int count = (int)cmd.ExecuteScalar();

                return count > 0; // >0 = đã đăng ký, 0 = chưa đăng ký
            }
        }
    }
}
