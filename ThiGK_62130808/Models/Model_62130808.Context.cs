﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThiGK_62130808.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ThiGK_62130808Entities : DbContext
    {
        public ThiGK_62130808Entities()
            : base("name=ThiGK_62130808Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DienThoai> DienThoais { get; set; }
        public virtual DbSet<LoaiDienThoai> LoaiDienThoais { get; set; }
    
        public virtual int DienThoai_TimKiem(string tenDT)
        {
            var tenDTParameter = tenDT != null ?
                new ObjectParameter("TenDT", tenDT) :
                new ObjectParameter("TenDT", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DienThoai_TimKiem", tenDTParameter);
        }
    }
}
