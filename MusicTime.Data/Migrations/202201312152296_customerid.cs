namespace MusicTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerEditViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 75),
                        SelectedCountryIso3 = c.String(nullable: false),
                        SelectedRegionCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerEditViewModels");
        }
    }
}
