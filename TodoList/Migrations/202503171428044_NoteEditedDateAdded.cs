namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteEditedDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "EditedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "EditedDate");
        }
    }
}
