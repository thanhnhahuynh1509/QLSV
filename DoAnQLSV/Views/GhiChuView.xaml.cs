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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoAnQLSV.Service;

namespace DoAnQLSV.Views
{
    /// <summary>
    /// Interaction logic for GhiChuView.xaml
    /// </summary>
    /// 
    public partial class GhiChuView : UserControl
    {
        public int userId;
        QLSVEntities db = new QLSVEntities();

        public GhiChuView()
        {
            InitializeComponent();
        }

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = new TextRange(txtGhiChu.Document.ContentStart,
                txtGhiChu.Document.ContentEnd).Text;
                TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(p => p.maTaiKhoan == userId);
                if (taiKhoan == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản!");
                    return;
                }
                taiKhoan.ghiChu = text;
                db.SaveChanges();
                MessageBox.Show("Lưu thành công!");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(p => p.maTaiKhoan == userId);
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản!");
                return;
            }
            txtGhiChu.Document.Blocks.Clear();
            txtGhiChu.Document.Blocks.Add(new Paragraph(new Run(taiKhoan.ghiChu)));
        }
    }
}
