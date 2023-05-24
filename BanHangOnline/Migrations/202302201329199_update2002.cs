﻿namespace BanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        isDefault = c.Boolean(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductImage", "ProductID", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductID" });
            DropTable("dbo.tb_ProductImage");
        }
    }
}
