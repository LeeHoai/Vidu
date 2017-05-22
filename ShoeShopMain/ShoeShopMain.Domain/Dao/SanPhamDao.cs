using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ShoeShopMain.Domain.Dao
{
    public class SanPhamDao
    {
        ShoeShopMainDbContext db = null;
        public SanPhamDao()
        {
            db = new ShoeShopMainDbContext();
        }

        public IEnumerable<SANPHAM> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<SANPHAM> model = db.SANPHAMs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenSP.Contains(searchString) || x.MaSP.ToString().Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaSP).ToPagedList(page, pageSize);
        }

        public long Insert(SANPHAM entity)
        {
            db.SANPHAMs.Add(entity);
            db.SaveChanges();
            return entity.MaSP;
        }

        public SANPHAM ViewDetail(int maSP)
        {
            return db.SANPHAMs.Find(maSP);
        }

        public bool Update(SANPHAM entity)
        {
            try
            {
                var user = db.SANPHAMs.Find(entity.MaSP);
                Console.Write(user);
                user.TenSP = entity.TenSP;
                user.SoLuongTon = entity.SoLuongTon;
                user.MaLoaiSP = entity.MaLoaiSP;
                user.MaNSX = entity.MaNSX;
                user.MaNCC = entity.MaNCC;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.SANPHAMs.Find(id);
                db.SANPHAMs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SANPHAM GetByID(int id)
        {
            return db.SANPHAMs.Find(id);
        }

        public List<SANPHAM> listSlider() 
        {
            return db.SANPHAMs.OrderBy(x => x.MaSP).ToList();
        }

        public List<SANPHAM> ListRelatedProducts(int maSP)
        {
            var sanpham = db.SANPHAMs.Find(maSP);
            return db.SANPHAMs.Where(x => x.MaSP != maSP && x.MaLoaiSP == sanpham.MaLoaiSP).ToList();
        }
    }
}
