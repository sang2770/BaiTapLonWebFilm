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
    using System.ComponentModel.DataAnnotations;
    public partial class TB_GHE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_GHE()
        {
            this.TB_GHE_TRONG_PHONG = new HashSet<TB_GHE_TRONG_PHONG>();
        }
        public int MAGHE { get; set; }
        public long SOGHE { get; set; }
        public int MALOAIGHE { get; set; }
    
        public virtual TB_LOAIGHE TB_LOAIGHE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_GHE_TRONG_PHONG> TB_GHE_TRONG_PHONG { get; set; }
    }
}
