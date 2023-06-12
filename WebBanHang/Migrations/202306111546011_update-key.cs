namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatekey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_News", new[] { "CategoryId" });
            AlterColumn("dbo.tb_News", "CategoryId", c => c.Int());
            CreateIndex("dbo.tb_News", "CategoryId");
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_News", new[] { "CategoryId" });
            AlterColumn("dbo.tb_News", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_News", "CategoryId");
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
    }
}
