using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using QLDKHP.DTO;

namespace QLDKHP.DAL
{
    public class AccountDAL
    {
        Database db = new Database();

        public AccountDTO CheckLogin(string username, string password)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM Account WHERE Username = @user AND Password = @pass";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new AccountDTO
                    {
                        Username = reader["Username"].ToString(),
                        Role = (int)reader["Role"]
                    };
                }

                return null;
            }
        }
        public int? GetMaSV(string username)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT MaSV FROM SinhVien WHERE Username = @user";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);

                object result = cmd.ExecuteScalar();

                if (result != null)
                    return (int)result;

                return null;
            }
        }
    }
}
