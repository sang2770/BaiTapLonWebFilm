using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tTheKhachHang
    {
        [Key]
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CMTND { get; set; }
        public string MucDoThanThiet { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgaySinh    { get; set; }
        public virtual List<tVeXemPhim> tVeXemPhim { get; set; }
    }
}