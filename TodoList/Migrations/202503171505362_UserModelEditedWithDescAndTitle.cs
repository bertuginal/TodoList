namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelEditedWithDescAndTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "Title", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notes", "Title", c => c.String(nullable: false));
        }
    }
}
