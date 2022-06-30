namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistEditViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Instrument = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        ArtistBio = c.String(),
                        BandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistEditViewModels", "BandId", "dbo.Bands");
            DropIndex("dbo.ArtistEditViewModels", new[] { "BandId" });
            DropTable("dbo.ArtistEditViewModels");
        }
    }
}
