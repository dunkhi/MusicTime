namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionCountry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Iso3 = c.String(nullable: false, maxLength: 3),
                        CountryNameEnglish = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Iso3);
            
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
            
            AddColumn("dbo.Customers", "CountryIso3", c => c.String(maxLength: 3));
            AddColumn("dbo.Customers", "RegionCode", c => c.String(maxLength: 3));
            CreateIndex("dbo.Customers", "CountryIso3");
            CreateIndex("dbo.Customers", "RegionCode");
            AddForeignKey("dbo.Customers", "CountryIso3", "dbo.Countries", "Iso3");
            AddForeignKey("dbo.Customers", "RegionCode", "dbo.Regions", "RegionCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "RegionCode", "dbo.Regions");
            DropForeignKey("dbo.Regions", "Iso3", "dbo.Countries");
            DropForeignKey("dbo.Customers", "CountryIso3", "dbo.Countries");
            DropIndex("dbo.Regions", new[] { "Iso3" });
            DropIndex("dbo.Customers", new[] { "RegionCode" });
            DropIndex("dbo.Customers", new[] { "CountryIso3" });
            DropColumn("dbo.Customers", "RegionCode");
            DropColumn("dbo.Customers", "CountryIso3");
            DropTable("dbo.Regions");
            DropTable("dbo.Countries");
        }
    }
}
