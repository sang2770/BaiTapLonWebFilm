using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapLonWebFilm.Models;
using PagedList;
namespace BaiTapLonWebFilm.Areas.Admin.Controllers
{
    public class DoanhThuController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();
        // GET: Admin/DoanhThu
        public ActionResult Index(int? Nam)
        {
            // Thống kê các phim doanh thu cao
            var ReportFilm = from item in (
                             from movie in db.TB_PHIM
                             join caculator in db.TB_LICHCHIEU
                             on movie.MAPHIM equals caculator.MAPHIM
                             join ticket in db.TB_VEXEMPHIM
                             on caculator.MALICHCHIEU equals ticket.MALICHCHIEU
                             select new
                             {
                                 TenPhim = movie.TENPHIM,
                                 MaVe = ticket.MAVE
                             })
                             group item by item.MaVe into g
                             orderby g.Count() descending
                             select new {TenPhim=g.Key, Count=g.Count()}
                             ;
            ReportFilm.Take(6);
            foreach(var item in ReportFilm)
            {
                ViewData[""+item.TenPhim] = item.Count;
            }    
            // Thong ke so vé ván ra trong nam
            int year = Nam ?? DateTime.Now.Year;
            var query=from item in db.TB_VEXEMPHIM
                      where item.NgayLap.Year==year
                      select item;
            int[] TkNam = new int[12];    
            foreach(TB_VEXEMPHIM item in query)
            {
                DateTime ngaylap = item.NgayLap;
                TkNam[ngaylap.Month]+=1;
            }
            for(int i=0;i<12;i++)
            {
                ViewData["T"+(i+1)] = TkNam[i];
            }    
          
            return View();
        }

        
    }
}
