using ShoeShopMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeShopMain.Domain.Dao;
using System.Web.Script.Serialization;

namespace ShoeShopMain.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(int maSP, int soLuong)
        {
            var sanPham = new SanPhamDao().ViewDetail(maSP);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.SanPham.MaSP==maSP))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.MaSP == maSP)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    //tao moi doi tuong cart item
                    var item = new CartItem();
                    item.SanPham = sanPham;
                    item.SoLuong = soLuong;
                    list.Add(item);
                }
                //gan vao session
                Session[CartSession] = list;
            }
            else
            {
                //tao moi doi tuong cart item
                var item = new CartItem();
                item.SanPham = sanPham;
                item.SoLuong = soLuong;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.MaSP == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart =(List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.MaSP == item.SanPham.MaSP);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                } 
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}