namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteReminderNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Reminder", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Reminder", c => c.DateTime(nullable: false));
        }
    }
}
