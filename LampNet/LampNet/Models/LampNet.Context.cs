﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LampNet.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LampNetEntities : DbContext
    {
        public LampNetEntities()
            : base("name=LampNetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_AMMETER> TBL_AMMETER { get; set; }
        public virtual DbSet<TBL_CTRCONTROL> TBL_CTRCONTROL { get; set; }
        public virtual DbSet<TBL_DEVICEPROTECT> TBL_DEVICEPROTECT { get; set; }
        public virtual DbSet<TBL_DOCUMENT> TBL_DOCUMENT { get; set; }
        public virtual DbSet<TBL_ENERGY> TBL_ENERGY { get; set; }
        public virtual DbSet<TBL_FEEDBACK> TBL_FEEDBACK { get; set; }
        public virtual DbSet<TBL_RUN> TBL_RUN { get; set; }
        public virtual DbSet<TBL_RUNNOTE> TBL_RUNNOTE { get; set; }
        public virtual DbSet<TBL_SIGCONTROL> TBL_SIGCONTROL { get; set; }
        public virtual DbSet<TBL_SITE> TBL_SITE { get; set; }
        public virtual DbSet<TBL_SYSSET> TBL_SYSSET { get; set; }
        public virtual DbSet<TBL_USER> TBL_USER { get; set; }
        public virtual DbSet<TBL_USERPROTECT> TBL_USERPROTECT { get; set; }
    }
}
