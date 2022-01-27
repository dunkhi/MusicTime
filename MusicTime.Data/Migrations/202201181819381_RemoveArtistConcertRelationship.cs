namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveArtistConcertRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Artists", "Concert_Id", "dbo.Concerts");
            DropForeignKey("dbo.Concerts", "BandId", "dbo.Bands");
            DropIndex("dbo.Artists", new[] { "Concert_Id" });
            DropIndex("dbo.Concerts", new[] { "BandId" });
            CreateTable(
                "dbo.ConcertBands",
                c => new
                    {
                        Concert_Id = c.Int(nullable: false),
                        Band_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Concert_Id, t.Band_id })
                .ForeignKey("dbo.Concerts", t => t.Concert_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bands", t => t.Band_id, cascadeDelete: true)
                .Index(t => t.Concert_Id)
                .Index(t => t.Band_id);
            
            DropColumn("dbo.Artists", "Concert_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Concert_Id", c => c.Int());
            DropForeignKey("dbo.ConcertBands", "Band_id", "dbo.Bands");
            DropForeignKey("dbo.ConcertBands", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.ConcertBands", new[] { "Band_id" });
            DropIndex("dbo.ConcertBands", new[] { "Concert_Id" });
            DropTable("dbo.ConcertBands");
            CreateIndex("dbo.Concerts", "BandId");
            CreateIndex("dbo.Artists", "Concert_Id");
            AddForeignKey("dbo.Concerts", "BandId", "dbo.Bands", "id", cascadeDelete: true);
            AddForeignKey("dbo.Artists", "Concert_Id", "dbo.Concerts", "Id");
        }
    }
}
