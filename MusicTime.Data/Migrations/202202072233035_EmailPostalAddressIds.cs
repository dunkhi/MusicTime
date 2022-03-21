namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailPostalAddressIds : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EmailAddresses");
            AddColumn("dbo.EmailAddresses", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.EmailAddresses", "IsDefault", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EmailAddresses", "Email", c => c.String());
            AddPrimaryKey("dbo.EmailAddresses", "Id");
            DropColumn("dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropPrimaryKey("dbo.EmailAddresses");
            AlterColumn("dbo.EmailAddresses", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.EmailAddresses", "IsDefault");
            DropColumn("dbo.EmailAddresses", "Id");
            AddPrimaryKey("dbo.EmailAddresses", "Email");
        }
    }
}
