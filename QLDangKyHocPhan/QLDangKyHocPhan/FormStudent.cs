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
            dgvLopHocPhan.Columns["SoTinChi"].HeaderText = "Tín chỉ";
            dgvLopHocPhan.Columns["Thu"].HeaderText = "Thứ"; 
            dgvLopHocPhan.Columns["Tiet"].HeaderText = "Tiết";
            dgvLopHocPhan.Columns["NgayBatDau"].HeaderText = "Bắt đầu";
            dgvLopHocPhan.Columns["NgayKetThuc"].HeaderText = "Kết thúc";
            dgvLopHocPhan.Columns["SiSo"].HeaderText = "Sĩ số";
            dgvLopHocPhan.Columns["TietBatDau"].Visible = false;
            dgvLopHocPhan.Columns["TietKetThuc"].Visible = false;
            dgvLopHocPhan.Columns["SoLuongToiDa"].Visible = false;
            dgvLopHocPhan.Columns["SoLuongDaDangKy"].Visible = false;
            dgvLopHocPhan.Columns["HocKy"].Visible = false;
            dgvLopHocPhan.Columns["NamHoc"].Visible = false;
            dgvLopHocPhan.Columns["MaMon"].Visible = false;
            DangKyBLL dkBLL = new DangKyBLL();
            dgvDaDangKy.DataSource = dkBLL.GetByMaSV(Session.MaSV);
            dgvDaDangKy.Columns["MaLopHP"].HeaderText = "Mã lớp";
            dgvDaDangKy.Columns["TenMon"].HeaderText = "Môn học";
            dgvDaDangKy.Columns["Thu"].HeaderText = "Thứ"; 
            dgvDaDangKy.Columns["Tiet"].HeaderText = "Tiết";
            dgvDaDangKy.Columns["NgayBatDau"].HeaderText = "Bắt đầu";
            dgvDaDangKy.Columns["NgayKetThuc"].HeaderText = "Kết thúc";
            dgvDaDangKy.Columns["SiSo"].HeaderText = "Sĩ số";
            dgvDaDangKy.Columns["TietBatDau"].Visible = false;
            dgvDaDangKy.Columns["TietKetThuc"].Visible = false;
            dgvDaDangKy.Columns["SoLuongToiDa"].Visible = false;
            dgvDaDangKy.Columns["SoLuongDaDangKy"].Visible = false;
            dgvDaDangKy.Columns["HocKy"].Visible = false;
            dgvDaDangKy.Columns["NamHoc"].Visible = false;
            dgvDaDangKy.Columns["MaMon"].Visible = false;
            lblTongTinChi.Text = "Tổng tín chỉ: " + dkBLL.TongTinChi(Session.MaSV);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvLopHocPhan.CurrentRow == null) // check chọn dòng
            {
                MessageBox.Show("Chưa chọn lớp!");
                return;
            }
            LopHocPhanDTO lop = (LopHocPhanDTO)dgvLopHocPhan.CurrentRow.DataBoundItem;
            DangKyBLL bll = new DangKyBLL();
            
            if (bll.DaDangKy(Session.MaSV, lop.MaLopHP))// check đã đăng ký chưa
            {
                MessageBox.Show("Bạn đã đăng ký lớp này rồi");
                return;
            }
            if (bll.CheckTrungLich(Session.MaSV, lop))// check trùng lịch
            {
                MessageBox.Show("Lớp bị trùng lịch");
                return;
            }
            // check sĩ số lớp
            if (!bll.SiSo(lop.MaLopHP))
            {
                MessageBox.Show("Lớp đã đầy");
                return;
            }
            // nếu 2 sinh viên dang ký cùng lúc thì có thể vượt sĩ số, cần check lại DAL
            bool result = bll.Insert(Session.MaSV, lop.MaLopHP); // thêm vào bảng dăng ký
            if (result)
            {
                MessageBox.Show("Đăng ký thành công");
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại");
            }
            dgvDaDangKy.DataSource = bll.GetByMaSV(Session.MaSV);// load lại sau khi bấm đăng ký
            lblTongTinChi.Text = "Tổng tín chỉ: " + bll.TongTinChi(Session.MaSV);
            LopHocPhanBLL lhpBLL = new LopHocPhanBLL();
            dgvLopHocPhan.DataSource = lhpBLL.GetAll();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvDaDangKy.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn lớp hủy đăng ký");
                return;
            }

            int maLopHP = Convert.ToInt32(dgvDaDangKy.CurrentRow.Cells["MaLopHP"].Value);
            DangKyBLL bll = new DangKyBLL();
            lblTongTinChi.Text = "Tổng tín chỉ: " + bll.TongTinChi(Session.MaSV);
            if (bll.Delete(Session.MaSV, maLopHP))
            {
                MessageBox.Show("Đã hủy đăng ký");
                dgvDaDangKy.DataSource = bll.GetByMaSV(Session.MaSV);
            }
            else
            {
                MessageBox.Show("Hủy thất bại");
            }
            lblTongTinChi.Text = "Tổng tín chỉ: " + bll.TongTinChi(Session.MaSV);
            LopHocPhanBLL lhpBLL = new LopHocPhanBLL();
            dgvLopHocPhan.DataSource = lhpBLL.GetAll();
        }
    }
}
