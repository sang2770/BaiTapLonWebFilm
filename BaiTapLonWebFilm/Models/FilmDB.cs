using BaiTapLonWebFilm.Models.Enity;
using System;
using System.Data.Entity;
using System.Linq;

namespace BaiTapLonWebFilm.Models
{
    public class FilmDB : DbContext
    {
        // Your context has been configured to use a 'FilmDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BaiTapLonWebFilm.Models.FilmDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FilmDB' 
        // connection string in the application configuration file.
        public FilmDB()
            : base("name=FilmDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<tNhanVien> tNhanViens { get; set; }
        public DbSet<tTaiKhoan> tTaiKhoans { get; set; }
        public DbSet<tPhim> tPhims { get; set; }
        public DbSet<tPhong> tPhongs { get; set; }
        public DbSet<tGhe> tGhes { get; set; }
        public DbSet<tLoaiGhe> tLoaiGhes { get; set; }
        public DbSet<tLichChieuPhim> tLichChieuPhims { get; set; }
        public DbSet<tTheKhachHang> tTheKhachHangs { get; set; }
        public DbSet<tVeXemPhim> tVeXemPhims { get; set; }
        public DbSet<tLoaiPhim> tLoaiPhims { get; set; }


    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}