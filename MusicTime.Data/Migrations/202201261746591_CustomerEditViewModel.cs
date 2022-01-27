namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerEditViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerEditViewModels",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        CustomerName = c.String(nullable: false, maxLength: 75),
                        SelectedCountryIso3 = c.String(nullable: false),
                        SelectedRegionCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerEditViewModels");
        }
    }
}
