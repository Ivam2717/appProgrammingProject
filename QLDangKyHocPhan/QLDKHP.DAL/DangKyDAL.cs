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
                lhp.MaMon,
                mh.TenMon,
                mh.SoTinChi,
                lhp.Thu,
                lhp.TietBatDau,
                lhp.TietKetThuc,
                lhp.NgayBatDau,
                lhp.NgayKetThuc,
                lhp.SoLuongToiDa,
                COUNT(dk2.MaSV) AS SoLuongDaDangKy
                FROM DangKy dk
                JOIN LopHocPhan lhp ON dk.MaLopHP = lhp.MaLopHP
                JOIN MonHoc mh ON lhp.MaMon = mh.MaMon
                LEFT JOIN DangKy dk2 ON dk2.MaLopHP = lhp.MaLopHP
                WHERE dk.MaSV = @MaSV
                GROUP BY
                    lhp.MaLopHP,
                    lhp.MaMon,
                    mh.TenMon,
                    mh.SoTinChi,
                    lhp.Thu,
                    lhp.TietBatDau,
                    lhp.TietKetThuc,
                    lhp.NgayBatDau,
                    lhp.NgayKetThuc,
                    lhp.SoLuongToiDa
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
                        TietBatDau = (int)reader["TietBatDau"],
                        TietKetThuc = (int)reader["TietKetThuc"]
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
        public int DemSoLuong(int maLopHP) // đếm số lượng sv đã đăng ký lớp học phần
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM DangKy WHERE MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);

                return (int)cmd.ExecuteScalar();
            }
        }
        public int LaySoLuongToiDa(int maLopHP) // lấy số lượng tối đã của lớp
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT SoLuongToiDa FROM LopHocPhan WHERE MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);

                return (int)cmd.ExecuteScalar();
            }
        }
        public bool Delete(int maSV, int maLopHP)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM DangKy WHERE MaSV = @MaSV AND MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public int TongTinChi(int maSV)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"SELECT SUM(mh.SoTinChi)
                         FROM DangKy dk
                         JOIN LopHocPhan lhp ON dk.MaLopHP = lhp.MaLopHP
                         JOIN MonHoc mh ON lhp.MaMon = mh.MaMon
                         WHERE dk.MaSV = @MaSV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                object result = cmd.ExecuteScalar();
                if (result == DBNull.Value)
                    return 0;
                return Convert.ToInt32(result);
            }
        }
    }
}
