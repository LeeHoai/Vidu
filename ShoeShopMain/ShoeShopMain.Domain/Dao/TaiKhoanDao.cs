using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ShoeShopMain.Domain.Dao
{
    public class TaiKhoanDao
    {
        ShoeShopMainDbContext db = null;
        public TaiKhoanDao()
        {
            db = new ShoeShopMainDbContext();
        }
        public long Insert(TAIKHOAN entity)
        {
            db.TAIKHOANs.Add(entity);
            db.SaveChanges();
            return entity.MaTaiKhoan;
        }
        public bool Update(TAIKHOAN entity)
        {
            try
            {
                var user = db.TAIKHOANs.Find(entity.MaTaiKhoan);
                Console.Write(user);
                user.HoTen = entity.HoTen;
                user.SoDienThoai = entity.SoDienThoai;
                user.DiaChi = entity.DiaChi;
                user.Email = entity.Email;
                user.MaQuyen = entity.MaQuyen;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return false;
            }
        }
        public IEnumerable<TAIKHOAN> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<TAIKHOAN> model = db.TAIKHOANs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.HoTen.Contains(searchString) || x.SoDienThoai.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaTaiKhoan).ToPagedList(page, pageSize);
        }

        public TAIKHOAN GetById(string soDienThoai)
        {
            return db.TAIKHOANs.SingleOrDefault(x => x.SoDienThoai == soDienThoai);
        }

        public TAIKHOAN ViewDetail(int maTaiKhoan)
        {
            return db.TAIKHOANs.Find(maTaiKhoan);
        }

        public int Login(string soDienThoai, string password)
        {
            var result = db.TAIKHOANs.SingleOrDefault(x => x.SoDienThoai == soDienThoai);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if (result.MaQuyen == 1)
                {
                    if(result.MatKhau == password){
                        return 1;
                    }
                    else{
                        return -1;
                    }
                    
                }
                else
                {
                    if(result.MatKhau == password){
                        return 2;
                    }
                    else{
                        return -1;
                    }
                }
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.TAIKHOANs.Find(id);
                db.TAIKHOANs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
