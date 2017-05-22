using ShoeShopMain.Domain.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShopMain.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SanPhamSlider()
        {
            var model = new SanPhamDao().listSlider();
            return PartialView(model);
        }

        public ActionResult Detail(int id)
        {
            var sanpham = new SanPhamDao().ViewDetail(id);
            ViewBag.LoaiSanPham = new LoaiSanPhamDao().ViewDetail(sanpham.MaLoaiSP.Value);
            ViewBag.RelatedProducts = new SanPhamDao().ListRelatedProducts(id);
            return View(sanpham);
        }
    }
}