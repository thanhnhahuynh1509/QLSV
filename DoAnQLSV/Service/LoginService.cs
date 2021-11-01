using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnQLSV.Service
{
    class LoginService
    {
        private QLSVEntities _db = new QLSVEntities();
        private List<TaiKhoan> taiKhoans;


        public int Login(string username, string password)
        {
            taiKhoans = _db.TaiKhoans.ToList();

            foreach(TaiKhoan tk in taiKhoans)
            {
                if(username.Equals(tk.taiKhoan1) && password.Equals(tk.matKhau))
                {
                    return tk.maTaiKhoan;
                }
            }

            return -1;
        }

        public bool Register(string username, string password)
        {

            try
            {
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.taiKhoan1 = username;
                taiKhoan.matKhau = password;
                taiKhoan.ghiChu = "";
                _db.TaiKhoans.Add(taiKhoan);
                _db.SaveChanges();

            } catch(Exception)
            {
                return false;
            }

            return true;
        }

    }
}
