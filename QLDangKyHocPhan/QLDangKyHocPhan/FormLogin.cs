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
using QLDKHP.DAL;
using QLDKHP.DTO;
using QLDKHP.BLL;

namespace QLDangKyHocPhan
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AccountBLL bll = new AccountBLL();
            AccountDAL dal = new AccountDAL();

            var account = bll.Login(txtUser.Text, txtPass.Text);

            if (account != null)
            {
                Session.Username = account.Username;
                Session.Role = account.Role;
                Session.MaSV = dal.GetMaSV(account.Username);

                MessageBox.Show("Đăng nhập thành công!");
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
