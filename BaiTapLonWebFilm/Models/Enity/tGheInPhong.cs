using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tGheInPhong
    {
        public int MaGhe { get; set; }
        public int MaPhong { get; set; }
        public string TrangThai { get; set; }

        public virtual tGhe TGhe { get; set; }
        public virtual tPhong TPhong { get; set; }
    }
}