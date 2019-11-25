namespace ECommerce.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartDataEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.Int(nullable: false),
                        OverallPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CartDataEntity_Id = c.Int(),
                        OrderDataEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryDataEntities", t => t.CategoryDataEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.CartDataEntities", t => t.CartDataEntity_Id)
                .ForeignKey("dbo.OrderDataEntities", t => t.OrderDataEntity_Id)
                .Index(t => t.CategoryDataEntity_Id)
                .Index(t => t.CartDataEntity_Id)
                .Index(t => t.OrderDataEntity_Id);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderLineDataEntities", "OrderDataEntity_Id", "dbo.OrderDataEntities");
            DropForeignKey("dbo.ProductDataEntities", "OrderDataEntity_Id", "dbo.OrderDataEntities");
            DropForeignKey("dbo.ProductDataEntities", "CartDataEntity_Id", "dbo.CartDataEntities");
            DropForeignKey("dbo.ProductDataEntities", "CategoryDataEntity_Id", "dbo.CategoryDataEntities");
            DropForeignKey("dbo.CategoryDataEntities", "ParentId", "dbo.CategoryDataEntities");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.OrderLineDataEntities", new[] { "OrderDataEntity_Id" });
            DropIndex("dbo.CategoryDataEntities", new[] { "ParentId" });
            DropIndex("dbo.ProductDataEntities", new[] { "OrderDataEntity_Id" });
            DropIndex("dbo.ProductDataEntities", new[] { "CartDataEntity_Id" });
            DropIndex("dbo.ProductDataEntities", new[] { "CategoryDataEntity_Id" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserProfileDataEntities");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderDataEntities");
            DropTable("dbo.OrderLineDataEntities");
            DropTable("dbo.CategoryDataEntities");
            DropTable("dbo.ProductDataEntities");
            DropTable("dbo.CartDataEntities");
        }
    }
}
