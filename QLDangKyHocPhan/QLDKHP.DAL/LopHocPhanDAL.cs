using QLDKHP.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKHP.DAL
{
    public class LopHocPhanDAL
    {
        Database db = new Database();

        public List<LopHocPhanDTO> GetAll()
        {
            List<LopHocPhanDTO> list = new List<LopHocPhanDTO>();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"                
                SELECT 
                    lhp.MaLopHP,
                    mh.TenMon,
                    mh.SoTinChi,
                    lhp.Thu,
                    lhp.TietBatDau,
                    lhp.TietKetThuc,
                    lhp.NgayBatDau,
                    lhp.NgayKetThuc,
                    lhp.SoLuongToiDa,
                    COUNT(dk.MaSV) AS SoLuongDaDangKy
                FROM LopHocPhan lhp
                LEFT JOIN DangKy dk ON dk.MaLopHP = lhp.MaLopHP
                JOIN MonHoc mh ON mh.MaMon = lhp.MaMon
                GROUP BY
                    lhp.MaLopHP,
                    mh.TenMon,
                    mh.SoTinChi,
                    lhp.Thu,
                    lhp.TietBatDau,
                    lhp.TietKetThuc,
                    lhp.NgayBatDau,
                    lhp.NgayKetThuc,
                    lhp.SoLuongToiDa";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LopHocPhanDTO lhp = new LopHocPhanDTO
                    {
                        MaLopHP = (int)reader["MaLopHP"],
                        TenMon = reader["TenMon"].ToString(),
                        SoTinChi = (int)reader["SoTinChi"],
                        Thu = (int)reader["Thu"],
                        TietBatDau = (int)reader["TietBatDau"],
                        TietKetThuc = (int)reader["TietKetThuc"],
                        NgayBatDau = (DateTime)reader["NgayBatDau"],
                        NgayKetThuc = (DateTime)reader["NgayKetThuc"],
                        SoLuongToiDa = (int)reader["SoLuongToiDa"],
                        SoLuongDaDangKy = (int)reader["SoLuongDaDangKy"],
                    };                    

                    list.Add(lhp);
                }
            }
            return list;
        }
        public int GetSoTinChi(int maLopHP)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT mh.SoTinChi
                FROM LopHocPhan lhp
                JOIN MonHoc mh ON lhp.MaMon = mh.MaMon
                WHERE lhp.MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
        public bool Insert(int maMon, int thu, int tietBatDau, int tietKetThuc, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                INSERT INTO LopHocPhan
                (MaMon, Thu, TietBatDau, TietKetThuc, NgayBatDau, NgayKetThuc, SoLuongToiDa)
                VALUES
                (@MaMon, @Thu, @TietBatDau, @TietKetThuc, @NgayBatDau, @NgayKetThuc, @SoLuong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                cmd.Parameters.AddWithValue("@Thu", thu);
                cmd.Parameters.AddWithValue("@TietBatDau", tietBatDau);
                cmd.Parameters.AddWithValue("@TietKetThuc", tietKetThuc);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int maLopHP)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM LopHocPhan WHERE MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool HasSinhVien(int maLopHP)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DangKy WHERE MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public List<int> GetSinhVienByLop(int maLopHP)
        {
            List<int> list = new List<int>();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                SELECT MaSv
                FROM DangKy
                WHERE dk.MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLopHP", maLopHP);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add((int)reader["MaSV"]);
                }
            }
            return list;
        }
        public bool Update(LopHocPhanDTO lop)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = @"
                UPDATE LopHocPhan
                SET MaMon = @MaMon,
                    Thu = @Thu,
                    TietBatDau = @TietBatDau,
                    TietKetThuc = @TietKetThuc,
                    NgayBatDau = @NgayBatDau,
                    NgayKetThuc = @NgayKetThuc,
                    SoLuongToiDa = @SoLuong
                WHERE MaLopHP = @MaLopHP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", lop.MaMon);
                cmd.Parameters.AddWithValue("@Thu", lop.Thu);
                cmd.Parameters.AddWithValue("@TietBatDau", lop.TietBatDau);
                cmd.Parameters.AddWithValue("@TietKetThuc", lop.TietKetThuc);
                cmd.Parameters.AddWithValue("@NgayBatDau", lop.NgayBatDau);
                cmd.Parameters.AddWithValue("@NgayKetThuc", lop.NgayKetThuc);
                cmd.Parameters.AddWithValue("@SoLuong", lop.SoLuongToiDa);
                cmd.Parameters.AddWithValue("@MaLopHP", lop.MaLopHP);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
