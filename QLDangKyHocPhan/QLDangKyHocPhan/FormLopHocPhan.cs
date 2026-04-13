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

namespace QLDangKyHocPhan
{
    public partial class FormLopHocPhan : Form
    {
        public FormLopHocPhan()
        {
            InitializeComponent();
        }

        private void FormLopHocPhan_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
        }
        private void LoadMonHoc()
        {
            MonHocBLL bll =new MonHocBLL();
            cbMonHoc.DataSource = bll.GetAll();
            cbMonHoc.DisplayMember = "TenMon";
            cbMonHoc.ValueMember = "MaMon";//hiển thị tên môn nhưng giá trị để xử lý là mã môn 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int maMon = Convert.ToInt32(cbMonHoc.SelectedValue);
                int tietBatDau = int.Parse(txtTietBatDau.Text);
                int tietKetThuc = int.Parse(txtTietKetThuc.Text);
                DateTime ngayBatDau = dtpNgayBatDau.Value;
                DateTime ngayKetThuc = dtpNgayKetThuc.Value;
                int thu = Convert.ToInt32(cbThu.Text);
                int soLuong = int.Parse(txtSoLuongToiDa.Text);
                if (tietBatDau >= tietKetThuc)
                {
                    MessageBox.Show("Tiết bắt đầu phải nhỏ hơn tiết kết thúc");
                    return;
                }
                if (ngayBatDau > ngayKetThuc)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
                    return;
                }
                if (soLuong <= 0 || soLuong > 100)
                {
                    MessageBox.Show("Sĩ số phải > 0 và <= 100");
                    return;
                }
                LopHocPhanBLL bll = new LopHocPhanBLL();
                bool result = bll.Insert(maMon, thu, tietBatDau, tietKetThuc, ngayBatDau, ngayKetThuc, soLuong);
                if (result)
                {
                    MessageBox.Show("Thêm lớp học phần thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
                dgvLopHocPhan.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maLopHP = Convert.ToInt32(dgvLopHocPhan.CurrentRow.Cells["MaLopHP"].Value);
                LopHocPhanBLL bll = new LopHocPhanBLL();
                bll.Delete(maLopHP);
                MessageBox.Show("Xóa thành công!");
                dgvLopHocPhan.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            cbMonHoc.SelectedIndex = -1;
            cbThu.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            txtTietBatDau.Clear();
            txtTietKetThuc.Clear();
            txtSoLuongToiDa.Clear();
        }
    }
}
