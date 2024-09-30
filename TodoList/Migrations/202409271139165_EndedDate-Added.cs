namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EndedDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "EndedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "EndedDate");
        }
    }
}
