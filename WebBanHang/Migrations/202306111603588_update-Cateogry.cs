namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCateogry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_News", new[] { "CategoryId" });
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        News_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.News_Id, t.Category_Id })
                .ForeignKey("dbo.tb_News", t => t.News_Id, cascadeDelete: true)
                .ForeignKey("dbo.tb_Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.News_Id)
                .Index(t => t.Category_Id);
            
            AddColumn("dbo.tb_News", "SelectedCategoryIds", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsCategories", "Category_Id", "dbo.tb_Category");
            DropForeignKey("dbo.NewsCategories", "News_Id", "dbo.tb_News");
            DropIndex("dbo.NewsCategories", new[] { "Category_Id" });
            DropIndex("dbo.NewsCategories", new[] { "News_Id" });
            DropColumn("dbo.tb_News", "SelectedCategoryIds");
            DropTable("dbo.NewsCategories");
            CreateIndex("dbo.tb_News", "CategoryId");
            AddForeignKey("dbo.tb_News", "CategoryId", "dbo.tb_Category", "Id");
        }
    }
}
