namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompletionTimeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "CompletionTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "CompletionTime");
        }
    }
}
