﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("CodeFirst")
        {

        }

        public DbSet<Client> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Contains> Contains { get; set; }
        public DbSet<RecipeDrug> RecipeDrugs { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagerStatus> ManagerStatuses { get; set; }
        public DbSet<PackageStatus> PackageStatuses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
