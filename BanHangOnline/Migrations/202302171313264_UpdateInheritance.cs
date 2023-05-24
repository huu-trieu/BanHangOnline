namespace BanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInheritance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductCategory", "createdBy", c => c.String());
            //AddColumn("dbo.tb_ProductCategory", "createdDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.tb_ProductCategory", "modifiedBy", c => c.String());
            //AddColumn("dbo.tb_ProductCategory", "modifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductCategory", "modifiedDate");
            DropColumn("dbo.tb_ProductCategory", "modifiedBy");
            DropColumn("dbo.tb_ProductCategory", "createdDate");
            DropColumn("dbo.tb_ProductCategory", "createdBy");
        }
    }
}
