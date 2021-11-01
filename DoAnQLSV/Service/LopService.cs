using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQLSV.Service
{
    class LopService
    {
        private QLSVEntities _db = new QLSVEntities();

        public List<Lop> GetLops(int userId)
        {
            _db = new QLSVEntities();
            return _db.Lops.Where( lop => lop.maTaiKhoan == userId).ToList();
        }

        public Lop GetLop(int maLop)
        {
            _db = new QLSVEntities();
            return _db.Lops.Where(lop => lop.maLop == maLop).FirstOrDefault();
        }

        public bool addLop(Lop lop)
        {
           try
           {
               _db.Lops.Add(lop);
               _db.SaveChanges();
                return true;
           }catch(Exception)
           {
                return false;
           }
        }

        public bool deleteLop(int maLop)
        {
            try
            {
                Lop lop = _db.Lops.Where(p => p.maLop == maLop).First();

                _db.Lops.Remove(lop);
                _db.SaveChanges();
                return true;

            } catch(Exception)
            {
                return false;
            }

        }

        public bool updateLop(Lop lop)
        {
            try
            {
                Lop result = _db.Lops.Where(p => p.maLop == lop.maLop).FirstOrDefault();
                if (result != null)
                {
                    result.tenLop = lop.tenLop;
                    result.monHoc = lop.monHoc;
                    result.mau = lop.mau;
                    result.buoi = lop.buoi;
                    _db.SaveChanges();
                    return true;
                }
                else
                    return false;

            } catch(Exception)
            {
                return false;
            }
        }
    }
}
