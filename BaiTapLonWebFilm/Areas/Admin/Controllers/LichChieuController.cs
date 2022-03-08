using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLonWebFilm.Models;

namespace BaiTapLonWebFilm.Areas.Admin.Controllers
{
    public class LichChieuController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Admin/LichChieu
        public ActionResult Index()
        {
            var tB_LICHCHIEU = db.TB_LICHCHIEU.Include(t => t.TB_PHIM).Include(t => t.TB_PHONG);
            return View(tB_LICHCHIEU.ToList());
        }

        // GET: Admin/LichChieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_LICHCHIEU tB_LICHCHIEU = db.TB_LICHCHIEU.Find(id);
            if (tB_LICHCHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tB_LICHCHIEU);
        }

        // GET: Admin/LichChieu/Create
        public ActionResult Create()
        {
            ViewBag.MAPHIM = new SelectList(db.TB_PHIM, "MAPHIM", "QUOCGIA");
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "LOAIPHONG");
            return View();
        }

        // POST: Admin/LichChieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALICHCHIEU,NGAYCHIEU,NGAYKETTHUC,MAPHONG,MAPHIM")] TB_LICHCHIEU tB_LICHCHIEU)
        {
            if (ModelState.IsValid)
            {
                db.TB_LICHCHIEU.Add(tB_LICHCHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAPHIM = new SelectList(db.TB_PHIM, "MAPHIM", "QUOCGIA", tB_LICHCHIEU.MAPHIM);
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "LOAIPHONG", tB_LICHCHIEU.MAPHONG);
            return View(tB_LICHCHIEU);
        }

        // GET: Admin/LichChieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_LICHCHIEU tB_LICHCHIEU = db.TB_LICHCHIEU.Find(id);
            if (tB_LICHCHIEU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAPHIM = new SelectList(db.TB_PHIM, "MAPHIM", "QUOCGIA", tB_LICHCHIEU.MAPHIM);
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "LOAIPHONG", tB_LICHCHIEU.MAPHONG);
            return View(tB_LICHCHIEU);
        }

        // POST: Admin/LichChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALICHCHIEU,NGAYCHIEU,NGAYKETTHUC,MAPHONG,MAPHIM")] TB_LICHCHIEU tB_LICHCHIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_LICHCHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAPHIM = new SelectList(db.TB_PHIM, "MAPHIM", "QUOCGIA", tB_LICHCHIEU.MAPHIM);
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "LOAIPHONG", tB_LICHCHIEU.MAPHONG);
            return View(tB_LICHCHIEU);
        }

        // GET: Admin/LichChieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_LICHCHIEU tB_LICHCHIEU = db.TB_LICHCHIEU.Find(id);
            if (tB_LICHCHIEU == null)
            {
                return HttpNotFound();
            }
            return View(tB_LICHCHIEU);
        }

        // POST: Admin/LichChieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_LICHCHIEU tB_LICHCHIEU = db.TB_LICHCHIEU.Find(id);
            db.TB_LICHCHIEU.Remove(tB_LICHCHIEU);
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
