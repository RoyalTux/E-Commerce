namespace DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ItemOrders", "ItemId", "dbo.Products");
            DropIndex("dbo.ItemOrders", new[] { "OrderId" });
            DropIndex("dbo.ItemOrders", new[] { "ItemId" });
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            DropTable("dbo.ItemOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ItemId });
            
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropColumn("dbo.Products", "Order_Id");
            CreateIndex("dbo.ItemOrders", "ItemId");
            CreateIndex("dbo.ItemOrders", "OrderId");
            AddForeignKey("dbo.ItemOrders", "ItemId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemOrders", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
