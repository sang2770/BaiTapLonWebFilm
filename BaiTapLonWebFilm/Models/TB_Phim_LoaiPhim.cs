//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TB_Phim_LoaiPhim
    {
        public int MAPHIM { get; set; }
        public int MALOAIPHIM { get; set; }
        public int MA { get; set; }
    
        public virtual TB_LOAIPHIM TB_LOAIPHIM { get; set; }
        public virtual TB_PHIM TB_PHIM { get; set; }
    }
}
