using System.Data.Entity;
using Data.News.Migrations;
using Models.News;
namespace Data.News
{
    public class NewsDb : DbContext
    {
        
        public NewsDb()
            : base("name=NewsDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDb, Configuration>());
        }

        public IDbSet<Models.News.News> News { get; set; }
        

    }

  
}