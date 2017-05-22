using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ShoeShopMain.Domain.Dao
{
    public class HoaDonNhapDao
    {
        ShoeShopMainDbContext db = null;
        public HoaDonNhapDao()
        {
            db = new ShoeShopMainDbContext();
        }

        public IEnumerable<HOADONNHAP> ListAllPaging(int page, int pageSize)
        {
            return db.HOADONNHAPs.OrderByDescending(x => x.MaHDN).ToPagedList(page, pageSize);
        }

        public HOADONNHAP ViewDetail(int maHDN)
        {
            return db.HOADONNHAPs.Find(maHDN);
        }
    }
}
