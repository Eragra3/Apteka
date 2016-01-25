namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkedRecipeDrugABit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingridients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RecipeDrugID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.RecipeDrugs", t => t.RecipeDrugID)
                .Index(t => t.RecipeDrugID)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.Products", "IsIngridient", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingridients", "RecipeDrugID", "dbo.RecipeDrugs");
            DropForeignKey("dbo.Ingridients", "ProductID", "dbo.Products");
            DropIndex("dbo.Ingridients", new[] { "ProductID" });
            DropIndex("dbo.Ingridients", new[] { "RecipeDrugID" });
            DropColumn("dbo.Products", "IsIngridient");
            DropTable("dbo.Ingridients");
        }
    }
}
