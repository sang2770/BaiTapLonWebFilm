using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tVeXemPhim
    {
        [Key]
        public string MaVe { get; set; }
        public int GiaVe    { get; set; }
        public string MaTaiKhoan { get; set; }
        public string MaLichChieu { get; set; }

        public virtual tLichChieuPhim TLichChieuPhim { get; set; }
        public virtual tTaiKhoan TTaiKhoan { get; set; }
    }
}