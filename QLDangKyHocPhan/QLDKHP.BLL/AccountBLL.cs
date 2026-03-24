using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDKHP.DAL;
using QLDKHP.DTO;

namespace QLDKHP.BLL
{
    public class AccountBLL
    {
        AccountDAL dal = new AccountDAL();
        public AccountDTO Login(string username, string password)
        {
            return dal.CheckLogin(username, password);
        }
    }
}
