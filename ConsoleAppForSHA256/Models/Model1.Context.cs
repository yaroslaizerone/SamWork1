﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAppForSHA256.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShoesFactoryEntities : DbContext
    {
        public ShoesFactoryEntities()
            : base("name=ShoesFactoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Change> Change { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialApplication> MaterialApplication { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderList> OrderList { get; set; }
        public virtual DbSet<Pattern> Pattern { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<ProductionCosts> ProductionCosts { get; set; }
        public virtual DbSet<RecyclingCompany> RecyclingCompany { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<SizeTable> SizeTable { get; set; }
        public virtual DbSet<Structure> Structure { get; set; }
        public virtual DbSet<SupplierCompani> SupplierCompani { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeFB> TypeFB { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WasteRequest> WasteRequest { get; set; }
        public virtual DbSet<Wastes> Wastes { get; set; }
    }
}
