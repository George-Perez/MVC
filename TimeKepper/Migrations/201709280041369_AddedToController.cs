namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedToController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Hours", "ClockInClockOut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Hours", "Clock", c => c.DateTime(nullable: false));
            DropColumn("dbo.Hours", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hours", "Time", c => c.String());
            DropColumn("dbo.Hours", "Clock");
            DropColumn("dbo.Hours", "ClockInClockOut");
            DropColumn("dbo.Employees", "IsActive");
        }
    }
}
