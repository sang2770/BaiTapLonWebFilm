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

        [HttpGet]
        // GET: NhanVien
        public ActionResult Index(int? page, int? id)
        {
            int pageSize = 5;
            int pagenum = (page ?? 1);
            //pagenum = pagenum > 0 ? pagenum : 1;
            List<TB_NHANVIEN> list = new List<TB_NHANVIEN>();
            if (id==null)
            {
                list = db.TB_NHANVIEN.OrderBy(n => n.MANHANVIEN).ToList();

            }
            else
            {
                list = db.TB_NHANVIEN.Where(n=>n.MANHANVIEN.ToString().Contains(id.ToString())).OrderBy(n => n.MANHANVIEN).ToList();

            }
            ViewBag.Size = list.Count();
            ViewBag.TotalPage=list.Count()%pageSize==0?list.Count()/pageSize:list.Count()/pageSize+1;
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
        public ActionResult Create([Bind(Include = "TENNHANVIEN,NGAYSINH,CMTND,NGAYVAOLAM,QUEQUAN,DIACHI,SDT, GIOITINH")] TB_NHANVIEN tB_NHANVIEN, HttpPostedFileBase ANH)
        {
            
                if (ModelState.IsValid)
                {
                    string savedFileName = "";  //string for saving the image server-side path          
                    if (ANH != null)
                    {
                        savedFileName = Server.MapPath("~/Image/nhanvien/" + "nhanvien_" + tB_NHANVIEN.TENNHANVIEN + "_" + tB_NHANVIEN.SDT + ".jpg"); //get the server-side path for store image 
                        ANH.SaveAs(savedFileName); //*save the image to server-side 
                    }
                var index = savedFileName.IndexOf(@"\Image\");

                tB_NHANVIEN.ANH = savedFileName.Substring(index, savedFileName.Length - index); ;
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
        public ActionResult Edit([Bind(Include = "TENNHANVIEN,NGAYSINH,CMTND,NGAYVAOLAM,QUEQUAN,DIACHI,SDT")] TB_NHANVIEN tB_NHANVIEN, int id)
        {
            if (ModelState.IsValid)
            {
                TB_NHANVIEN nhanvien = db.TB_NHANVIEN.Where(n => n.MANHANVIEN == id).FirstOrDefault();
                if(nhanvien!=null)
                {
                    nhanvien.TENNHANVIEN = tB_NHANVIEN.TENNHANVIEN;
                    nhanvien.NGAYSINH = tB_NHANVIEN.NGAYSINH;
                    nhanvien.CMTND = tB_NHANVIEN.CMTND;
                    nhanvien.NGAYVAOLAM = tB_NHANVIEN.NGAYVAOLAM;
                    nhanvien.QUEQUAN = tB_NHANVIEN.QUEQUAN;
                    nhanvien.DIACHI = tB_NHANVIEN.DIACHI;
                    nhanvien.SDT = tB_NHANVIEN.SDT;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
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
