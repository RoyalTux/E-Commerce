namespace DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(nullable: false, maxLength: 256),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            AddColumn("dbo.Products", "SubCategoryId", c => c.Int());
            AlterColumn("dbo.Products", "Album", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Artist", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.Products", "SubCategoryId");
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "Id");
            DropColumn("dbo.Products", "CategoryId");
        }

        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int());
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "Artist", c => c.String());
            AlterColumn("dbo.Products", "Album", c => c.String());
            DropColumn("dbo.Products", "SubCategoryId");
            DropTable("dbo.SubCategories");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
