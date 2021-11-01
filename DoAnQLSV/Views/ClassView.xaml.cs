using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DoAnQLSV.Service;

namespace DoAnQLSV.Views
{
    /// <summary>
    /// Interaction logic for ClassView.xaml
    /// </summary>
    public partial class ClassView : UserControl
    {
        ObservableCollection<Lop> danhSachLop;
        private int userId = MainWindow.userId;
        private LopService lopService = new LopService();

        public ClassView()
        {
            InitializeComponent();

            resetDraw();
        }

        private void resetDraw()
        {
            clearButtonClass();
            List<Lop> lops = lopService.GetLops(userId);
            danhSachLop = new ObservableCollection<Lop>(lops);
            drawButtonClass(danhSachLop.ToList());
        }

        private Label CustomLabel(string text)
        {
            Label l1 = new Label();
            l1.Content = text;
            l1.FontSize = 12;
            l1.FontWeight = FontWeights.Bold;
            l1.Foreground = new BrushConverter().ConvertFrom("#0b1e59") as Brush;
            l1.Width = 182;
            return l1;
        }

        private StackPanel CustomStackPanel(Lop lop)
        {
            StackPanel stack = new StackPanel();
            stack.Children.Add(CustomLabel("Tên Lớp: " + lop.tenLop));
            stack.Children.Add(CustomLabel("Môn: " + lop.monHoc));
            stack.Children.Add(CustomLabel("Buổi: " + lop.buoi));
            Label label = CustomLabel("id: " + lop.maLop);
            label.Margin = new Thickness(-100);
            label.Visibility = Visibility.Hidden;
            stack.Children.Add(label);
            return stack;
        }

        private Button CustomButtonClass(StackPanel stack, string color)
        {
            Button btn = new Button();
            btn.Style = (Style)TryFindResource("ButtonClass");
            btn.Background = (Brush)new BrushConverter().ConvertFrom(color);
            btn.Content = stack;
            btn.Click += btnClass_Click;
            return btn;
        }

        private void drawButtonClass(List<Lop> lops)
        {
            foreach (Lop lop in lops)
            {
                StackPanel stack = CustomStackPanel(lop);
                Button btn = CustomButtonClass(stack, lop.mau);
                containButtonClass.Children.Add(btn);
            }
        }

        private void clearButtonClass()
        {
            containButtonClass.Children.Clear();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            StackPanel stack = btn.Content as StackPanel;
            int n = stack.Children.Count;
            Label lbTenLop = stack.Children[0] as Label;
            Label lbMonHoc = stack.Children[1] as Label;
            Label lbBuoi = stack.Children[2] as Label;
            Label lbId = stack.Children[n - 1] as Label;
            try
            {
                string tenLop = lbTenLop.Content.ToString().Replace("Tên Lớp: ", "");
                string monHoc = lbMonHoc.Content.ToString().Replace("Môn: ", "");
                string buoi = lbBuoi.Content.ToString().Replace("Buổi: ", "");
                string maLop = lbId.Content.ToString().Replace("id: ", "");
                int classId = int.Parse(maLop);

                InputClassView inputClassView = new InputClassView();
                InputClassView.maLop = classId;
                inputClassView.txtTenLop.Text = tenLop;
                inputClassView.txtMonhoc.Text = monHoc;
                inputClassView.txtBuoi.Text = buoi;

                inputClassView.ShowDialog();
                resetDraw();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            resetDraw();
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            InputClassView inputClassView = new InputClassView();
            inputClassView.btnAdd.Margin = new Thickness(0,20,0,0);
            inputClassView.btnDelete.Margin = new Thickness(0,0,-2000,0);
            inputClassView.btnUpdate.Margin = new Thickness(0, 0, -2000, 0);
            inputClassView.btnRedirect.Margin = new Thickness(0, 0, -2000, 0);
            inputClassView.ShowDialog();
            resetDraw();
        }


        // Search box
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Lop> lops = new List<Lop>();

            lops = danhSachLop.Where(lop =>
                   {
                       return lop.tenLop.ToLower().Contains(SearchBox.Text.ToLower());

                   }).ToList();

            clearButtonClass();
            drawButtonClass(lops);
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

