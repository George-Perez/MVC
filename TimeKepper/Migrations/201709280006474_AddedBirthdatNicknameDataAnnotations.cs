namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthdatNicknameDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "Nickname", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            DropColumn("dbo.Employees", "Nickname");
            DropColumn("dbo.Employees", "Birthdate");
        }
    }
}
