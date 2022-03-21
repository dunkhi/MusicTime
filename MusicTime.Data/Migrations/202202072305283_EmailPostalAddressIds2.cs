namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailPostalAddressIds2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailAddresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.EmailAddresses", new[] { "CustomerId" });
            AlterColumn("dbo.EmailAddresses", "CustomerId", c => c.Int());
            CreateIndex("dbo.EmailAddresses", "CustomerId");
            AddForeignKey("dbo.EmailAddresses", "CustomerId", "dbo.Customers", "Id");
            DropColumn("dbo.CustomerEditViewModels", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerEditViewModels", "Email", c => c.String());
            DropForeignKey("dbo.EmailAddresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.EmailAddresses", new[] { "CustomerId" });
            AlterColumn("dbo.EmailAddresses", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmailAddresses", "CustomerId");
            AddForeignKey("dbo.EmailAddresses", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
