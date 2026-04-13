using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDangKyHocPhan;

namespace QLDangKyHocPhan
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        private void menuMonHoc_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FormMonHoc)
                {
                    frm.Activate();
                    return;
                }
            }
            FormMonHoc f = new FormMonHoc();
            f.MdiParent = this;
            f.Show();
        }
        private void menuLopHP_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FormLopHocPhan)
                {
                    frm.Activate();
                    return;
                }
            }
            FormLopHocPhan f = new FormLopHocPhan();
            f.MdiParent = this;
            f.Show();
        }
    }
}
