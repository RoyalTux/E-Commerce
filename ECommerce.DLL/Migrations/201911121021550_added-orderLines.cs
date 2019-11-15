namespace DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedorderLines : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);

            AddColumn("dbo.Orders", "OrderLineId", c => c.Int());
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderLines", new[] { "Order_Id" });
            DropColumn("dbo.Orders", "OrderLineId");
            DropTable("dbo.OrderLines");
        }
    }
}
