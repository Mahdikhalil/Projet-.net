namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacturePorteuse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        DateAchat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ClientFk = c.Int(nullable: false),
                        ProductFk = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DateAchat, t.ClientFk, t.ProductFk })
                .ForeignKey("dbo.Clients", t => t.ClientFk, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductFk, cascadeDelete: true)
                .Index(t => t.ClientFk)
                .Index(t => t.ProductFk);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CIN = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.CIN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factures", "ProductFk", "dbo.Products");
            DropForeignKey("dbo.Factures", "ClientFk", "dbo.Clients");
            DropIndex("dbo.Factures", new[] { "ProductFk" });
            DropIndex("dbo.Factures", new[] { "ClientFk" });
            DropTable("dbo.Clients");
            DropTable("dbo.Factures");
        }
    }
}
