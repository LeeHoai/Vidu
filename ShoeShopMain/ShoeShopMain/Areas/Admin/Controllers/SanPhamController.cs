using ShoeShopMain.Domain.Dao;
using ShoeShopMain.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShopMain.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SanPhamDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagLSP();
            SetViewBagNSX();
            SetViewBagNCC();
            return View();
        }
        [HttpPost]
        public ActionResult Create(SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                long id = dao.Insert(sanpham);
                if (id > 0)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm lỗi!");
                }
            }
            return View("Index");
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

        public ActionResult Edit(int id)
        {
            var dao = new SanPhamDao();
            var sanphamid = dao.GetByID(id);
            SetViewBagLSP(sanphamid.MaLoaiSP);
            SetViewBagNSX(sanphamid.MaNSX);
            SetViewBagNCC(sanphamid.MaNCC);
            var user = new SanPhamDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                var result = dao.Update(sanpham);
                if (result)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm lỗi!");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SanPhamDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}