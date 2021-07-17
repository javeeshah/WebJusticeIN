namespace WebJusticeIN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Guid(nullable: false),
                        BlogNumber = c.String(nullable: false),
                        BlogTitle = c.String(nullable: false),
                        BlogSummary = c.String(),
                        IsPublished = c.Boolean(nullable: false),
                        AuthorName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Guid(nullable: false),
                        NewsNumber = c.String(nullable: false),
                        NewsTitle = c.String(),
                        NewsDesc = c.String(),
                        IsPublished = c.Boolean(nullable: false),
                        AuthorName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
            DropTable("dbo.Blogs");
        }
    }
}
