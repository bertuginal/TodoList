namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDateAddedAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "CreatedDate");
        }
    }
}
