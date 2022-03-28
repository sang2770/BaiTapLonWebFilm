using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLonWebFilm.Models;
using PagedList;

namespace BaiTapLonWebFilm.Areas.Admin.Controllers
{
    public class PhongController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Admin/Phong
        public ActionResult Index(int? size, int? page, int? id)
        {
            // 1. Số lượng trên 1 trang
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });
            items.Add(new SelectListItem { Text = "100", Value = "100" });
            items.Add(new SelectListItem { Text = "200", Value = "200" });
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            
            ViewBag.size = items; 
            ViewBag.currentSize = size; 

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;
            
            //Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);
            int pageNumber = (page ?? 1);
            List<TB_PHONG> list =new List<TB_PHONG>();
            if (id == null)
            {
                list = db.TB_PHONG.OrderBy(n => n.MAPHONG).ToList();

            }
            else
            {
                list = db.TB_PHONG.Where(n => n.MAPHONG.ToString().Contains(id.ToString())).OrderBy(n => n.MAPHONG).ToList();

            }
            return View(list.ToPagedList(pageNumber, pageSize));
       
        }

        // GET: Admin/Phong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHONG tB_PHONG = db.TB_PHONG.Find(id);
            if (tB_PHONG == null)
            {
                return HttpNotFound();
            }
            return View(tB_PHONG);
        }

        // GET: Admin/Phong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPHONG,SOPHONG,LOAIPHONG")] TB_PHONG tB_PHONG)
        {
            if (ModelState.IsValid)
            {
                db.TB_PHONG.Add(tB_PHONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_PHONG);
        }

        // GET: Admin/Phong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHONG tB_PHONG = db.TB_PHONG.Find(id);
            if (tB_PHONG == null)
            {
                return HttpNotFound();
            }
            return View(tB_PHONG);
        }

        // POST: Admin/Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPHONG,SOPHONG,LOAIPHONG")] TB_PHONG tB_PHONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PHONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_PHONG);
        }

        // GET: Admin/Phong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHONG tB_PHONG = db.TB_PHONG.Find(id);
            if (tB_PHONG == null)
            {
                return HttpNotFound();
            }
            return View(tB_PHONG);
        }

        // POST: Admin/Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PHONG tB_PHONG = db.TB_PHONG.Find(id);
            db.TB_PHONG.Remove(tB_PHONG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
