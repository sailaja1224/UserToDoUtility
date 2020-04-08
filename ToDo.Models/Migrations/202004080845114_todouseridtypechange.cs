namespace ToDo.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todouseridtypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserToDo", "CreatedBy", c => c.String());
            AlterColumn("dbo.UserToDo", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserToDo", "ModifiedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.UserToDo", "CreatedBy", c => c.Int(nullable: false));
        }
    }
}
