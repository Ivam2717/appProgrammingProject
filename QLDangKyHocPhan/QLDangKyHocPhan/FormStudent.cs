using QLDKHP.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDKHP.DTO;
using QLDKHP.DAL;

namespace QLDangKyHocPhan
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Xin chào: " + Session.Username;

            // Load lớp học phần (đã JOIN)
            LopHocPhanBLL lhpBLL = new LopHocPhanBLL();
            dgvLopHocPhan.DataSource = lhpBLL.GetAll();
            dgvLopHocPhan.Columns["MaLopHP"].HeaderText = "Mã lớp";
            dgvLopHocPhan.Columns["TenMon"].HeaderText = "Môn học";
            dgvLopHocPhan.Columns["Thu"].HeaderText = "Thứ";
            dgvLopHocPhan.Columns["GioBatDau"].HeaderText = "Bắt đầu";
            dgvLopHocPhan.Columns["GioKetThuc"].HeaderText = "Kết thúc";
            dgvLopHocPhan.Columns["SoLuongToiDa"].HeaderText = "Sĩ số";
            DangKyBLL dkBLL = new DangKyBLL();
            dgvDaDangKy.DataSource = dkBLL.GetByMaSV(Session.MaSV);
            dgvDaDangKy.Columns["MaLopHP"].HeaderText = "Mã lớp";
            dgvDaDangKy.Columns["TenMon"].HeaderText = "Môn học";
            dgvDaDangKy.Columns["Thu"].HeaderText = "Thứ";
            dgvDaDangKy.Columns["GioBatDau"].HeaderText = "Bắt đầu";
            dgvDaDangKy.Columns["GioKetThuc"].HeaderText = "Kết thúc";
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvLopHocPhan.CurrentRow == null) // check chọn dòng
            {
                MessageBox.Show("Chưa chọn lớp!");
                return;
            }
            var row = dgvLopHocPhan.CurrentRow; // lấy dòng hiện tại
            int maLopHP = Convert.ToInt32(row.Cells["MaLopHP"].Value);// lấy giá trị mã lớp học phần hiện tại
            LopHocPhanDTO lop = new LopHocPhanDTO
            {
                MaLopHP = maLopHP,
                Thu = Convert.ToInt32(row.Cells["Thu"].Value),
                GioBatDau = (TimeSpan)row.Cells["GioBatDau"].Value,
                GioKetThuc = (TimeSpan)row.Cells["GioKetThuc"].Value
            };
            DangKyBLL bll = new DangKyBLL();
            if (bll.DaDangKy(Session.MaSV, maLopHP))
            {
                MessageBox.Show("Bạn đã đăng ký lớp này rồi!");
                return;
            }

            // 4. Check trùng lịch
            if (bll.CheckTrungLich(Session.MaSV, lop))
            {
                MessageBox.Show("Lớp bị trùng lịch!");
                return;
            }


            bool result = bll.Insert(Session.MaSV, (int)maLopHP); // thêm vào bảng dăng ký

            if (result)
            {
                MessageBox.Show("Đăng ký thành công!");
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại!");
            }
            dgvDaDangKy.DataSource = bll.GetByMaSV(Session.MaSV);
        }
    }
}
