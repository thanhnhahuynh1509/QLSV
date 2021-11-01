using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoAnQLSV.Views;

namespace DoAnQLSV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int userId;
        private Button currentButton;
        private ClassView classView = new ClassView();
        public static Object objectView;
        public static TextBox changeView = new TextBox();

        public MainWindow()
        {
            InitializeComponent();
            changeView.TextChanged += ChangeView_TextChanged;
            changeView.Margin = new Thickness(1000);
        }

        // Set private

        private void handelBtn(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.Style = TryFindResource("ButtonToolLeftMenu") as Style;
            }
            currentButton = btn;
            currentButton.Style = TryFindResource("btnClickStyle") as Style;
            //currentButton.Background = (Brush)new BrushConverter().ConvertFrom("#333");
        }


        //


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            } else
            {
                WindowState = WindowState.Maximized;
            }
           
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnLop_Click(object sender, RoutedEventArgs e)
        {
            handelBtn(sender as Button);
            objectView = classView;
            changeView.Text = "2";
        }

        private void btnGhiChu_Click(object sender, RoutedEventArgs e)
        {
            handelBtn(sender as Button);
            backgroundMain.Background = new BrushConverter().ConvertFrom("#d9fce8") as Brush;
            GhiChuView ghiChuView = new GhiChuView();
            ghiChuView.userId = userId;
            objectView = ghiChuView;
            changeView.Text = "3";
        }

        private void btnCaiDat_Click(object sender, RoutedEventArgs e)
        {
            handelBtn(sender as Button);
            backgroundMain.Background = new BrushConverter().ConvertFrom("#d9fce8") as Brush;
            SettingView settingView = new SettingView();
            settingView.userId = userId;
            objectView = settingView;
            changeView.Text = "4";
        }

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            handelBtn(sender as Button);

            if(MessageBox.Show("Bạn có chắc chắn muốn đăng xuất!","Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                Close();
            } else
            {
                currentButton.Style = TryFindResource("ButtonToolLeftMenu") as Style;
                return;
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            objectView = new Intro();
            changeView.Text = "1";
        }

        private void ChangeView_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataContext = objectView;
        }
    }
}
