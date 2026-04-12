using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDKHP.BLL;

namespace QLDangKyHocPhan
{
    public partial class btnClear : Form
    {
        public btnClear()
        {
            InitializeComponent();
        }
        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            MonHocBLL bll = new MonHocBLL();
            dgvMonHoc.DataSource = bll.GetAll();
        }
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMonHoc.CurrentRow != null)
            {
                txtTenMon.Text = dgvMonHoc.CurrentRow.Cells["TenMon"].Value.ToString();
                txtSoTinChi.Text = dgvMonHoc.CurrentRow.Cells["SoTinChi"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MonHocBLL bll = new MonHocBLL();
                bll.Insert(txtTenMon.Text, int.Parse(txtSoTinChi.Text));
                dgvMonHoc.DataSource = bll.GetAll();
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
                if (dgvMonHoc.CurrentRow == null)
                {
                    MessageBox.Show("Chưa chọn môn!");
                    return;
                }
                int maMon = Convert.ToInt32(dgvMonHoc.CurrentRow.Cells["MaMon"].Value);
                MonHocBLL bll = new MonHocBLL();
                bll.Delete(maMon);
                dgvMonHoc.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMonHoc.CurrentRow == null)
                {
                    MessageBox.Show("Chưa chọn môn!");
                    return;
                }
                int maMon = Convert.ToInt32(dgvMonHoc.CurrentRow.Cells["MaMon"].Value);
                MonHocBLL bll = new MonHocBLL();
                bll.Update(maMon, txtTenMon.Text, int.Parse(txtSoTinChi.Text));
                dgvMonHoc.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenMon.Clear();
            txtSoTinChi.Clear();
        }
    }
}
