namespace ECommerce.DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedcartLine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities");
            DropForeignKey("dbo.ProductDataEntities", "OrderDataEntity_Id", "dbo.OrderDataEntities");
            DropIndex("dbo.ProductDataEntities", new[] { "CartDataEntity_Id" });
            DropIndex("dbo.ProductDataEntities", new[] { "OrderDataEntity_Id" });
            CreateTable(
                "dbo.CartLineDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        CartDataEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductDataEntities", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.CartDataEntities", t => t.CartDataEntity_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.CartDataEntity_Id);

            AddColumn("dbo.CartDataEntities", "UserProfile_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.OrderLineDataEntities", "ProductDataEntity_Id", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDataEntities", "UserProfile_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CartDataEntities", "UserProfile_Id");
            CreateIndex("dbo.OrderLineDataEntities", "ProductDataEntity_Id");
            CreateIndex("dbo.OrderDataEntities", "UserProfile_Id");
            AddForeignKey("dbo.CartDataEntities", "UserProfile_Id", "dbo.UserProfileDataEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDataEntities", "UserProfile_Id", "dbo.UserProfileDataEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderLineDataEntities", "ProductDataEntity_Id", "dbo.ProductDataEntities", "Id", cascadeDelete: true);
            DropColumn("dbo.CartDataEntities", "TrackingNumber");
            DropColumn("dbo.CartDataEntities", "OverallPrice");
            DropColumn("dbo.CartDataEntities", "Quantity");
            DropColumn("dbo.ProductDataEntities", "CartDataEntity_Id");
            DropColumn("dbo.ProductDataEntities", "OrderDataEntity_Id");
            DropColumn("dbo.OrderDataEntities", "StateDataEntity");
            DropColumn("dbo.OrderDataEntities", "OrderLineId");
        }

        public override void Down()
        {
            AddColumn("dbo.OrderDataEntities", "OrderLineId", c => c.Int());
            AddColumn("dbo.OrderDataEntities", "StateDataEntity", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDataEntities", "OrderDataEntity_Id", c => c.Int());
            AddColumn("dbo.ProductDataEntities", "CartDataEntity_Id", c => c.Int());
            AddColumn("dbo.CartDataEntities", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.CartDataEntities", "OverallPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartDataEntities", "TrackingNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderLineDataEntities", "ProductDataEntity_Id", "dbo.ProductDataEntities");
            DropForeignKey("dbo.OrderDataEntities", "UserProfile_Id", "dbo.UserProfileDataEntities");
            DropForeignKey("dbo.CartDataEntities", "UserProfile_Id", "dbo.UserProfileDataEntities");
            DropForeignKey("dbo.CartLineDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities");
            DropForeignKey("dbo.CartLineDataEntities", "Product_Id", "dbo.ProductDataEntities");
            DropIndex("dbo.OrderDataEntities", new[] { "UserProfile_Id" });
            DropIndex("dbo.OrderLineDataEntities", new[] { "ProductDataEntity_Id" });
            DropIndex("dbo.CartLineDataEntities", new[] { "CartDataEntity_Id" });
            DropIndex("dbo.CartLineDataEntities", new[] { "Product_Id" });
            DropIndex("dbo.CartDataEntities", new[] { "UserProfile_Id" });
            DropColumn("dbo.OrderDataEntities", "UserProfile_Id");
            DropColumn("dbo.OrderLineDataEntities", "ProductDataEntity_Id");
            DropColumn("dbo.CartDataEntities", "UserProfile_Id");
            DropTable("dbo.CartLineDataEntities");
            CreateIndex("dbo.ProductDataEntities", "OrderDataEntity_Id");
            CreateIndex("dbo.ProductDataEntities", "CartDataEntity_Id");
            AddForeignKey("dbo.ProductDataEntities", "OrderDataEntity_Id", "dbo.OrderDataEntities", "Id");
            AddForeignKey("dbo.ProductDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities", "Id");
        }
    }
}
