using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapLonWebFilm.Models;
namespace BaiTapLonWebFilm.Controllers
{
    public class LoginController : Controller
    {
        DBFilmEntities1 db=new DBFilmEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string TenDangNhap, string MatKhau)
        {
            TB_TAIKHOAN tk = db.TB_TAIKHOAN.Where(s => s.TENDANGNHAP == TenDangNhap).SingleOrDefault<TB_TAIKHOAN>();
            if(tk==null)
            {
              TempData["Err"] = "Tài khoản không hợp lệ!";
              return RedirectToAction("Index");
            }
            else
            {
                if(tk.MATKHAU==MatKhau)
                {
                    Session["User"] = tk.TENDANGNHAP;
                    Session["Type"] = tk.LOAITAIKHOAN;
                    if(Session["Type"].ToString().ToUpper().Equals("Admin".ToUpper()))
                    {
                       return  RedirectToAction("Index", "Admins");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Client");
                    }
                }    
            }
            TempData["Err"] = "Sai mật khẩu!";
            return RedirectToAction("Index");

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}