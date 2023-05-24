namespace BanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_New", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Post", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "isActive");
            DropColumn("dbo.tb_Post", "isActive");
            DropColumn("dbo.tb_New", "isActive");
            DropColumn("dbo.tb_Category", "isActive");
        }
    }
}
