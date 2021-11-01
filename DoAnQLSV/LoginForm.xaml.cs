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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DoAnQLSV.Service;

namespace DoAnQLSV
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private LoginService loginService = new LoginService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void FadeAnimation(Grid page, Thickness from, Thickness to)
        {
            var sb = new Storyboard();
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(.4)),
                From = from,
                To = to,
                DecelerationRatio = .9f
            };

            Storyboard.SetTarget(slideAnimation, page);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            sb.Children.Add(slideAnimation);

            sb.Begin();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int checkLogin = loginService.Login(txtUsername.Text.Trim(), txtPass.Password.Trim());
            if (checkLogin == -1)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                return;
            }
            else
            {
               try
                {
                    MainWindow.userId = checkLogin;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }


        }

        private void btnRedirectRegisterPage_Click(object sender, RoutedEventArgs e)
        {

            FadeAnimation(registerPage, new Thickness(-1500,0,0,0), new Thickness(0,0,0,0));
            FadeAnimation(loginPage, new Thickness(0,0,0,0), new Thickness(1000,0,0,0));

        }

        private void checkValidAccount(string username, string password)
        {
            if (!password.Equals(txtPassRegisAgain.Password))
            {
                MessageBox.Show("Mật khẩu không trùng khớp");
                return;
            }

            if (username.Length < 8 || password.Length < 8)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được nhỏ hơn 8 ký tự!");
                return;
            }

            if(Regex.IsMatch(username, "\\W") || Regex.IsMatch(username, "\\W"))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu chứa ký tự đặt biệt!");
                return;
            }

        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            string username = txtUsernameRegis.Text;
            string password = txtPassRegis.Password;

            if (!password.Equals(txtPassRegisAgain.Password))
            {
                MessageBox.Show("Mật khẩu không trùng khớp");
                return;
            }

            if (username.Length < 8 || password.Length < 8)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được nhỏ hơn 8 ký tự!");
                return;
            }

            if (Regex.IsMatch(username, "\\W") || Regex.IsMatch(password, "\\W"))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu chứa ký tự đặt biệt!");
                return;
            }

            bool checkRegister = loginService.Register(username, password);

            if(!checkRegister)
            {
                MessageBox.Show("Tài khoản đã tồn tại!");
                return;
            }
            MessageBox.Show("Đăng ký tài khoản thành công!");
            txtUsername.Text = username;
            txtPass.Password = password;
            btnLoginRegisterPage_Click(sender, e);
        }

        private void btnLoginRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            FadeAnimation(registerPage, new Thickness(0, 0, 0, 0), new Thickness(-1500, 0, 0, 0));
            FadeAnimation(loginPage, new Thickness(1000, 0, 0, 0), new Thickness(0, 0, 0, 0));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
