//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_63133302.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPhamGioHang
    {
        public int Id { get; set; }
        public Nullable<int> IdGH { get; set; }
        public Nullable<int> IdSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayThem { get; set; }
    
        public virtual GioHang GioHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
