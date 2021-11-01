using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoAnQLSV.Service;

namespace DoAnQLSV.Views
{
    /// <summary>
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        public int userId;

        private QLSVEntities db = new QLSVEntities();

        public SettingView()
        {
            InitializeComponent();
            txtUsernameRegis.IsReadOnly = true;
        }

        private bool CheckInput()
        {
            if (!txtNewPassword.Password.Equals(txtNewPasswordAgain.Password))
            {
                MessageBox.Show("Mật khẩu không trùng khớp");
                return false;
            }

            if (txtNewPassword.Password.Length < 8)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được nhỏ hơn 8 ký tự!");
                return false;
            }

            if (Regex.IsMatch(txtNewPassword.Password, "\\W"))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu chứa ký tự đặt biệt!");
                return false;
            }
            return true;
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
                return;
            try
            {
                TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(p => p.maTaiKhoan == userId);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    return;
                }
                string username = txtUsernameRegis.Text;
                string password = txtOldPassword.Password;
                LoginService loginService = new LoginService();
                if (loginService.Login(username, password) == -1)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    return;
                }
                taiKhoan.matKhau = txtNewPassword.Password;
                db.SaveChanges();
                MessageBox.Show("Cập nhật tài khoản thành công!");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(p => p.maTaiKhoan == userId);
            if(taiKhoan == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                return;
            }
            txtUsernameRegis.Text = taiKhoan.taiKhoan1;
            txtOldPassword.Password = "";
            txtNewPassword.Password = "";
            txtNewPasswordAgain.Password = "";
        }
    }
}
