namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToNotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "CategoryId", c => c.Int());
            CreateIndex("dbo.Notes", "CategoryId");
            AddForeignKey("dbo.Notes", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Notes", new[] { "CategoryId" });
            DropColumn("dbo.Notes", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
