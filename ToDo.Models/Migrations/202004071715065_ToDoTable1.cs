namespace ToDo.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDoTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserToDo", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserToDo", "IsDeleted");
        }
    }
}
