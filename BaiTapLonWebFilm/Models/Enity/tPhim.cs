using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BaiTapLonWebFilm.Models.Enity
{
    public class tPhim
    {
        [Key]
        public string MaPhim { get; set; }
        public string TenPhim { get; set; }
        public string QuocGia { get; set; }
        public string HinhAnh { get; set; }
        public string MotaPhim { get; set; }
        public int ThoiLuong { get; set; }
        public string MaLoaiPhim { get; set; }
        public virtual tLoaiPhim tLoaiPhim { set; get; }
    }
}