namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeesAndHoursControllers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hours", "Hours_Id", c => c.Int());
            CreateIndex("dbo.Hours", "Hours_Id");
            AddForeignKey("dbo.Hours", "Hours_Id", "dbo.Hours", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hours", "Hours_Id", "dbo.Hours");
            DropIndex("dbo.Hours", new[] { "Hours_Id" });
            DropColumn("dbo.Hours", "Hours_Id");
        }
    }
}
