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
    
    public partial class BAOCAOSACHTRATRE
    {
        public int MaBaoCaoSachTraTre { get; set; }
        public Nullable<int> MaSach { get; set; }
        public string GhiChu { get; set; }
        public string SoNgayTraTre { get; set; }
    
        public virtual SACH SACH { get; set; }
    }
}
