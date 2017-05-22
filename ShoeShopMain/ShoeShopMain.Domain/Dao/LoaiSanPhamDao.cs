using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ShoeShopMain.Domain.Dao
{
    public class LoaiSanPhamDao
    {
        ShoeShopMainDbContext db = null;
        public LoaiSanPhamDao()
        {
            db = new ShoeShopMainDbContext();
        }

        public List<LOAISANPHAM> listAll()
        {
            return db.LOAISANPHAMs.ToList();
        }

        public List<LOAISANPHAM> listGroup()
        {
            return db.LOAISANPHAMs.ToList();
        }

        public LOAISANPHAM ViewDetail(int id)
        {
            return db.LOAISANPHAMs.Find(id);
        }
    }
}
