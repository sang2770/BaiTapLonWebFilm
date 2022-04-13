using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BaiTapLonWebFilm.Models;
using PagedList;

namespace BaiTapLonWebFilm.Areas.Admin.Controllers
{
    public class PhimController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Admin/Phim
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
            var links = (from l in db.TB_PHIM
                         select l).OrderBy(x => x.MAPHIM);

            // 4. Tạo kích thước trang (pageSize), mặc định là 5.
            int pageSize = (size ?? 5);

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
           // return View(db.TB_PHIM.ToList());
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
            ViewBag.TENLOAIPHIM = new SelectList(db.TB_LOAIPHIM.OrderBy(n => n.MALOAIPHIM), "MALOAIPHIM", "TENLOAIPHIM");
            return View();
        }

        // POST: Admin/Phim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPHIM,QUOCGIA,HINHANH,MOTAPHIM,THOILUONG,TENPHIM")] TB_PHIM tB_PHIM, HttpPostedFileBase ANH,FormCollection f)
        {
            if (ModelState.IsValid)
            {
                string savedFileName = "";  //string for saving the image server-side path          
                if (ANH != null)
                {
                    savedFileName = Server.MapPath("~/Image/movies/" + tB_PHIM.TENPHIM + ".jpg"); //get the server-side path for store image 
                    ANH.SaveAs(savedFileName); //*save the image to server-side 
                }
                tB_PHIM.HINHANH = tB_PHIM.TENPHIM + ".jpg"; 
                db.TB_PHIM.Add(tB_PHIM);
                var maloai = Request.Form["TENLOAIPHIM"];
              
                TB_Phim_LoaiPhim tB_Phim_LoaiPhim = new TB_Phim_LoaiPhim();
                
                {
                    tB_Phim_LoaiPhim.MAPHIM = tB_PHIM.MAPHIM;
                    tB_Phim_LoaiPhim.MALOAIPHIM = int.Parse(maloai);
                    db.TB_Phim_LoaiPhim.Add(tB_Phim_LoaiPhim);
                }
               

                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

            return View(tB_PHIM);
        }

        // GET: Admin/Phim/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.TENLOAIPHIM = new SelectList(db.TB_LOAIPHIM.OrderBy(n => n.MALOAIPHIM), "MALOAIPHIM", "TENLOAIPHIM");
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
        public ActionResult Edit([Bind(Include = "MAPHIM,QUOCGIA,HINHANH,MOTAPHIM,THOILUONG,TENPHIM")] TB_PHIM tB_PHIM, int id, HttpPostedFileBase ANH)
        {
            TB_PHIM movie = db.TB_PHIM.Where(n => n.MAPHIM == id).FirstOrDefault();
            if (movie != null)
            {
                string savedFileName = "";  //string for saving the image server-side path          
                if (ANH != null)
                {
                    savedFileName = Server.MapPath("~/Image/movies/" + tB_PHIM.TENPHIM + ".jpg"); //get the server-side path for store image 
                    ANH.SaveAs(savedFileName); //*save the image to server-side 
                }
                var index = savedFileName.IndexOf(@"\Image\");

                movie.HINHANH = tB_PHIM.TENPHIM + ".jpg"; ;
                movie.MAPHIM = id;
                movie.QUOCGIA = tB_PHIM.QUOCGIA;
                movie.MOTAPHIM = tB_PHIM.MOTAPHIM;
                movie.THOILUONG= tB_PHIM.THOILUONG;
                movie.TENPHIM = tB_PHIM.TENPHIM;
              
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
            List<TB_Phim_LoaiPhim> tB_Phim_LoaiPhims=db.TB_Phim_LoaiPhim.Where(n=>n.MAPHIM==id).ToList();
            db.TB_PHIM.Remove(tB_PHIM);
            foreach(TB_Phim_LoaiPhim item in tB_Phim_LoaiPhims)
            {
                db.TB_Phim_LoaiPhim.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult timkiem(FormCollection f, int? page)
        {
            string searchkey = f["txtsearch"].ToString();
            
            List<TB_PHIM> lstSearchResults = db.TB_PHIM.Where(n => n.TENPHIM.Contains(searchkey)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 5;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy phim bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.TB_PHIM.OrderBy(n => n.TENPHIM).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.keyword = searchkey;
            ViewBag.ThongBao = "Đã tìm thấy" + lstSearchResults.Count + "sản phẩm";
            return View(lstSearchResults.OrderBy(n => n.TENPHIM).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult timkiem(int? page, string searchkey)
        {
            ViewBag.keyword = searchkey;
            List<TB_PHIM> lstSearchResults = db.TB_PHIM.Where(n => n.TENPHIM.Contains(searchkey)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 5;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.TB_PHIM.OrderBy(n => n.TENPHIM).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstSearchResults.Count + "sản phẩm";
            return View(lstSearchResults.OrderBy(n => n.TENPHIM).ToPagedList(pagenumber, pagesize));
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
