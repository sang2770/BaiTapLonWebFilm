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
    public class PhimController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Admin/Phim
        public ActionResult Index()
        {
            return View(db.TB_PHIM.ToList());
        }

        // GET: Admin/Phim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            if (tB_PHIM == null)
            {
                return HttpNotFound();
            }
            return View(tB_PHIM);
        }

        // GET: Admin/Phim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPHIM,QUOCGIA,HINHANH,MOTAPHIM,THOILUONG,TENPHIM")] TB_PHIM tB_PHIM)
        {
            if (ModelState.IsValid)
            {
                db.TB_PHIM.Add(tB_PHIM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_PHIM);
        }

        // GET: Admin/Phim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            if (tB_PHIM == null)
            {
                return HttpNotFound();
            }
            return View(tB_PHIM);
        }

        // POST: Admin/Phim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPHIM,QUOCGIA,HINHANH,MOTAPHIM,THOILUONG,TENPHIM")] TB_PHIM tB_PHIM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PHIM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_PHIM);
        }

        // GET: Admin/Phim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            if (tB_PHIM == null)
            {
                return HttpNotFound();
            }
            return View(tB_PHIM);
        }

        // POST: Admin/Phim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            db.TB_PHIM.Remove(tB_PHIM);
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
