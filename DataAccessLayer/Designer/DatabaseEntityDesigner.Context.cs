﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Designer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AptekaEntities : DbContext
    {
        public AptekaEntities()
            : base("name=AptekaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Contains> Contains { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Ingridients> Ingridients { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<ManagerStatus> ManagerStatus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<PackageStatus> PackageStatus { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<RecipeDrugs> RecipeDrugs { get; set; }
        public virtual DbSet<Shippings> Shippings { get; set; }
    }
}