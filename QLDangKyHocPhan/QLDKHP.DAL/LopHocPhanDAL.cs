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
                    lhp.Thu,
                    lhp.GioBatDau,
                    lhp.GioKetThuc,
                    lhp.SoLuongToiDa
                FROM LopHocPhan lhp
                JOIN MonHoc mh ON lhp.MaMon = mh.MaMon
                ";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LopHocPhanDTO lhp = new LopHocPhanDTO
                    {
                        MaLopHP = (int)reader["MaLopHP"],
                        TenMon = reader["TenMon"].ToString(),
                        Thu = (int)reader["Thu"],
                        GioBatDau = (TimeSpan)reader["GioBatDau"],
                        GioKetThuc = (TimeSpan)reader["GioKetThuc"],
                        SoLuongToiDa = (int)reader["SoLuongToiDa"]
                    };

                    list.Add(lhp);
                }
            }

            return list;
        }
    }
}
