using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ShoeShopMain.Domain.Dao
{
    public class HoaDonBanDao
    {
        ShoeShopMainDbContext db = null;
        public HoaDonBanDao()
        {
            db = new ShoeShopMainDbContext();
        }

        public IEnumerable<HOADONBAN> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<HOADONBAN> model = db.HOADONBANs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MaHDB.ToString().Contains(searchString) || x.MaTaiKhoan.ToString().Contains(searchString) || x.NgayBan.ToString().Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaHDB).ToPagedList(page, pageSize);
        }
    }
}
 