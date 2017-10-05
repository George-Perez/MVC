namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Stores", new[] { "InventoryId" });
            DropColumn("dbo.Stores", "InventoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "InventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "InventoryId");
            AddForeignKey("dbo.Stores", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
        }
    }
}
