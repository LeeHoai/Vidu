using ShoeShopMain.Domain.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShopMain.Areas.Admin.Controllers
{
    public class HoaDonBanController : Controller
    {
        // GET: Admin/HoaDonBan
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new HoaDonBanDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
    }
}