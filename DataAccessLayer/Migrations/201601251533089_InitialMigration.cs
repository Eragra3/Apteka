namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contains",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ClientID })
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        NIP = c.String(),
                        Address_City = c.String(),
                        Address_Street = c.String(),
                        Address_ZipCode = c.String(),
                        Address_HouseNumber = c.String(),
                        Address_ApartmentNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PackageID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Packages", t => t.PackageID)
                .ForeignKey("dbo.OrderStatus", t => t.StatusID)
                .Index(t => t.PackageID)
                .Index(t => t.ClientID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Address_City = c.String(),
                        Address_Street = c.String(),
                        Address_ZipCode = c.String(),
                        Address_HouseNumber = c.String(),
                        Address_ApartmentNumber = c.String(),
                        AssemblyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        Index = c.String(),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Positions", t => t.PositionID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.ClientID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .ForeignKey("dbo.ManagerStatus", t => t.StatusID)
                .Index(t => t.EmployeeID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.ManagerStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PackageStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(maxLength: 100),
                        InOffer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.RecipeDrugs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EvaluatedByID = c.Int(nullable: false),
                        MadeByID = c.Int(nullable: false),
                        EvaluatedDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EvaluatedByID)
                .ForeignKey("dbo.Employees", t => t.MadeByID)
                .Index(t => t.EvaluatedByID)
                .Index(t => t.MadeByID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeDrugs", "MadeByID", "dbo.Employees");
            DropForeignKey("dbo.RecipeDrugs", "EvaluatedByID", "dbo.Employees");
            DropForeignKey("dbo.Managers", "StatusID", "dbo.ManagerStatus");
            DropForeignKey("dbo.Managers", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Invoices", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Employees", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Orders", "StatusID", "dbo.OrderStatus");
            DropForeignKey("dbo.Contains", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "PackageID", "dbo.Packages");
            DropForeignKey("dbo.Orders", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Contains", "ClientID", "dbo.Clients");
            DropIndex("dbo.RecipeDrugs", new[] { "MadeByID" });
            DropIndex("dbo.RecipeDrugs", new[] { "EvaluatedByID" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Managers", new[] { "StatusID" });
            DropIndex("dbo.Managers", new[] { "EmployeeID" });
            DropIndex("dbo.Invoices", new[] { "OrderID" });
            DropIndex("dbo.Invoices", new[] { "ClientID" });
            DropIndex("dbo.Employees", new[] { "PositionID" });
            DropIndex("dbo.Orders", new[] { "StatusID" });
            DropIndex("dbo.Orders", new[] { "ClientID" });
            DropIndex("dbo.Orders", new[] { "PackageID" });
            DropIndex("dbo.Contains", new[] { "ClientID" });
            DropIndex("dbo.Contains", new[] { "OrderID" });
            DropTable("dbo.RecipeDrugs");
            DropTable("dbo.Products");
            DropTable("dbo.PackageStatus");
            DropTable("dbo.ManagerStatus");
            DropTable("dbo.Managers");
            DropTable("dbo.Invoices");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Packages");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
            DropTable("dbo.Contains");
        }
    }
}
