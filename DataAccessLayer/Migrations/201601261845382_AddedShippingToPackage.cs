namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShippingToPackage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Packages", "ShippingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Packages", "ShippingID");
            AddForeignKey("dbo.Packages", "ShippingID", "dbo.Shippings", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "ShippingID", "dbo.Shippings");
            DropIndex("dbo.Packages", new[] { "ShippingID" });
            DropColumn("dbo.Packages", "ShippingID");
            DropTable("dbo.Shippings");
        }
    }
}
