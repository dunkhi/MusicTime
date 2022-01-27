namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BandArtistDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bands", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Artists", "FirstName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Artists", "LastName", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "LastName", c => c.String());
            AlterColumn("dbo.Artists", "FirstName", c => c.String());
            AlterColumn("dbo.Bands", "Name", c => c.String(nullable: false));
        }
    }
}
