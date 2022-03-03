using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BaiTapLonWebFilm.Models.Enity
{
    public class tNhanVien
    {
        [Key]
        public string MaNhanVien { get; set; } 
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CMTND { get; set; }
        public string QueQuan { get; set; }
        public string DiaChi    { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayVaoLam { get; set; }
    }
}