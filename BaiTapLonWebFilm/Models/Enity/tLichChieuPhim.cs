using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tLichChieuPhim
    {
        [Key]
        public string MaLichChieu { get; set; }
        public DateTime NgayChieu { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public string MaPhong { get; set; }

        public virtual tPhong tPhong { get; set; }
    }
}