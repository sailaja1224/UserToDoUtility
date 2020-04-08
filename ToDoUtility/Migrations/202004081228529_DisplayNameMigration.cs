namespace ToDoUtility.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DisplayName");
        }
    }
}
