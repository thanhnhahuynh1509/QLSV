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
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DoAnQLSV.Service;
using System.Text.RegularExpressions;

namespace DoAnQLSV.Views
{
    /// <summary>
    /// Interaction logic for InputStudentView.xaml
    /// </summary>
    public partial class InputStudentView : Window
    {
        public static int maLop;
        public static string maSinhVien;
        private List<Lop> listLop = new List<Lop>();

        QLSVEntities _db = new QLSVEntities();

        private LopService lopService = new LopService();
        private SinhVienService sinhVienSerVice = new SinhVienService();

        public InputStudentView()
        {
            InitializeComponent();
        }

        private SinhVien getStudent()
        {
            SinhVien sv = new SinhVien();

            sv.maSinhVien = txtMaSinhVien.Text;
            sv.hoDem = txtHoDem.Text;
            sv.maLop = maLop;
            sv.ten = txtTen.Text;
            sv.lop = txtLop.Text;
            sv.gioiTinh = txtGioiTinh.Text;
            sv.sdt = txtSDT.Text;
            sv.email = txtEmail.Text;
            sv.phatBieu = int.Parse(txtPhatBieu.Text);
            sv.soBuoiCoMat = int.Parse(txtDiemDanh.Text);
            sv.soBuoiVang = int.Parse(txtVang.Text);

            return sv;
        }

        private bool CheckInput()
        {
            if(txtMaSinhVien.Text.Equals("") || txtHoDem.Text.Equals("") || txtTen.Text.Equals("") || txtLop.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return false;
            }
            if (!txtSDT.Text.Equals("") && !Regex.IsMatch(txtSDT.Text, "\\d{8,12}"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo");
                return false;
            }
            if (!txtEmail.Text.Equals("") && !Regex.IsMatch(txtEmail.Text, "\\w+@\\w+[.]\\w+"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo");
                return false;
            }
            if(Regex.IsMatch(txtPhatBieu.Text, "\\D+") || Regex.IsMatch(txtDiemDanh.Text, "\\D+") || Regex.IsMatch(txtVang.Text, "\\D+"))
            {
                MessageBox.Show("Phát biểu, điểm danh, số ngày vắng phải là số!", "Thông báo");
                return false;
            }
            if (!txtGioiTinh.Text.ToLower().Equals("Nam".ToLower()))
                txtGioiTinh.Text = "Nữ";
            else
                txtGioiTinh.Text = "Nam";

            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (!CheckInput())
                return;
            try
            {
                SinhVien sv = getStudent();
                bool check = sinhVienSerVice.AddSinhVien(sv);

                if (!check)
                    throw new Exception();
                    
                
            } catch(Exception)
            {
                MessageBox.Show("Sinh viên đã tồn tại trong lớp!");
            }
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
                return;
            try
            {
                SinhVien sv = getStudent();
                sinhVienSerVice.UpdateSinhVien(maSinhVien, maLop, sv);

            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật không thành công!");
            }
            Close();
        }


        private void loadAnimation()
        {
            Storyboard sb = new Storyboard();
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(.4)),
                From = new Thickness(0, 100, 0, 0),
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
