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
    public class GheController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Admin/Ghe
        public ActionResult Index(int ? page)
        {
            int pageSize = 10;
            int pagenum = (page ?? 1);
            List<TB_GHE> list = db.TB_GHE.OrderBy(n => n.MAGHE).ToList();
            ViewBag.Size = list.Count();
            return View(list.ToPagedList(pagenum, pageSize));
        }

        // GET: Admin/Ghe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_GHE tB_GHE = db.TB_GHE.Find(id);
            if (tB_GHE == null)
            {
                return HttpNotFound();
            }
            return View(tB_GHE);
        }

        // GET: Admin/Ghe/Create
        public ActionResult Create()
        {
            ViewBag.MALOAIGHE = new SelectList(db.TB_LOAIGHE, "MALOAIGHE", "TENLOAIGHE");
            return View();
        }

        // POST: Admin/Ghe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAGHE,SOGHE,MALOAIGHE")] TB_GHE tB_GHE, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                int maPhong = int.Parse(f["txtMaPhong"].ToString());
                TB_PHONG tB_PHONG = db.TB_PHONG.Find(maPhong);
                if (maPhong != null)
                {
                    
                    TB_GHE_TRONG_PHONG tB_GHE_TRONG_PHONG = new TB_GHE_TRONG_PHONG();
                    tB_GHE_TRONG_PHONG.MAGHE = tB_GHE.MAGHE;
                    tB_GHE_TRONG_PHONG.MAPHONG = maPhong;
                    db.TB_GHE_TRONG_PHONG.Add(tB_GHE_TRONG_PHONG);
                }

                db.TB_GHE.Add(tB_GHE);
                db.SaveChanges();
              
                return RedirectToAction("Index");
            }

            ViewBag.MALOAIGHE = new SelectList(db.TB_LOAIGHE, "MALOAIGHE", "TENLOAIGHE", tB_GHE.MALOAIGHE);
            return View(tB_GHE);
        }

        // GET: Admin/Ghe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_GHE tB_GHE = db.TB_GHE.Find(id);
            if (tB_GHE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MALOAIGHE = new SelectList(db.TB_LOAIGHE, "MALOAIGHE", "TENLOAIGHE", tB_GHE.MALOAIGHE);
            return View(tB_GHE);
        }

        // POST: Admin/Ghe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAGHE,SOGHE,MALOAIGHE")] TB_GHE tB_GHE, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                int maPhong = int.Parse(f["txtMaPhong"].ToString());
                TB_PHONG tB_PHONG = db.TB_PHONG.Find(maPhong);
                if (maPhong != null)
                {
                    TB_GHE_TRONG_PHONG tB_GHE_TRONG_PHONG = new TB_GHE_TRONG_PHONG();
                    tB_GHE_TRONG_PHONG.MAGHE = tB_GHE.MAGHE;
                    tB_GHE_TRONG_PHONG.MAPHONG = maPhong;
                    db.TB_GHE_TRONG_PHONG.Add(tB_GHE_TRONG_PHONG);
                }

                db.TB_GHE.Add(tB_GHE);
                db.SaveChanges();
                db.Entry(tB_GHE).State = EntityState.Modified;     
                return RedirectToAction("Index");
            }
            db.SaveChanges();
            ViewBag.MALOAIGHE = new SelectList(db.TB_LOAIGHE, "MALOAIGHE", "TENLOAIGHE", tB_GHE.MALOAIGHE);
            return View(tB_GHE);
        }

        // GET: Admin/Ghe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_GHE tB_GHE = db.TB_GHE.Find(id);
            if (tB_GHE == null)
            {
                return HttpNotFound();
            }
            return View(tB_GHE);
        }

        // POST: Admin/Ghe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_GHE tB_GHE = db.TB_GHE.Find(id);
            db.TB_GHE.Remove(tB_GHE);
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
