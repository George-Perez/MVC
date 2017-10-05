namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToStore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "EmployeeId");
            AddForeignKey("dbo.Stores", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Stores", new[] { "EmployeeId" });
            DropColumn("dbo.Stores", "EmployeeId");
        }
    }
}
