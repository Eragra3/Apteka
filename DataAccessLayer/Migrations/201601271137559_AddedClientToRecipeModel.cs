namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientToRecipeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeDrugs", "ClientID", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeDrugs", "ClientID");
            AddForeignKey("dbo.RecipeDrugs", "ClientID", "dbo.Clients", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeDrugs", "ClientID", "dbo.Clients");
            DropIndex("dbo.RecipeDrugs", new[] { "ClientID" });
            DropColumn("dbo.RecipeDrugs", "ClientID");
        }
    }
}
