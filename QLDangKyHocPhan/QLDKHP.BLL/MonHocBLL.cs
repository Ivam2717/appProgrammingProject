using QLDKHP.DAL;
using QLDKHP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKHP.BLL
{
    public class MonHocBLL
    {
        public List<MonHocDTO> GetAll()
        {
            MonHocDAL dal = new MonHocDAL();
            return dal.GetAll();
        }
        public bool Insert(string tenMon, int soTinChi)
        {
            MonHocDAL dal = new MonHocDAL();
            tenMon = tenMon.Trim();
            if (string.IsNullOrWhiteSpace(tenMon))
                throw new Exception("Tên môn không được để trống");
            if (soTinChi <= 0)
                throw new Exception("Số tín chỉ phải > 0");
            if (dal.ExistsByName(tenMon))
                throw new Exception("Môn học đã tồn tại!");
            return dal.Insert(tenMon, soTinChi);
        }
        public bool Update(int maMon, string tenMon, int soTinChi)
        {
            MonHocDAL dal = new MonHocDAL();
            if (string.IsNullOrWhiteSpace(tenMon))
                throw new Exception("Tên môn không được để trống");
            if (dal.ExistsByNameExceptId(tenMon, maMon))
                throw new Exception("Tên môn đã tồn tại!");
            return dal.Update(maMon, tenMon, soTinChi);
        }
        public bool Delete(int maMon)
        {
            MonHocDAL dal = new MonHocDAL();
            if (dal.HasLopHocPhan(maMon))
                throw new Exception("Không thể xóa môn vì đã có lớp học phần!");
            return dal.Delete(maMon);
        }
    }
}
