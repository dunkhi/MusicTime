namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTypeChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AddressTypes");
            AddColumn("dbo.AddressTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.AddressTypes", "Addresstype", c => c.String());
            AddPrimaryKey("dbo.AddressTypes", "Id");
            DropColumn("dbo.AddressTypes", "AddressTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddressTypes", "AddressTypeId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.AddressTypes");
            DropColumn("dbo.AddressTypes", "Addresstype");
            DropColumn("dbo.AddressTypes", "Id");
            AddPrimaryKey("dbo.AddressTypes", "AddressTypeId");
        }
    }
}
