namespace ToDo.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserToDo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ToDoName = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserToDo");
        }
    }
}
