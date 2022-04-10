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
        [Route("api/LichChieu/{MaPhim}/{Ngay}/{Thang}/{Nam}")]
        // Lay Thong tin lich chieu tung phim
        public IHttpActionResult GetLichChieu(int MaPhim, int Ngay, int Thang, int Nam)
        {
            IList<TB_LICHCHIEU> lichchieu = db.TB_LICHCHIEU
                .Where(n => n.MAPHIM == MaPhim)
                .Where(n => n.NGAYCHIEU.Year == Nam)
                .Where(n=>n.NGAYCHIEU.Month==Thang)
                .Where(n=>n.NGAYCHIEU.Day==Ngay)
                .ToList();
            return Ok(lichchieu);
        }
        [Route("api/KhacHang/{MaKH}")]
        // Lấy thông tin khách hàng bằng mã khách hàng
        public IHttpActionResult GetKhachHang(int MaKH)
        {
            TB_THEKHACHHANG khachhang = db.TB_THEKHACHHANG.Where(n => n.MATHEKHACHHANG == MaKH).SingleOrDefault();
            if(khachhang == null)
            {
                return NotFound();
            }    
            return Ok(khachhang);
        }
        [Route("api/PhongChieu/{MaPhong}")]

        // Chon phong chieu
        public IHttpActionResult GetPhongChieu(int MaPhong)
        {
            TB_PHONG phong = db.TB_PHONG.Where(n => n.MAPHONG == MaPhong).SingleOrDefault();
            if(phong==null)
            {
                return NotFound();

            }
            return Ok(phong);
        }
        [Route("api/GheTrongPhong/{MaPhong}")]

        // Lay So Ghe trong phong 
        public IHttpActionResult GetGheTrongPhong(int MaPhong)
        {
            var result = from phong in db.TB_PHONG
                         join GheInPhong in db.TB_GHE_TRONG_PHONG
                         on phong.MAPHONG equals GheInPhong.MAPHONG
                         join Ghe in db.TB_GHE
                         on GheInPhong.MAGHE equals Ghe.MAGHE
                         join LoaiGhe in db.TB_LOAIGHE
                         on Ghe.MALOAIGHE equals LoaiGhe.MALOAIGHE
                         where phong.MAPHONG==MaPhong
                         select new {Ghe.MAGHE,LoaiGhe.TENLOAIGHE, Ghe.SOGHE, GheInPhong.TRANGTHAI};
            if(result==null)
            {
                return NotFound();
            }    
            return Ok(result);
        }
        [Route("api/Check/{MaGhe}/{MaPhong}")]
        // Check ghe
        public IHttpActionResult PutGheBook(int MaGhe, int MaPhong)
        {
            TB_GHE_TRONG_PHONG ghe = db.TB_GHE_TRONG_PHONG.Where(n => n.MAPHONG == MaPhong).Where(n => n.MAGHE == MaGhe).SingleOrDefault();
            if (ghe == null)
            {
                return NotFound();
            }
            ghe.TRANGTHAI = "Đã đặt";
            db.SaveChanges();
            return Ok(ghe);
        }
        [Route("api/DatVe")]

        // Dat ve
        public IHttpActionResult PostVeXemPhim(TB_VEXEMPHIM ve)
        {
            try
            {
                ve.NgayLap = DateTime.Now;
                db.TB_VEXEMPHIM.Add(ve);
                db.SaveChanges();
            }catch(Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }


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