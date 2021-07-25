namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_editSkill1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Skills", name: "Person_PersonId", newName: "PersonId");
            RenameIndex(table: "dbo.Skills", name: "IX_Person_PersonId", newName: "IX_PersonId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Skills", name: "IX_PersonId", newName: "IX_Person_PersonId");
            RenameColumn(table: "dbo.Skills", name: "PersonId", newName: "Person_PersonId");
        }
    }
}
