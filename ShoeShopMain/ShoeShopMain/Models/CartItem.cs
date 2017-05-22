using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoeShopMain.Domain.EF;

namespace ShoeShopMain.Models
{
    [Serializable]
    public class CartItem
    {
        public SANPHAM SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}