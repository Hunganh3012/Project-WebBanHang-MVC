namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateisDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Adv", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_Category", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_News", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_Post", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_Contact", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_OrderDetail", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_Order", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_Product", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_ProductCategory", "isDelete", c => c.Boolean());
            AddColumn("dbo.tb_Subscribe", "isDelete", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Subscribe", "isDelete");
            DropColumn("dbo.tb_ProductCategory", "isDelete");
            DropColumn("dbo.tb_Product", "isDelete");
            DropColumn("dbo.tb_Order", "isDelete");
            DropColumn("dbo.tb_OrderDetail", "isDelete");
            DropColumn("dbo.tb_Contact", "isDelete");
            DropColumn("dbo.tb_Post", "isDelete");
            DropColumn("dbo.tb_News", "isDelete");
            DropColumn("dbo.tb_Category", "isDelete");
            DropColumn("dbo.tb_Adv", "isDelete");
        }
    }
}
