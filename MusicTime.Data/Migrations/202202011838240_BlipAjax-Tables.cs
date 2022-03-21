namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlipAjaxTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        AddressTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.PostalAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Iso3 = c.String(maxLength: 3),
                        StreetAddress1 = c.String(maxLength: 100),
                        StreetAddress2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        RegionCode = c.String(maxLength: 3),
                        PostalCode = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Iso3)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionCode)
                .Index(t => t.CustomerID)
                .Index(t => t.Iso3)
                .Index(t => t.RegionCode);
            
            DropColumn("dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropForeignKey("dbo.PostalAddresses", "RegionCode", "dbo.Regions");
            DropForeignKey("dbo.PostalAddresses", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.PostalAddresses", "Iso3", "dbo.Countries");
            DropForeignKey("dbo.EmailAddresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.PostalAddresses", new[] { "RegionCode" });
            DropIndex("dbo.PostalAddresses", new[] { "Iso3" });
            DropIndex("dbo.PostalAddresses", new[] { "CustomerID" });
            DropIndex("dbo.EmailAddresses", new[] { "CustomerId" });
            DropTable("dbo.PostalAddresses");
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.AddressTypes");
        }
    }
}
