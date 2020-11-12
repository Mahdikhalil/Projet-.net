namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Adress_StreetAddress", c => c.String());
            AddColumn("dbo.Products", "Adress_City", c => c.String());
            DropColumn("dbo.Products", "StreetAddress");
            DropColumn("dbo.Products", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "City", c => c.String());
            AddColumn("dbo.Products", "StreetAddress", c => c.String());
            DropColumn("dbo.Products", "Adress_City");
            DropColumn("dbo.Products", "Adress_StreetAddress");
        }
    }
}
