using System.Data.Entity.Migrations;

namespace ECommerce.DLL.Migrations
{
    public partial class AddedCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CartDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Orders", "Cart_Id", c => c.Int());
            AddColumn("dbo.OrderDataEntities", "CartDataEntity_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Cart_Id");
            CreateIndex("dbo.OrderDataEntities", "CartDataEntity_Id");
            AddForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.OrderDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities");
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.OrderDataEntities", new[] { "CartDataEntity_Id" });
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            DropColumn("dbo.OrderDataEntities", "CartDataEntity_Id");
            DropColumn("dbo.Orders", "Cart_Id");
            DropTable("dbo.CartDataEntities");
            DropTable("dbo.Carts");
        }
    }
}
