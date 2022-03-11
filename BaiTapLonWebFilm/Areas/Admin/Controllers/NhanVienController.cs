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
    public class NhanVienController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: NhanVien
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pagenum = (page ?? 1);
            List<TB_NHANVIEN> list = db.TB_NHANVIEN.OrderBy(n => n.MANHANVIEN).ToList();
            ViewBag.Size = list.Count();
            return View(list.ToPagedList(pagenum, pageSize));
        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_NHANVIEN tB_NHANVIEN = db.TB_NHANVIEN.Find(id);
            if (tB_NHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tB_NHANVIEN);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TENNHANVIEN,NGAYSINH,CMTND,NGAYVAOLAM,QUEQUAN,DIACHI,SDT")] TB_NHANVIEN tB_NHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.TB_NHANVIEN.Add(tB_NHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_NHANVIEN);
        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_NHANVIEN tB_NHANVIEN = db.TB_NHANVIEN.Find(id);
            if (tB_NHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tB_NHANVIEN);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANHANVIEN,TENNHANVIEN,NGAYSINH,CMTND,NGAYVAOLAM,QUEQUAN,DIACHI,SDT")] TB_NHANVIEN tB_NHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_NHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_NHANVIEN);
        }

        // GET: NhanVien/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_NHANVIEN tB_NHANVIEN = db.TB_NHANVIEN.Find(id);
            if (tB_NHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(tB_NHANVIEN);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_NHANVIEN tB_NHANVIEN = db.TB_NHANVIEN.Find(id);
            db.TB_NHANVIEN.Remove(tB_NHANVIEN);
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
