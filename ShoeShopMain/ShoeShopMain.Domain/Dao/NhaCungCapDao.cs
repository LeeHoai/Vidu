using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShopMain.Domain.Dao
{
    public class NhaCungCapDao
    {
        ShoeShopMainDbContext db = null;
        public NhaCungCapDao()
        {
            db = new ShoeShopMainDbContext();
        }

        public List<NHACUNGCAP> listAll()
        {
            return db.NHACUNGCAPs.ToList();
        }

        public List<NHACUNGCAP> listGroup()
        {
            return db.NHACUNGCAPs.ToList();
        }
    }
}
