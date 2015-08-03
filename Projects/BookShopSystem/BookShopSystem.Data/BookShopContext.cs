using BookShopSystem.Data.Migrations;
using BookShopSystem.Models;

namespace BookShopSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopContext : DbContext
    {
        
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext,Configuration>());
        }

        public IDbSet<Book> Books  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; } 
        
    }
}