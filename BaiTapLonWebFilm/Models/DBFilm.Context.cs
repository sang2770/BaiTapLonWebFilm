﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiTapLonWebFilm.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBFilmEntities1 : DbContext
    {
        public DBFilmEntities1()
            : base("name=DBFilmEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_GHE> TB_GHE { get; set; }
        public virtual DbSet<TB_GHE_TRONG_PHONG> TB_GHE_TRONG_PHONG { get; set; }
        public virtual DbSet<TB_LICHCHIEU> TB_LICHCHIEU { get; set; }
        public virtual DbSet<TB_LOAIGHE> TB_LOAIGHE { get; set; }
        public virtual DbSet<TB_LOAIPHIM> TB_LOAIPHIM { get; set; }
        public virtual DbSet<TB_NHANVIEN> TB_NHANVIEN { get; set; }
        public virtual DbSet<TB_PHIM> TB_PHIM { get; set; }
        public virtual DbSet<TB_Phim_LoaiPhim> TB_Phim_LoaiPhim { get; set; }
        public virtual DbSet<TB_PHONG> TB_PHONG { get; set; }
        public virtual DbSet<TB_TAIKHOAN> TB_TAIKHOAN { get; set; }
        public virtual DbSet<TB_THEKHACHHANG> TB_THEKHACHHANG { get; set; }
        public virtual DbSet<TB_VEXEMPHIM> TB_VEXEMPHIM { get; set; }
    }
}
