using System.Data.Entity.Migrations;

namespace ECommerce.DLL.Migrations
{
    public partial class addedtrackingnumbertocart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "TrackingNumber", c => c.Int(nullable: false));
            AddColumn("dbo.CartDataEntities", "TrackingNumber", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.CartDataEntities", "TrackingNumber");
            DropColumn("dbo.Carts", "TrackingNumber");
        }
    }
}
