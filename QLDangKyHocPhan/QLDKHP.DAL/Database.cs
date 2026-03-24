using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDKHP.DAL
{
    public class Database
    {
        private string connectionString = @"Data Source=DESKTOP-L1R9Q1N\SQLEXPRESS;Initial Catalog=QLDKHP;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
