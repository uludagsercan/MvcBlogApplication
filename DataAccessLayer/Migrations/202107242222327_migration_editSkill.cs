namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_editSkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Department", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Department");
        }
    }
}
