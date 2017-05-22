using ShoeShopMain.Areas.Admin.Models;
using ShoeShopMain.Common;
using ShoeShopMain.Domain.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShopMain.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                var result = dao.Login(model.SoDienThoai, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.SoDienThoai);
                    var userSession = new TaiKhoanLogin();
                    userSession.SoDienThoai = user.SoDienThoai;
                    userSession.TaiKhoanID = user.MaTaiKhoan;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }else if(result == 2){
                    var user = dao.GetById(model.SoDienThoai);
                    var userSession = new TaiKhoanLogin();
                    userSession.SoDienThoai = user.SoDienThoai;
                    userSession.TaiKhoanID = user.MaTaiKhoan;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToRoute("HomeCustomer");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View("Index");
        }
    }
}