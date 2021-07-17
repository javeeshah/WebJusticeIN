using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebJusticeIN.Areas.Admin.Models
{
    public class JusticeInDbContext: DbContext
    {

        public JusticeInDbContext(): base("JusticeInn")
        {
        }

        public DbSet<Blog> blogs { get; set; }
        public DbSet<News> news { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blogs");
            modelBuilder.Entity<News>().ToTable("News");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}