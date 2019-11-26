namespace ECommerce.DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class tablenameschanged : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CartDataEntities", newName: "Cart");
            RenameTable(name: "dbo.CartLineDataEntities", newName: "CartLine");
            RenameTable(name: "dbo.ProductDataEntities", newName: "Product");
            RenameTable(name: "dbo.CategoryDataEntities", newName: "Category");
            RenameTable(name: "dbo.UserProfileDataEntities", newName: "UserProfile");
            RenameTable(name: "dbo.OrderLineDataEntities", newName: "OrderLine");
            RenameTable(name: "dbo.OrderDataEntities", newName: "Order");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.Order", newName: "OrderDataEntities");
            RenameTable(name: "dbo.OrderLine", newName: "OrderLineDataEntities");
            RenameTable(name: "dbo.UserProfile", newName: "UserProfileDataEntities");
            RenameTable(name: "dbo.Category", newName: "CategoryDataEntities");
            RenameTable(name: "dbo.Product", newName: "ProductDataEntities");
            RenameTable(name: "dbo.CartLine", newName: "CartLineDataEntities");
            RenameTable(name: "dbo.Cart", newName: "CartDataEntities");
        }
    }
}
