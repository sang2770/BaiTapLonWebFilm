using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLonWebFilm.Models;

namespace BaiTapLonWebFilm.Controllers
{
    public class PhongController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Phong
        public ActionResult Index()
        {
            return View(db.TB_PHONG.ToList());
        }

        // GET: Phong/Details/5
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

        // GET: Phong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phong/Create
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

        // GET: Phong/Edit/5
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

        // POST: Phong/Edit/5
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

        // GET: Phong/Delete/5
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

        // POST: Phong/Delete/5
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
