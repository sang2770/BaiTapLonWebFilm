using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tLoaiPhim
    {
        [Key]
        public string MaLoaiPhim { get; set; }
        public string TenLoaiPhim { get; set; }
        public virtual List<tPhim> Phims { get; set; }

    }
}