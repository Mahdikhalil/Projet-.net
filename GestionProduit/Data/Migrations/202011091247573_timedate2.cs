namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timedate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateProduction", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Providers", "DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Providers", "DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DateProduction", c => c.DateTime(nullable: false));
        }
    }
}
