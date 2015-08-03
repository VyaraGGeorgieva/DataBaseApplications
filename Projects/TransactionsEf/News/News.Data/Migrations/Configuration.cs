using System.Data.Entity.Migrations.Infrastructure;

namespace Data.News.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.News.NewsDb>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "Data.News.NewsDb";
        }

        protected override void Seed(Data.News.NewsDb context)
        {
            if (!context.News.Any())
            {
                context.News.Add(new Models.News.News() {Content = "First News"});
            context.News.Add(new Models.News.News() { Content = "Second News" });
            context.News.Add(new Models.News.News() { Content = "Third News" });
            base.Seed(context);
            }
            
        }
        
    }
}
