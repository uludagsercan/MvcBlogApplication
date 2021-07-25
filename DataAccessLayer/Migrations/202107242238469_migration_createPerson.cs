namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_createPerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonFullName = c.String(maxLength: 100),
                        PersonDepartment = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.PersonId);
            
            AddColumn("dbo.Skills", "Person_PersonId", c => c.Int());
            CreateIndex("dbo.Skills", "Person_PersonId");
            AddForeignKey("dbo.Skills", "Person_PersonId", "dbo.People", "PersonId");
            DropColumn("dbo.Skills", "FullName");
            DropColumn("dbo.Skills", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Department", c => c.String(maxLength: 150));
            AddColumn("dbo.Skills", "FullName", c => c.String(maxLength: 60));
            DropForeignKey("dbo.Skills", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Skills", new[] { "Person_PersonId" });
            DropColumn("dbo.Skills", "Person_PersonId");
            DropTable("dbo.People");
        }
    }
}
