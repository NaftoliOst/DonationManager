namespace DonationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovePersonConnection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "PersonID", "dbo.Persons");
            DropIndex("dbo.Donations", new[] { "PersonID" });
            DropColumn("dbo.Donations", "PersonID");            
            AddColumn("dbo.Charities", "CharityNumber", c => c.String());
            
            
            AddColumn("dbo.Charities", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Charities", "PersonID");
            AddForeignKey("dbo.Charities", "PersonID", "dbo.Persons", "ID", cascadeDelete:false);
            
        }
        
        public override void Down()
        {
            
            DropIndex("dbo.Charities", new[] { "PersonID" });
            DropColumn("dbo.Charities", "PersonID");
            DropColumn("dbo.Charities", "CharityNumber");
            DropForeignKey("dbo.Charities", "PersonID", "dbo.Persons");
            AddColumn("dbo.Donations", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Donations", "PersonID");
            AddForeignKey("dbo.Donations", "PersonID", "dbo.Persons", "ID", cascadeDelete: true);
        }
    }
}
