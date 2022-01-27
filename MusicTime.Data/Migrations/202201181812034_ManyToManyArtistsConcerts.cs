namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyArtistsConcerts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Concert_Id", c => c.Int());
            CreateIndex("dbo.Artists", "Concert_Id");
            CreateIndex("dbo.Concerts", "BandId");
            AddForeignKey("dbo.Artists", "Concert_Id", "dbo.Concerts", "Id");
            AddForeignKey("dbo.Concerts", "BandId", "dbo.Bands", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concerts", "BandId", "dbo.Bands");
            DropForeignKey("dbo.Artists", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.Concerts", new[] { "BandId" });
            DropIndex("dbo.Artists", new[] { "Concert_Id" });
            DropColumn("dbo.Artists", "Concert_Id");
        }
    }
}
