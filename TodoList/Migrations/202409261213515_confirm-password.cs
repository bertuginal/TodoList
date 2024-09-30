namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.TodoItems", "Description", c => c.String(nullable: false, maxLength: 160));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoItems", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Users", "ConfirmPassword");
        }
    }
}
