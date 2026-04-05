using QLDKHP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDKHP.DAL;
using QLDKHP.DTO;

namespace QLDKHP.BLL
{
    public class DangKyBLL
    {
        DangKyDAL dal = new DangKyDAL();
        public List<LopHocPhanDTO> GetByMaSV(int maSV)
        {
            return dal.GetByMaSV(maSV);
        }
    }
}
