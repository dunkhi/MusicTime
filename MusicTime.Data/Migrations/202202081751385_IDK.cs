namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostalAddresses", "CustomerID", "dbo.Customers");
            DropIndex("dbo.PostalAddresses", new[] { "CustomerID" });
            AlterColumn("dbo.PostalAddresses", "CustomerID", c => c.Int());
            CreateIndex("dbo.PostalAddresses", "CustomerID");
            AddForeignKey("dbo.PostalAddresses", "CustomerID", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostalAddresses", "CustomerID", "dbo.Customers");
            DropIndex("dbo.PostalAddresses", new[] { "CustomerID" });
            AlterColumn("dbo.PostalAddresses", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.PostalAddresses", "CustomerID");
            AddForeignKey("dbo.PostalAddresses", "CustomerID", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
