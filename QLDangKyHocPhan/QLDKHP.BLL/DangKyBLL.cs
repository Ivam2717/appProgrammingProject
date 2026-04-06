using QLDKHP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDKHP.DAL;

namespace QLDKHP.BLL
{
    public class DangKyBLL
    {
        DangKyDAL dal = new DangKyDAL();
        public List<LopHocPhanDTO> GetByMaSV(int maSV)
        {
            return dal.GetByMaSV(maSV);
        }
        public bool CheckTrungLich(int maSV, LopHocPhanDTO lopMoi)
        {
            var list = dal.GetByMaSV(maSV);
            foreach (var lop in list)
            {
                if (lop.Thu == lopMoi.Thu)
                {
                    if (lopMoi.GioBatDau < lop.GioKetThuc &&
                        lopMoi.GioKetThuc > lop.GioBatDau)
                    {
                        return true; // true = bị trùng lịch
                    }
                }
            }
            return false; // false = k bị trùng lịck
        }
        public bool DaDangKy(int maSV, int maLopHP)
        {
            return dal.Exists(maSV, maLopHP);
        }
        public bool Insert(int maSV, int maLopHP)
        {
            return dal.Insert(maSV, maLopHP);
        }
    }
}
