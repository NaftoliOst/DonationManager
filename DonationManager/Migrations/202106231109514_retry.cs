namespace DonationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Charities", "PersonID", "dbo.Persons");
            DropIndex("dbo.Charities", new[] { "PersonID" });
            AlterColumn("dbo.Charities", "PersonID", c => c.Int());
            CreateIndex("dbo.Charities", "PersonID");
            AddForeignKey("dbo.Charities", "PersonID", "dbo.Persons", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Charities", "PersonID", "dbo.Persons");
            DropIndex("dbo.Charities", new[] { "PersonID" });
            AlterColumn("dbo.Charities", "PersonID", c => c.Int(nullable: false));
            CreateIndex("dbo.Charities", "PersonID");
            AddForeignKey("dbo.Charities", "PersonID", "dbo.Persons", "ID", cascadeDelete: true);
        }
    }
}
