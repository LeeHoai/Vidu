using ShoeShopMain.Domain.Dao;
using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ShoeShopMain.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TaiKhoanDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TAIKHOAN taikhoan)
        {
            if(ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                long id = dao.Insert(taikhoan);
                if (id > 0)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("","Thêm tài khoản lỗi!");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var user = new TaiKhoanDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(TAIKHOAN taikhoan)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                var result = dao.Update(taikhoan);
                if (result)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản lỗi!");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TaiKhoanDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}