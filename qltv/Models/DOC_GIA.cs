//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace qltv.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOC_GIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOC_GIA()
        {
            this.PHIEU_MUON_SACH = new HashSet<PHIEU_MUON_SACH>();
            this.PHIEU_THU_PHAT = new HashSet<PHIEU_THU_PHAT>();
        }
    
        public int MaDG { get; set; }
        public Nullable<int> MaLoaiDG { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string NgayLapThe { get; set; }
        public string TienNo { get; set; }
        public string HanThe { get; set; }
    
        public virtual LOAI_DOCGIA LOAI_DOCGIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEU_MUON_SACH> PHIEU_MUON_SACH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEU_THU_PHAT> PHIEU_THU_PHAT { get; set; }
    }
}
