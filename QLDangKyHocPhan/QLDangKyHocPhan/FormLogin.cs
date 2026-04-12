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
            var account = bll.Login(txtUser.Text, txtPass.Text);

            if (account != null)
            {
                Session.Username = account.Username;
                Session.Role = account.Role;
                Session.MaSV = bll.GetMaSV(account.Username)??0;// ??0 để tránh lỗi null khi lấy mã sinh viên, nếu không có sẽ trả về 0
                MessageBox.Show("Đăng nhập thành công!");
                if (account.Role == 0) // Sinh viên
                {
                    FormStudent f = new FormStudent();
                    f.Show();
                    this.Hide();
                }
                else if (account.Role == 1) // Admin
                {                    
                    FormAdmin f = new FormAdmin();
                    f.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }

        }
    }
}
