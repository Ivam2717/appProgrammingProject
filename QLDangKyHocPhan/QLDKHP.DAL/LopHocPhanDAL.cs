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
    }
}
