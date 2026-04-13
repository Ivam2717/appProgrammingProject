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
        public bool Insert(int maMon, int thu, int tietBatDau, int tietKetThuc,
                   DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            return dal.Insert(maMon, thu, tietBatDau, tietKetThuc, ngayBatDau, ngayKetThuc, soLuong);
        }
        public bool Delete(int maLopHP)
        {
            if (dal.HasSinhVien(maLopHP))
            {
                throw new Exception("Không thể xóa lớp vì đã có sinh viên đăng ký!");
            }
            return dal.Delete(maLopHP);
        }
        public bool Update(LopHocPhanDTO lop)
        {
            var danhSachSV = dal.GetSinhVienByLop(lop.MaLopHP);

            foreach (var maSV in danhSachSV)
            {
                if (CheckTrungLich(maSV, lop))
                {
                    throw new Exception("Không thể sửa vì gây trùng lịch cho sinh viên!");
                }
            }
            return dal.Update(lop);
        }
        public bool CheckTrungLich(int maSV, LopHocPhanDTO lopMoi)
        {
            DangKyDAL dal = new DangKyDAL();
            var list = dal.GetByMaSV(maSV);
            foreach (var lop in list)
            {
                if (lop.Thu == lopMoi.Thu)
                {
                    if (lopMoi.TietBatDau < lop.TietKetThuc &&
                        lopMoi.TietKetThuc > lop.TietBatDau)
                    {
                        return true; // true = bị trùng lịch
                    }
                }
            }
            return false; // false = k bị trùng lịck
        }
    }
}
