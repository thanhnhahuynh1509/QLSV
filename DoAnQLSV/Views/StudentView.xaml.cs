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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DoAnQLSV.Service;
using Microsoft.Win32;

namespace DoAnQLSV.Views
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : UserControl
    {
        public static int maLop;
        private SinhVienService sinhVienService = new SinhVienService();
        private List<SinhVien> list;

        public StudentView()
        {
            InitializeComponent();
            try
            {
                list = sinhVienService.GetSinhViens(maLop);
                danhSachSinhVien.ItemsSource = list;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void UpdateStudentView()
        {
            list = sinhVienService.GetSinhViens(maLop);
            danhSachSinhVien.ItemsSource = list;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<SinhVien> sinhViens = new List<SinhVien>();

            sinhViens = list.Where(sv =>
            {
                return sv.maSinhVien.ToLower().Contains(SearchBox.Text.ToLower());

            }).ToList();

            danhSachSinhVien.ItemsSource = sinhViens;
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            InputStudentView.maLop = maLop;
            InputStudentView studentView = new InputStudentView();

            studentView.btnAdd.Margin = new Thickness(0, 60, 0, 0);
            studentView.btnUpdate.Margin = new Thickness(0, 0, -2000, 0);
            studentView.ShowDialog();
            UpdateStudentView();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;

            sinhVienService.DeletetSinhVien(sinhVien.maSinhVien, maLop);
            UpdateStudentView();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;

            InputStudentView.maSinhVien = sinhVien.maSinhVien;
            InputStudentView.maLop = maLop;
            InputStudentView studentView = new InputStudentView();

            studentView.txtMaSinhVien.Text = sinhVien.maSinhVien;
            studentView.txtMaSinhVien.IsReadOnly = true;
            studentView.txtHoDem.Text = sinhVien.hoDem;
            studentView.txtTen.Text = sinhVien.ten;
            studentView.txtLop.Text = sinhVien.lop;
            studentView.txtGioiTinh.Text = sinhVien.gioiTinh;
            studentView.txtSDT.Text = sinhVien.sdt;
            studentView.txtEmail.Text = sinhVien.email;
            studentView.txtPhatBieu.Text = sinhVien.phatBieu.ToString();
            studentView.txtDiemDanh.Text = sinhVien.soBuoiCoMat.ToString();
            studentView.txtVang.Text = sinhVien.soBuoiVang.ToString();
            studentView.ShowDialog();

            UpdateStudentView();
        }

        private void btnTruBuoiVang_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;
            if(sinhVien.soBuoiVang > 0)
            {
                sinhVien.soBuoiVang -= 1;
                sinhVienService.UpdateSinhVien(sinhVien.maSinhVien, maLop, sinhVien);
                UpdateStudentView();
            }
        }

        private void btnCongBuoiVang_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;
            sinhVien.soBuoiVang += 1;
            sinhVienService.UpdateSinhVien(sinhVien.maSinhVien, maLop, sinhVien);
            UpdateStudentView();
        }

        private void btnTruSoBuoiCoMat_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;
            if (sinhVien.soBuoiCoMat > 0)
            {
                sinhVien.soBuoiCoMat -= 1;
                sinhVienService.UpdateSinhVien(sinhVien.maSinhVien, maLop, sinhVien);
                UpdateStudentView();
            }
        }

        private void btnCongBuoiCoMat_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;
            sinhVien.soBuoiCoMat += 1;
            sinhVienService.UpdateSinhVien(sinhVien.maSinhVien, maLop, sinhVien);
            UpdateStudentView();
        }

        private void btnTruPhatBieu_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;
            if (sinhVien.phatBieu > 0)
            {
                sinhVien.phatBieu -= 1;
                sinhVienService.UpdateSinhVien(sinhVien.maSinhVien, maLop, sinhVien);
                UpdateStudentView();
            }
        }

        private void btnCongPhatBieu_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sinhVien = ((Button)(e.Source)).DataContext as SinhVien;
            sinhVien.phatBieu += 1;
            sinhVienService.UpdateSinhVien(sinhVien.maSinhVien, maLop, sinhVien);
            UpdateStudentView();
        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];

                for(int i = 0; i < danhSachSinhVien.Columns.Count - 5; i++)
                {
                    worksheet.Cells[1, i + 1] = danhSachSinhVien.Columns[i].Header;
                    worksheet.Cells[1, i + 1].Font.Bold = true;
                    worksheet.Columns[i + 1].ColumnWidth = 15;
                    worksheet.Cells[1, i + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells[1, i + 1].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAqua;
                }

                worksheet.Cells[1, 8] = "Phát Biểu";
                worksheet.Cells[1, 8].Font.Bold = true;
                worksheet.Columns[8].ColumnWidth = 15;
                worksheet.Cells[1, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Cells[1, 8].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAqua;

                worksheet.Cells[1, 9] = "Điểm Danh";
                worksheet.Cells[1, 9].Font.Bold = true;
                worksheet.Columns[9].ColumnWidth = 15;
                worksheet.Cells[1, 9].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Cells[1, 9].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAqua;

                worksheet.Cells[1, 10] = "Vắng";
                worksheet.Cells[1, 10].Font.Bold = true;
                worksheet.Columns[10].ColumnWidth = 15;
                worksheet.Cells[1, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Cells[1, 10].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbAqua;


                for (int i = 0; i < list.Count; i++)
                {
                    worksheet.Cells[i + 2,1] = list[i].maSinhVien;
                    worksheet.Cells[i + 2,2] = list[i].hoDem;
                    worksheet.Cells[i + 2,3] = list[i].ten;
                    worksheet.Cells[i + 2,4] = list[i].lop;
                    worksheet.Cells[i + 2,5] = list[i].gioiTinh;
                    worksheet.Cells[i + 2,6] = list[i].sdt;
                    worksheet.Cells[i + 2,7] = list[i].email;
                    worksheet.Cells[i + 2,8] = list[i].phatBieu;
                    worksheet.Cells[i + 2,9] = list[i].soBuoiCoMat;
                    worksheet.Cells[i + 2,10] = list[i].soBuoiVang;
                    worksheet.Cells[i + 2, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Cells[i + 2, 6].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Cells[i + 2, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Cells[i + 2, 9].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    worksheet.Cells[i + 2, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
