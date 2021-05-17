namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryModifiedDate", c => c.DateTime());
        }
    }
}
