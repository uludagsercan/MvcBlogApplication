namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_message : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageSubject", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageSubject", c => c.String());
        }
    }
}
