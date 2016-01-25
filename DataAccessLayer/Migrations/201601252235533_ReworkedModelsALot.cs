namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkedModelsALot : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contains", "ClientID", "dbo.Clients");
            DropIndex("dbo.Contains", new[] { "ClientID" });
            DropIndex("dbo.RecipeDrugs", new[] { "MadeByID" });
            DropPrimaryKey("dbo.Contains");
            AddColumn("dbo.Contains", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeDrugs", "PackageID", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeDrugs", "StatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.RecipeDrugs", "MadeByID", c => c.Int());
            AlterColumn("dbo.RecipeDrugs", "EvaluatedDate", c => c.DateTime());
            AddPrimaryKey("dbo.Contains", new[] { "OrderID", "ProductID" });
            CreateIndex("dbo.Contains", "ProductID");
            CreateIndex("dbo.RecipeDrugs", "PackageID");
            CreateIndex("dbo.RecipeDrugs", "MadeByID");
            CreateIndex("dbo.RecipeDrugs", "StatusID");
            AddForeignKey("dbo.Contains", "ProductID", "dbo.Products", "ID");
            AddForeignKey("dbo.RecipeDrugs", "PackageID", "dbo.Packages", "ID");
            AddForeignKey("dbo.RecipeDrugs", "StatusID", "dbo.OrderStatus", "ID");
            DropColumn("dbo.Contains", "ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contains", "ClientID", c => c.Int(nullable: false));
            DropForeignKey("dbo.RecipeDrugs", "StatusID", "dbo.OrderStatus");
            DropForeignKey("dbo.RecipeDrugs", "PackageID", "dbo.Packages");
            DropForeignKey("dbo.Contains", "ProductID", "dbo.Products");
            DropIndex("dbo.RecipeDrugs", new[] { "StatusID" });
            DropIndex("dbo.RecipeDrugs", new[] { "MadeByID" });
            DropIndex("dbo.RecipeDrugs", new[] { "PackageID" });
            DropIndex("dbo.Contains", new[] { "ProductID" });
            DropPrimaryKey("dbo.Contains");
            AlterColumn("dbo.RecipeDrugs", "EvaluatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RecipeDrugs", "MadeByID", c => c.Int(nullable: false));
            DropColumn("dbo.RecipeDrugs", "StatusID");
            DropColumn("dbo.RecipeDrugs", "PackageID");
            DropColumn("dbo.Contains", "ProductID");
            AddPrimaryKey("dbo.Contains", new[] { "OrderID", "ClientID" });
            CreateIndex("dbo.RecipeDrugs", "MadeByID");
            CreateIndex("dbo.Contains", "ClientID");
            AddForeignKey("dbo.Contains", "ClientID", "dbo.Clients", "ID");
        }
    }
}
