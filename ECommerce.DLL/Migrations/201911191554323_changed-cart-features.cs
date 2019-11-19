namespace DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changedcartfeatures : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.OrderLines", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities");
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            DropIndex("dbo.OrderLines", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.OrderDataEntities", new[] { "CartDataEntity_Id" });
            RenameColumn(table: "dbo.AspNetUserClaims", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_UserId", newName: "IX_User_Id");
            DropPrimaryKey("dbo.AspNetUserLogins");
            AddColumn("dbo.CartDataEntities", "OverallPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartDataEntities", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ProductDataEntities", "CartDataEntity_Id", c => c.Int());
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "UserId", "LoginProvider", "ProviderKey" });
            CreateIndex("dbo.ProductDataEntities", "CartDataEntity_Id");
            AddForeignKey("dbo.ProductDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities", "Id");
            DropColumn("dbo.AspNetUsers", "Email");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.OrderDataEntities", "CartDataEntity_Id");
            DropTable("dbo.Carts");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderLines");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.UserProfiles");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        ParentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotoPath = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Album = c.String(),
                        Artist = c.String(),
                        TrackDuration = c.Double(nullable: false),
                        Category_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhotoPath = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Album = c.String(),
                        Artist = c.String(),
                        TrackDuration = c.Double(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Int(nullable: false),
                        OrderLineId = c.Int(),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.OrderDataEntities", "CartDataEntity_Id", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            DropForeignKey("dbo.ProductDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities");
            DropIndex("dbo.ProductDataEntities", new[] { "CartDataEntity_Id" });
            DropPrimaryKey("dbo.AspNetUserLogins");
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.ProductDataEntities", "CartDataEntity_Id");
            DropColumn("dbo.CartDataEntities", "Quantity");
            DropColumn("dbo.CartDataEntities", "OverallPrice");
            AddPrimaryKey("dbo.AspNetUserLogins", new[] { "LoginProvider", "ProviderKey", "UserId" });
            RenameIndex(table: "dbo.AspNetUserClaims", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.AspNetUserClaims", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.OrderDataEntities", "CartDataEntity_Id");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.Categories", "ParentCategory_Id");
            CreateIndex("dbo.Products", "Order_Id");
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.OrderLines", "Order_Id");
            CreateIndex("dbo.Orders", "Cart_Id");
            AddForeignKey("dbo.OrderDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.OrderLines", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
