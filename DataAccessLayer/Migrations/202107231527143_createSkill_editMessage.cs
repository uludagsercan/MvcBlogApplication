namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createSkill_editMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 60),
                        SkillName = c.String(maxLength: 50),
                        Precentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
            AddColumn("dbo.Contacts", "ReadStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "ReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReadStatus");
            DropColumn("dbo.Contacts", "ReadStatus");
            DropTable("dbo.Skills");
        }
    }
}
