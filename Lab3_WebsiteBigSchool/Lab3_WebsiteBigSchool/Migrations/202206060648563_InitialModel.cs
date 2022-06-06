namespace Lab3_WebsiteBigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cources", newName: "Courses");
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            RenameTable(name: "dbo.Courses", newName: "Cources");
        }
    }
}
