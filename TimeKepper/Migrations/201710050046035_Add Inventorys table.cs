namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventorystable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "InventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stores", "InventoryId");
            AddForeignKey("dbo.Stores", "InventoryId", "dbo.Inventories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.Stores", new[] { "InventoryId" });
            DropColumn("dbo.Stores", "InventoryId");
        }
    }
}
