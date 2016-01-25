namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDatesToBeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Packages", "AssemblyDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Packages", "AssemblyDate", c => c.DateTime(nullable: false));
        }
    }
}
