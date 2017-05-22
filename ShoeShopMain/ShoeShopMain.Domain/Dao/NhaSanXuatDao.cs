using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopMain.Domain.Dao
{
    public class NhaSanXuatDao
    {
        ShoeShopMainDbContext db = null;
        public NhaSanXuatDao()
        {
            db = new ShoeShopMainDbContext();
        }

        public List<NHASANXUAT> listAll()
        {
            return db.NHASANXUATs.ToList();
        }

        public List<NHASANXUAT> listGroup()
        {
            return db.NHASANXUATs.ToList();
        }
    }
}
