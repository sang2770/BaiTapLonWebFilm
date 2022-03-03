using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tPhong
    {
        [Key]
        public string MaPhong { get; set; }
        public int SoPhong { get; set; }
        public string LoaiPhong { get; set; }

        public virtual List<tGhe>TGhes { get; set; }
    }
}