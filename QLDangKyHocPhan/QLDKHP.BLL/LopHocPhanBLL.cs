using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDKHP.DTO;
using QLDKHP.DAL;

namespace QLDKHP.BLL
{
    public class LopHocPhanBLL
    {
        LopHocPhanDAL dal = new LopHocPhanDAL();
        public List<LopHocPhanDTO> GetAll()
        {
            return dal.GetAll();
        }
    }
}
