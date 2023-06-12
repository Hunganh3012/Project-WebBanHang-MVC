namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCategoryString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_News", "CategoryString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_News", "CategoryString");
        }
    }
}
