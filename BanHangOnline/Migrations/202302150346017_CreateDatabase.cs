namespace BanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Adv",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 150),
                    Description = c.String(maxLength: 500),
                    Image = c.String(maxLength: 500),
                    Link = c.String(maxLength: 500),
                    Type = c.Int(nullable: false),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })

                .PrimaryKey(t => t.ID);
            CreateTable(
                "dbo.tb_Category",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Description = c.String(),
                    SeoTitle = c.String(),
                    SeoDescription = c.String(),
                    SeoKeywords = c.String(),
                    Position = c.Int(nullable: false),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID);
            CreateTable(
                "dbo.tb_News",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 150),
                    Description = c.String(),
                    Detail = c.String(),
                    Image = c.String(),
                    CategoryID = c.Int(nullable: false),
                    SeoTitle = c.String(),
                    SeoDescription = c.String(),
                    SeoKeywords = c.String(),
                    Position = c.Int(nullable: false),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);

            CreateTable(
                "dbo.tb_Post",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 150),
                    Description = c.String(),
                    Detail = c.String(),
                    Image = c.String(),
                    CategoryID = c.Int(nullable: false),
                    SeoTitle = c.String(),
                    SeoDescription = c.String(),
                    SeoKeywords = c.String(),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);

            CreateTable(
                "dbo.tb_Contact",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 150),
                    Email = c.String(maxLength: 150),
                    Website = c.String(),
                    Message = c.String(maxLength: 4000),
                    isRead = c.Boolean(nullable: false),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.tb_OrderDetails",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    OrderID = c.Int(nullable: false),
                    ProductID = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);

            CreateTable(
                "dbo.tb_Order",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                    CustomerName = c.String(nullable: false),
                    Phone = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    TotalAmoung = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.tb_Product",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 150),
                    ProductCode = c.String(),
                    Description = c.String(),
                    Detail = c.String(),
                    Image = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                    isHome = c.Boolean(nullable: false),
                    isSale = c.Boolean(nullable: false),
                    isFeature = c.Boolean(nullable: false),
                    isHot = c.Boolean(nullable: false),
                    ProductCategoryID = c.Int(nullable: false),
                    SeoTitle = c.String(),
                    SeoDescription = c.String(),
                    SeoKeywords = c.String(),
                    CreatedBy = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_ProductCategory", t => t.ProductCategoryID, cascadeDelete: true);

            CreateTable(
                "dbo.tb_ProductCategory",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 150),
                    Description = c.String(),
                    Icon = c.String(),
                    CreatedBy = c.String(),
                    SeoTitle = c.String(),
                    SeoDescription = c.String(),
                    SeoKeywords = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    ModifiedDate = c.DateTime(nullable: false),
                    ModifiedBy = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.tb_Subcribe",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Email = c.Int(),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
               "dbo.tb_SystemSetting",
               c => new
               {
                   SettingKey = c.Int(nullable: false, identity: true),
                   SettingValue = c.String(nullable: false, maxLength: 4000),
                   SettingDescription = c.String(nullable: false, maxLength: 4000)

               })
               .PrimaryKey(t => t.SettingKey);



            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

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

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_OrderDetails", "ProductID", "dbo.tb_Product");
            DropForeignKey("dbo.tb_Product", "ProductCategoryID", "dbo.tb_ProductCategory");
            DropForeignKey("dbo.tb_OrderDetails", "OrderID", "dbo.tb_Order");
            DropForeignKey("dbo.tb_Post", "CategoryID", "dbo.tb_Category");
            DropForeignKey("dbo.tb_News", "CategoryID", "dbo.tb_Category");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");

            DropIndex("dbo.tb_Product", new[] { "ProductCategoryID" });
            DropIndex("dbo.tb_OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.tb_OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.tb_Post", new[] { "CategoryID" });
            DropIndex("dbo.tb_News", new[] { "CategoryID" });


            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");

            DropTable("dbo.tb_ProductCategory");
            DropTable("dbo.tb_Product");
            DropTable("dbo.tb_Order");
            DropTable("dbo.tb_OrderDetails");
            DropTable("dbo.tb_Contact");
            DropTable("dbo.tb_Post");
            DropTable("dbo.tb_News");
            DropTable("dbo.tb_Category");
            DropTable("dbo.tb_Adv");
        }
    }
}
