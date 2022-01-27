namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueConcerts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "FinalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Concerts", "VenueId");
            CreateIndex("dbo.Tickets", "ConcertId");
            AddForeignKey("dbo.Concerts", "VenueId", "dbo.Venues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts");
            DropForeignKey("dbo.Concerts", "VenueId", "dbo.Venues");
            DropIndex("dbo.Tickets", new[] { "ConcertId" });
            DropIndex("dbo.Concerts", new[] { "VenueId" });
            DropColumn("dbo.CustomerOrders", "FinalPrice");
        }
    }
}
