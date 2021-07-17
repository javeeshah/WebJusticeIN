namespace WebJusticeIN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.News", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Active");
            DropColumn("dbo.Blogs", "Active");
        }
    }
}
