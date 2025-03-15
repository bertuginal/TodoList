namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteDescCharactersUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Description", c => c.String(nullable: false, maxLength: 160));
        }
    }
}
