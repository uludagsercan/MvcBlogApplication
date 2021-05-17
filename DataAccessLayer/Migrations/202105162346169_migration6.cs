namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
