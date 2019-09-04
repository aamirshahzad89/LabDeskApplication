namespace LabDeskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecomments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestValues", "Comments", c => c.String());
            DropColumn("dbo.LogInitialStyle", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogInitialStyle", "Comments", c => c.String());
            DropColumn("dbo.TestValues", "Comments");
        }
    }
}
