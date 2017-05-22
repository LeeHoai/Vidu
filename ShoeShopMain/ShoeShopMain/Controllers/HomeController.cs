using ShoeShopMain.Domain.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShopMain.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string searchString, int page = 1, int pageSize = 6)
        {
            var dao = new SanPhamDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            SetViewBagLSP();
            SetViewBagNSX();
            SetViewBagNCC();

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult MainMenuLSP()
        {
            var model = new LoaiSanPhamDao().listGroup();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult MainMenuNSX()
        {
            var model = new NhaSanXuatDao().listGroup();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult MainMenuNCC()
        {
            var model = new NhaCungCapDao().listGroup();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult HomeNemuLSP()
        {
            var model = new LoaiSanPhamDao().listGroup();
            return PartialView(model);
        }

        public void SetViewBagLSP(int? selectedID = null)
        {
            var dao = new LoaiSanPhamDao();
            ViewBag.MaLoaiSP = new SelectList(dao.listAll(), "MaLoaiSP", "TenLoaiSP", selectedID);
        }
        public void SetViewBagNSX(int? selectedID = null)
        {
            var dao = new NhaSanXuatDao();
            ViewBag.MaNSX = new SelectList(dao.listAll(), "MaNSX", "TenNSX", selectedID);
        }
        public void SetViewBagNCC(int? selectedID = null)
        {
            var dao = new NhaCungCapDao();
            ViewBag.MaNCC = new SelectList(dao.listAll(), "MaNCC", "TenNCC", selectedID);
        }
    }
}