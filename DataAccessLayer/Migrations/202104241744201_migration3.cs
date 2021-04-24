namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "WriterId", "dbo.Writers");
            DropIndex("dbo.Categories", new[] { "WriterId" });
            DropColumn("dbo.Categories", "WriterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "WriterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "WriterId");
            AddForeignKey("dbo.Categories", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
        }
    }
}
