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
            // Hiển thị tên user
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
    }
}
