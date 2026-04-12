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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void menuMonHoc_Click(object sender, EventArgs e)
        {
            btnClear f = new btnClear();
            f.MdiParent = this;
            f.Show();
        }
        private void menuLopHP_Click(object sender, EventArgs e)
        {
            //FormLopHocPhan f = new FormLopHocPhan();
            //f.MdiParent = this;
            //f.Show();
        }
    }
}
