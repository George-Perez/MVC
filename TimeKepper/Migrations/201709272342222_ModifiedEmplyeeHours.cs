namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedEmplyeeHours : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
    }
}
