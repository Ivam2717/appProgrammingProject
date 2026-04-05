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
        public int Thu { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public int SoLuongToiDa { get; set; }
    }
}
