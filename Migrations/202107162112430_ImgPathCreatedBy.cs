namespace WebJusticeIN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImgPathCreatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "ImagePath", c => c.String());
            AddColumn("dbo.Blogs", "CreatedBy", c => c.String());
            AddColumn("dbo.News", "CreatedBy", c => c.String());
            AddColumn("dbo.News", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "ImagePath");
            DropColumn("dbo.News", "CreatedBy");
            DropColumn("dbo.Blogs", "CreatedBy");
            DropColumn("dbo.Blogs", "ImagePath");
        }
    }
}
