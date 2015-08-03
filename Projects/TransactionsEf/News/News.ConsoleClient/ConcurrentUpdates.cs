
using System;
using Data.News;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Models.News;

namespace ConsoleClient.News
{
    class ConcurrentUpdates
    {
        static void Main()
        {
            var context=  new NewsDb();
            var news = context.News;
            foreach (var newsItem in news)
            {
                Console.WriteLine("{0}",newsItem.Content);
            }

            var continueReading = true;
            while (continueReading)
            {
                Console.WriteLine("Enter news content:");
                var content = Console.ReadLine();
                var newNews = new Models.News.News() { Content = content };
                context.News.Add(newNews);

                try
                {
                    context.SaveChanges();
                    continueReading = false;
                    Console.WriteLine("Changes successfully saved in the DB.");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Conflict! Text from DB: {0}", content);
                }
            }
        }
    }
}
