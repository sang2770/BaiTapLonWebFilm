using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLonWebFilm.Models;

namespace BaiTapLonWebFilm.Areas.Client.Controllers
{
    public class TB_PHIMController : Controller
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: Client/TB_PHIM
        public ActionResult Index()
        {
            return View(db.TB_PHIM.ToList());
        }

        // GET: Client/TB_PHIM/Details/5
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


    }
}
