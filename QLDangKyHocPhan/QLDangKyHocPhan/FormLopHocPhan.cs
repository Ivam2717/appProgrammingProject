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
            cbMonHoc.ValueMember = "MaMon";
        }
    }
}
