namespace TimeKepper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inventories", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventories", "StoreId");
            AddForeignKey("dbo.Inventories", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "StoreId", "dbo.Stores");
            DropIndex("dbo.Inventories", new[] { "StoreId" });
            DropColumn("dbo.Inventories", "StoreId");
        }
    }
}
