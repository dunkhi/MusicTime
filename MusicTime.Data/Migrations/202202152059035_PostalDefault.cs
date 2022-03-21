namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostalDefault : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostalAddresses", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostalAddresses", "IsDefault");
        }
    }
}
