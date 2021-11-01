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
using System.Windows.Shapes;
using DoAnQLSV.Service;

namespace DoAnQLSV.Views
{
    /// <summary>
    /// Interaction logic for InputClassView.xaml
    /// </summary>
    public partial class InputClassView : Window
    {
        private LopService lopService = new LopService();
        private int maTaiKhoan = MainWindow.userId;
        public static int maLop;

        public InputClassView()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private string handleColor()
        {
            

            if (_f8ff6e.IsChecked == true)
                return "#f8ff6e";
            if(_cea1ed.IsChecked == true)
                return "#cea1ed";
            if (_9cff6e.IsChecked == true)
                return "#9cff6e";
            if (_ff547f.IsChecked == true)
                return "#ff547f";
            if (_ffa3dd.IsChecked == true)
                return "#ffa3dd";

            return "";
        }

        private bool checkInput()
        {
            if (txtTenLop.Text == "" || txtMonhoc.Text == "" || txtBuoi.Text == "")
                return false;
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool check = checkInput();
            if(!check)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!");
                return;
            }
            try
            {
                Lop lop = new Lop();
                lop.maTaiKhoan = maTaiKhoan;
                lop.tenLop = txtTenLop.Text;
                lop.monHoc = txtMonhoc.Text;
                lop.buoi = txtBuoi.Text;
                lop.mau = handleColor();

                lopService.addLop(lop);
               
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool check = checkInput();
            if (!check)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ!");
                return;
            }
            try
            {
                Lop lop = new Lop();
                lop.maLop = maLop;
                lop.maTaiKhoan = maTaiKhoan;
                lop.tenLop = txtTenLop.Text;
                lop.monHoc = txtMonhoc.Text;
                lop.buoi = txtBuoi.Text;
                lop.mau = handleColor();

                lopService.updateLop(lop);

            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lopService.deleteLop(maLop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            Close();
        }

        private void btnRedirect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentView.maLop = maLop;
                MainWindow.objectView = new StudentView();
                MainWindow.changeView.Text = "changeStudentView";
                Close();
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void loadAnimation()
        {
            Storyboard sb = new Storyboard();
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(.4)),
                From = new Thickness(0,100,0,0),
                To = new Thickness(0),
                DecelerationRatio = .9f
            };

            Storyboard.SetTarget(slideAnimation, borderStart);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            sb.Children.Add(slideAnimation);

            sb.Begin();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                loadAnimation();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
