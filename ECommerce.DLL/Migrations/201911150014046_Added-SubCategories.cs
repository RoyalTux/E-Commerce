namespace DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedSubCategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            CreateTable(
                "dbo.CategoryDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryDataEntities", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "dbo.OrderDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                        StateDataEntity = c.Int(nullable: false),
                        OrderLineId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderLineDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        PhotoPath = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Album = c.String(nullable: false, maxLength: 256),
                        Artist = c.String(nullable: false, maxLength: 256),
                        TrackDuration = c.Double(nullable: false),
                        OrderDataEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderDataEntities", t => t.OrderDataEntity_Id, cascadeDelete: true)
                .Index(t => t.OrderDataEntity_Id);

            CreateTable(
                "dbo.ProductDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        PhotoPath = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 256),
                        Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Album = c.String(nullable: false, maxLength: 256),
                        Artist = c.String(nullable: false, maxLength: 256),
                        TrackDuration = c.Double(nullable: false),
                        CategoryDataEntity_Id = c.Int(nullable: false),
                        OrderDataEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryDataEntities", t => t.CategoryDataEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.OrderDataEntities", t => t.OrderDataEntity_Id)
                .Index(t => t.CategoryDataEntity_Id)
                .Index(t => t.OrderDataEntity_Id);

            CreateTable(
                "dbo.UserProfileDataEntities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Address = c.String(nullable: false, maxLength: 256),
                        Email = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false, maxLength: 256),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Role = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Categories", "ParentId", c => c.Int());
            AddColumn("dbo.Categories", "ParentCategory_Id", c => c.Int());
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            AddColumn("dbo.OrderLines", "Name", c => c.String());
            AddColumn("dbo.OrderLines", "PhotoPath", c => c.String());
            AddColumn("dbo.OrderLines", "Description", c => c.String());
            AddColumn("dbo.OrderLines", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderLines", "Album", c => c.String());
            AddColumn("dbo.OrderLines", "Artist", c => c.String());
            AddColumn("dbo.OrderLines", "TrackDuration", c => c.Double(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "PhotoPath", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Album", c => c.String());
            AlterColumn("dbo.Products", "Artist", c => c.String());
            AlterColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.UserProfiles", "Name", c => c.String());
            AlterColumn("dbo.UserProfiles", "Address", c => c.String());
            AlterColumn("dbo.UserProfiles", "Email", c => c.String());
            AlterColumn("dbo.UserProfiles", "Password", c => c.String());
            AlterColumn("dbo.UserProfiles", "UserName", c => c.String());
            AlterColumn("dbo.UserProfiles", "Role", c => c.String());
            CreateIndex("dbo.Categories", "ParentCategory_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Products", "SubCategoryId");
            DropTable("dbo.SubCategories");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 256),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Products", "SubCategoryId", c => c.Int());
            DropForeignKey("dbo.ProductDataEntities", "OrderDataEntity_Id", "dbo.OrderDataEntities");
            DropForeignKey("dbo.ProductDataEntities", "CategoryDataEntity_Id", "dbo.CategoryDataEntities");
            DropForeignKey("dbo.OrderLineDataEntities", "OrderDataEntity_Id", "dbo.OrderDataEntities");
            DropForeignKey("dbo.CategoryDataEntities", "ParentId", "dbo.CategoryDataEntities");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropIndex("dbo.ProductDataEntities", new[] { "OrderDataEntity_Id" });
            DropIndex("dbo.ProductDataEntities", new[] { "CategoryDataEntity_Id" });
            DropIndex("dbo.OrderLineDataEntities", new[] { "OrderDataEntity_Id" });
            DropIndex("dbo.CategoryDataEntities", new[] { "ParentId" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            AlterColumn("dbo.UserProfiles", "Role", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.UserProfiles", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.UserProfiles", "Password", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.UserProfiles", "Email", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.UserProfiles", "Address", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.UserProfiles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 9, scale: 2));
            AlterColumn("dbo.Products", "Artist", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Album", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 9, scale: 2));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.OrderLines", "TrackDuration");
            DropColumn("dbo.OrderLines", "Artist");
            DropColumn("dbo.OrderLines", "Album");
            DropColumn("dbo.OrderLines", "Quantity");
            DropColumn("dbo.OrderLines", "Description");
            DropColumn("dbo.OrderLines", "PhotoPath");
            DropColumn("dbo.OrderLines", "Name");
            DropColumn("dbo.Products", "Category_Id");
            DropColumn("dbo.Categories", "ParentCategory_Id");
            DropColumn("dbo.Categories", "ParentId");
            DropTable("dbo.UserProfileDataEntities");
            DropTable("dbo.ProductDataEntities");
            DropTable("dbo.OrderLineDataEntities");
            DropTable("dbo.OrderDataEntities");
            DropTable("dbo.CategoryDataEntities");
            CreateIndex("dbo.Products", "SubCategoryId");
            CreateIndex("dbo.SubCategories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "Id");
        }
    }
}
