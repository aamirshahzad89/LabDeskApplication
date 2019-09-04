namespace LabDeskApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcomments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogInitialStyle", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogInitialStyle", "Comments");
        }
    }
}
