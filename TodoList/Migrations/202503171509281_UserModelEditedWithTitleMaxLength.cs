namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelEditedWithTitleMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Title", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Title", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
