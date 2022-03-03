using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tGhe
    {
        [Key]
        public string MaGhe { get; set; }
        public string MaLoaiGhe { get; set; }
        public virtual tLoaiGhe TLoaiGhe    { get; set; }

    }
}