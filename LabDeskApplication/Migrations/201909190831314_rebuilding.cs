namespace LabDeskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rebuilding : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.LogInitialVendor", "UsedLabID");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.LogInitialVendor", "UsedLabID", c => c.Boolean(nullable: false));
        }
    }
}
