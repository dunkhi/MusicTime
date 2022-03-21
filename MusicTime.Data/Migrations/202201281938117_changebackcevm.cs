namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changebackcevm : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustomerEditViewModels");
            AddColumn("dbo.CustomerEditViewModels", "CustomerID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CustomerEditViewModels", "CustomerID");
            DropColumn("dbo.CustomerEditViewModels", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerEditViewModels", "id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.CustomerEditViewModels");
            DropColumn("dbo.CustomerEditViewModels", "CustomerID");
            AddPrimaryKey("dbo.CustomerEditViewModels", "id");
        }
    }
}
