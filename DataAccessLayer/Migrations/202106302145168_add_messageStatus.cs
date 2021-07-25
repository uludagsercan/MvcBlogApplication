namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_messageStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDraftStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageDraftStatus");
        }
    }
}
