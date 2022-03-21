namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CEVMadditionalfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerEditViewModels", "FirstName", c => c.String(maxLength: 75));
            AddColumn("dbo.CustomerEditViewModels", "LastName", c => c.String());
            AddColumn("dbo.CustomerEditViewModels", "UserName", c => c.String());
            AddColumn("dbo.CustomerEditViewModels", "Email", c => c.String());
            DropColumn("dbo.CustomerEditViewModels", "CustomerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerEditViewModels", "CustomerName", c => c.String(nullable: false, maxLength: 75));
            DropColumn("dbo.CustomerEditViewModels", "Email");
            DropColumn("dbo.CustomerEditViewModels", "UserName");
            DropColumn("dbo.CustomerEditViewModels", "LastName");
            DropColumn("dbo.CustomerEditViewModels", "FirstName");
        }
    }
}
