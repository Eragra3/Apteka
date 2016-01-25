namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkedSomething : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeDrugs", "EvaluatedByID", "dbo.Employees");
            DropIndex("dbo.RecipeDrugs", new[] { "EvaluatedByID" });
            DropColumn("dbo.RecipeDrugs", "EvaluatedByID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeDrugs", "EvaluatedByID", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeDrugs", "EvaluatedByID");
            AddForeignKey("dbo.RecipeDrugs", "EvaluatedByID", "dbo.Employees", "ID");
        }
    }
}
