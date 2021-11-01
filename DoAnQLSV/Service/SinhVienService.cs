using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQLSV.Service
{
    
    class SinhVienService
    {
        private QLSVEntities _db = new QLSVEntities();
        private LopService lopService = new LopService();

        public List<SinhVien> GetSinhViens(int maLop)
        {
            _db = new QLSVEntities();
            Lop lop = lopService.GetLop(maLop);
            List<SinhVien> list = lop.SinhViens.ToList();
            return list;
        }

        public bool AddSinhVien(SinhVien sinhVien)
        {
            SinhVien sv = _db.SinhViens.Where(p => p.maSinhVien.Equals(sinhVien.maSinhVien) && p.maLop == sinhVien.maLop).FirstOrDefault();
            if(sv != null)
            {
                return false;
            }

            try
            {
                _db.SinhViens.Add(sinhVien);
                _db.SaveChanges();
            } catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeletetSinhVien(string maSinhVien, int maLop)
        {

            try
            {
                SinhVien sv = _db.SinhViens.Where(p => p.maSinhVien.Equals(maSinhVien) && p.maLop == maLop).First();
                _db.SinhViens.Remove(sv);
                _db.SaveChanges();
            } catch(Exception)
            {
                return false;
            }
            return true;
        }

        public void UpdateSinhVien(string maSinhVien, int maLop, SinhVien sv)
        {
            SinhVien sinhVien = _db.SinhViens.Where(p => p.maSinhVien.Equals(maSinhVien) && p.maLop == maLop).FirstOrDefault();
            if(sinhVien != null)
            {
                sinhVien.maSinhVien = sv.maSinhVien;
                sinhVien.phatBieu = sv.phatBieu;
                sinhVien.soBuoiCoMat = sv.soBuoiCoMat;
                sinhVien.soBuoiVang = sv.soBuoiVang;
                sinhVien.lop = sv.lop;
                sinhVien.ten = sv.ten;
                sinhVien.hoDem = sv.hoDem;
                sinhVien.gioiTinh = sv.gioiTinh;
                sinhVien.sdt = sv.sdt;
                sinhVien.email = sv.email;
                _db.SaveChanges();
            }
        }

        

    }
}
