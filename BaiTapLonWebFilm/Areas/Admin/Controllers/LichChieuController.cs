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
    public class LichChieuController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Admin/LichChieu
        public ActionResult Index(int? size, int? page)
        {
            // 1. Tạo list pageSize để người dùng có thể chọn xem để phân trang
            // Bạn có thể thêm bớt tùy ý 
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });
            items.Add(new SelectListItem { Text = "100", Value = "100" });
            items.Add(new SelectListItem { Text = "200", Value = "200" });

            // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            // 1.2. Tạo các biến ViewBag
            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

            // 2. Nếu page = null thì đặt lại là 1.
            page = page ?? 1; //if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in db.TB_LICHCHIEU
                         select l).OrderBy(x => x.MALICHCHIEU);

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
            // return View(db.TB_PHIM.ToList());
           
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
            ViewBag.MAPHIM = new SelectList(db.TB_PHIM, "MAPHIM", "TENPHIM");
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "SOPHONG");
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
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "SOPHONG", tB_LICHCHIEU.MAPHONG);
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
            ViewBag.MAPHIM = new SelectList(db.TB_PHIM, "MAPHIM", "TENPHIM");
            ViewBag.MAPHONG = new SelectList(db.TB_PHONG, "MAPHONG", "MAPHONG");
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
