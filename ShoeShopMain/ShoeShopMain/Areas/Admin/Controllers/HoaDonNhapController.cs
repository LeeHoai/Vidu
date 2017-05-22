using ShoeShopMain.Domain.Dao;
using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShopMain.Areas.Admin.Controllers
{
    public class HoaDonNhapController : Controller
    {
        // GET: Admin/HoaDonNhap
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new HoaDonNhapDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var user = new HoaDonNhapDao().ViewDetail(id);
            return View(user);
        }
    }
}