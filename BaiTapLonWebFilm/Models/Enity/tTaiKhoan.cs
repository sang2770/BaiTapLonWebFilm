using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BaiTapLonWebFilm.Models.Enity
{
    public class tTaiKhoan
    {
        [Key]
        public string MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string LoaiTaiKhoan { get; set; }    
        public string MatKhau { set; get; }
        public string MaNhanVien { set; get; }
        public virtual tNhanVien tNhanVien { get; set; }
        public virtual List<tVeXemPhim> TVeXemPhims { get; set; }   
    }
}