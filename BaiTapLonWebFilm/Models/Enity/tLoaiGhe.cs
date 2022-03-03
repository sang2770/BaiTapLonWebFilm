using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tLoaiGhe
    {
        [Key]
        public string MaLoaiGhe { get; set; }
        public string TenLoaiGhe { get;set; }
        public string GiaGhe { get;set; }
        public virtual List<tGhe>TGhes  { get; set; }
    }
}