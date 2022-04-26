namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Addresstype = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BandId = c.Int(nullable: false),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        BandBio = c.String(),
                        Logo = c.String(),
                        Photo = c.String(),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        FullName = c.String(),
                        Instrument = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        ArtistBio = c.String(),
                        BandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId);
            
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        BandId = c.Int(nullable: false),
                        ConcertDate = c.DateTime(nullable: false, storeType: "date"),
                        VenueId = c.Int(nullable: false),
                        TicketsAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.BandId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConcertId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Seat = c.String(),
                        Area = c.String(),
                        TicketType = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concerts", t => t.ConcertId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ConcertId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CustomerOrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerOrder2", t => t.CustomerOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerOrderId);
            
            CreateTable(
                "dbo.CustomerOrder2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false, storeType: "date"),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FullName = c.String(),
                        UserName = c.String(),
                        CountryIso3 = c.String(maxLength: 3),
                        RegionCode = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryIso3)
                .ForeignKey("dbo.Regions", t => t.RegionCode)
                .Index(t => t.CountryIso3)
                .Index(t => t.RegionCode);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Iso3 = c.String(nullable: false, maxLength: 3),
                        CountryNameEnglish = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Iso3);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CustomerId = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.PostalAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        VenueId = c.Int(),
                        IsDefault = c.Boolean(),
                        Iso3 = c.String(maxLength: 3),
                        StreetAddress1 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        RegionCode = c.String(maxLength: 3),
                        PostalCode = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Iso3)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Regions", t => t.RegionCode)
                .ForeignKey("dbo.Venues", t => t.VenueId)
                .Index(t => t.CustomerId)
                .Index(t => t.VenueId)
                .Index(t => t.Iso3)
                .Index(t => t.RegionCode);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionCode = c.String(nullable: false, maxLength: 3),
                        Iso3 = c.String(nullable: false, maxLength: 3),
                        RegionNameEnglish = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionCode)
                .ForeignKey("dbo.Countries", t => t.Iso3, cascadeDelete: true)
                .Index(t => t.Iso3);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Capacity = c.Int(nullable: false),
                        Photo = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "CustomerOrderId", "dbo.CustomerOrder2");
            DropForeignKey("dbo.Customers", "RegionCode", "dbo.Regions");
            DropForeignKey("dbo.PostalAddresses", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.Concerts", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.PostalAddresses", "RegionCode", "dbo.Regions");
            DropForeignKey("dbo.Regions", "Iso3", "dbo.Countries");
            DropForeignKey("dbo.PostalAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PostalAddresses", "Iso3", "dbo.Countries");
            DropForeignKey("dbo.EmailAddresses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerOrder2", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CountryIso3", "dbo.Countries");
            DropForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts");
            DropForeignKey("dbo.Concerts", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Artists", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Albums", "BandId", "dbo.Bands");
            DropIndex("dbo.Regions", new[] { "Iso3" });
            DropIndex("dbo.PostalAddresses", new[] { "RegionCode" });
            DropIndex("dbo.PostalAddresses", new[] { "Iso3" });
            DropIndex("dbo.PostalAddresses", new[] { "VenueId" });
            DropIndex("dbo.PostalAddresses", new[] { "CustomerId" });
            DropIndex("dbo.EmailAddresses", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "RegionCode" });
            DropIndex("dbo.Customers", new[] { "CountryIso3" });
            DropIndex("dbo.CustomerOrder2", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetails", new[] { "CustomerOrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Tickets", new[] { "ProductId" });
            DropIndex("dbo.Tickets", new[] { "ConcertId" });
            DropIndex("dbo.Concerts", new[] { "VenueId" });
            DropIndex("dbo.Concerts", new[] { "BandId" });
            DropIndex("dbo.Artists", new[] { "BandId" });
            DropIndex("dbo.Albums", new[] { "BandId" });
            DropTable("dbo.Venues");
            DropTable("dbo.Regions");
            DropTable("dbo.PostalAddresses");
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.Countries");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrder2");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Tickets");
            DropTable("dbo.Concerts");
            DropTable("dbo.Artists");
            DropTable("dbo.Bands");
            DropTable("dbo.Albums");
            DropTable("dbo.AddressTypes");
        }
    }
}
