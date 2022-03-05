﻿using System;
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
    public class KhachHangController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: KhachHang
        public ActionResult Index()
        {
            return View(db.TB_THEKHACHHANG.ToList());
        }

        // GET: KhachHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_THEKHACHHANG tB_THEKHACHHANG = db.TB_THEKHACHHANG.Find(id);
            if (tB_THEKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tB_THEKHACHHANG);
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATHEKHACHHANG,TENKHACHHANG,CMTND,NGAYSINH,NGAYDANGKY,MUCDOTHANTHIET")] TB_THEKHACHHANG tB_THEKHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.TB_THEKHACHHANG.Add(tB_THEKHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_THEKHACHHANG);
        }

        // GET: KhachHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_THEKHACHHANG tB_THEKHACHHANG = db.TB_THEKHACHHANG.Find(id);
            if (tB_THEKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tB_THEKHACHHANG);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATHEKHACHHANG,TENKHACHHANG,CMTND,NGAYSINH,NGAYDANGKY,MUCDOTHANTHIET")] TB_THEKHACHHANG tB_THEKHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_THEKHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_THEKHACHHANG);
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_THEKHACHHANG tB_THEKHACHHANG = db.TB_THEKHACHHANG.Find(id);
            if (tB_THEKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tB_THEKHACHHANG);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_THEKHACHHANG tB_THEKHACHHANG = db.TB_THEKHACHHANG.Find(id);
            db.TB_THEKHACHHANG.Remove(tB_THEKHACHHANG);
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
