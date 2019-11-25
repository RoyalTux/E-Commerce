namespace ECommerce.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcategoryparentid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CategoryDataEntities", new[] { "ParentId" });
            AlterColumn("dbo.CategoryDataEntities", "ParentId", c => c.Int());
            CreateIndex("dbo.CategoryDataEntities", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CategoryDataEntities", new[] { "ParentId" });
            AlterColumn("dbo.CategoryDataEntities", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CategoryDataEntities", "ParentId");
        }
    }
}
