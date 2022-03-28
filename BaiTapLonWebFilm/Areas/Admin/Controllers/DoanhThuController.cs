using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapLonWebFilm.Areas.Admin.Controllers
{
    public class DoanhThuController : Controller
    {
        // GET: Admin/DoanhThu
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/DoanhThu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DoanhThu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DoanhThu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DoanhThu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DoanhThu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DoanhThu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DoanhThu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
