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

namespace BaiTapLonWebFilm.Areas.Client.Controllers
{
    public class TB_PHIMController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Client/TB_PHIM
        public ActionResult Index()
        {
            DateTime now=DateTime.Now;
            List<TB_PHIM> tB_PHIM= new List<TB_PHIM>();
            var query = (from movie in db.TB_PHIM
                         join  lich in db.TB_LICHCHIEU on movie.MAPHIM equals lich.MAPHIM
                         where lich.NGAYKETTHUC>now.Date
                         group new {movie,lich} by new {movie.MAPHIM,movie.TENPHIM,movie.MOTAPHIM,movie.HINHANH,
                         movie.QUOCGIA,movie.THOILUONG} into m
                         select new
                         {
                             m.Key.MAPHIM,
                             m.Key.TENPHIM,
                             m.Key.MOTAPHIM,
                             m.Key.HINHANH,
                             m.Key.QUOCGIA,
                             m.Key.THOILUONG,
                         }).ToList();
                         
            foreach (var t in query)
            {
                tB_PHIM.Add(new TB_PHIM
                {
                    MAPHIM = t.MAPHIM,
                    TENPHIM = t.TENPHIM,
                    MOTAPHIM = t.MOTAPHIM,
                    HINHANH = t.HINHANH,
                    QUOCGIA = t.QUOCGIA,
                    THOILUONG = t.THOILUONG,

                });
            }
            return View(tB_PHIM);
        }
         public ActionResult Loc(String Category)
        {
            DateTime now = DateTime.Now;
            List<TB_PHIM> tB_PHIM= new List<TB_PHIM>();
            var query = (from movie in db.TB_PHIM
                         join  lich in db.TB_LICHCHIEU on movie.MAPHIM equals lich.MAPHIM      
                         join category_phim in db.TB_Phim_LoaiPhim on movie.MAPHIM equals category_phim.MAPHIM
                         join category in db.TB_LOAIPHIM on category_phim.MALOAIPHIM equals category.MALOAIPHIM
                         where category.TENLOAIPHIM.Equals(Category) && lich.NGAYKETTHUC > now.Date
                         group new {movie,lich} by new {movie.MAPHIM,movie.TENPHIM,movie.MOTAPHIM,movie.HINHANH,
                         movie.QUOCGIA,movie.THOILUONG} into m
                         select new
                         {
                             m.Key.MAPHIM,
                             m.Key.TENPHIM,
                             m.Key.MOTAPHIM,
                             m.Key.HINHANH,
                             m.Key.QUOCGIA,
                             m.Key.THOILUONG,
                         }).ToList();
                         
            foreach (var t in query)
            {
                tB_PHIM.Add(new TB_PHIM
                {
                    MAPHIM = t.MAPHIM,
                    TENPHIM = t.TENPHIM,
                    MOTAPHIM = t.MOTAPHIM,
                    HINHANH = t.HINHANH,
                    QUOCGIA = t.QUOCGIA,
                    THOILUONG = t.THOILUONG,

                });
            }
            return View(tB_PHIM);
        }

        // GET: Client/TB_PHIM/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            List<TB_LICHCHIEU> lstlichchieu=db.TB_LICHCHIEU.Where(n=>n.MAPHIM==id).ToList();
            if (tB_PHIM == null)
            {
                return HttpNotFound();
            }
            if(lstlichchieu == null)
            {
                ViewBag.lstLichchieu = "Không có Lịch chiếu";
            }
            ViewBag.lstLichchieu=lstlichchieu;
            ViewBag.MaPhim = id;
            return View(tB_PHIM);
        }
        [HttpPost]
        public ActionResult timkiem(FormCollection f)
        {
            string searchkey = f["txtsearch"].ToString();

            IList<TB_PHIM> tB_PHIM = db.TB_PHIM.Where(n => n.TENPHIM.Contains(searchkey)).ToList();

            if (tB_PHIM.Count>0)
            {
                ViewBag.ThongBao = "Không tìm thấy phim bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(tB_PHIM);
            }
            ViewBag.keyword = searchkey;
            ViewBag.ThongBao = "Đã tìm thấy"  + "Phim";
            return View(tB_PHIM);
        }
        [HttpGet]
        public ActionResult timkiem( string searchkey)
        {
            ViewBag.keyword = searchkey;

            TB_PHIM tB_PHIM = db.TB_PHIM.Single(n => n.TENPHIM == searchkey);
            if (tB_PHIM == null)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(tB_PHIM);
            }
            ViewBag.ThongBao = "Đã tìm thấy" +  " Phim";
            return View(tB_PHIM);
        }




    }
}
