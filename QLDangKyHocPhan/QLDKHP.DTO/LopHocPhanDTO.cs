using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKHP.DTO
{
    public class LopHocPhanDTO
    {
        public string TenMon { get; set; }
        public int MaLopHP { get; set; }
        public int MaMon { get; set; }
        public int HocKy { get; set; }
        public int NamHoc { get; set; }
        public int Thu { get; set; }
        public int TietBatDau { get; set; }
        public int TietKetThuc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuongToiDa { get; set; }
        public int SoLuongDaDangKy { get; set; }
        public int SoTinChi { get; set; }
        public string Tiet
        {
            get { return TietBatDau + "-" + TietKetThuc; }
        }
        public string SiSo
        {
            get { return SoLuongDaDangKy + "/" + SoLuongToiDa; }
        }
    }
}
