namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class edit_messagesubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageSubject", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageSubject");
        }
    }
}
