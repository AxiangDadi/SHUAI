﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class XmEntities : DbContext
    {
        public XmEntities()
            : base("name=XmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<After> After { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Keeper> Keeper { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Dingdan> Dingdan { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Shoop> Shoop { get; set; }
    }
}
