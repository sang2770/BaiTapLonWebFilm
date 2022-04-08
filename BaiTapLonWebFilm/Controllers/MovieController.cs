using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BaiTapLonWebFilm.Models;

namespace BaiTapLonWebFilm.Controllers
{
    public class MovieController : ApiController
    {
        private DBFilmEntities1 db = new DBFilmEntities1();

        // GET: api/Movie
        public IQueryable<TB_PHIM> GetTB_PHIM()
        {
            return db.TB_PHIM;
        }

        // GET: api/Movie/5
        [ResponseType(typeof(TB_PHIM))]
        public IHttpActionResult GetTB_PHIM(int id)
        {
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            if (tB_PHIM == null)
            {
                return NotFound();
            }

            return Ok(tB_PHIM);
        }

        // PUT: api/Movie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTB_PHIM(int id, TB_PHIM tB_PHIM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tB_PHIM.MAPHIM)
            {
                return BadRequest();
            }

            db.Entry(tB_PHIM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB_PHIMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movie
        [ResponseType(typeof(TB_PHIM))]
        public IHttpActionResult PostTB_PHIM(TB_PHIM tB_PHIM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TB_PHIM.Add(tB_PHIM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tB_PHIM.MAPHIM }, tB_PHIM);
        }

        // DELETE: api/Movie/5
        [ResponseType(typeof(TB_PHIM))]
        public IHttpActionResult DeleteTB_PHIM(int id)
        {
            TB_PHIM tB_PHIM = db.TB_PHIM.Find(id);
            if (tB_PHIM == null)
            {
                return NotFound();
            }

            db.TB_PHIM.Remove(tB_PHIM);
            db.SaveChanges();

            return Ok(tB_PHIM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TB_PHIMExists(int id)
        {
            return db.TB_PHIM.Count(e => e.MAPHIM == id) > 0;
        }
    }
}