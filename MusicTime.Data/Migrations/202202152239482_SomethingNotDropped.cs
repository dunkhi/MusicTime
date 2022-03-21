namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomethingNotDropped : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerEditViewModels", "PostalAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerEditViewModels", "PostalAddressId");
            AddForeignKey("dbo.CustomerEditViewModels", "PostalAddressId", "dbo.PostalAddresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerEditViewModels", "PostalAddressId", "dbo.PostalAddresses");
            DropIndex("dbo.CustomerEditViewModels", new[] { "PostalAddressId" });
            DropColumn("dbo.CustomerEditViewModels", "PostalAddressId");
        }
    }
}
