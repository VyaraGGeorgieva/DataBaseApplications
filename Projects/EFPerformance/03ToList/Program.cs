//Using Entity Framework select all ads from the database, then invoke ToList(), then filter the categories whose status is Published; then select the ad title, category and town, then invoke ToList() again and finally order the ads by publish date. Rewrite the same query in a more optimized way and compare the performance.

using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using AdsContext;

namespace ToList
{
    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();
            context.Ads.Count();

            var stopWatch = new Stopwatch();

            stopWatch.Start();
            UnoptimizedToList(context);
            //Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            OptimizedList(context);
            Console.WriteLine(stopWatch.Elapsed);
        }

        private static void OptimizedList(AdsEntities context)
        {
            var adsOpt = context.Ads
                .Where(a => a.AdStatus.Status.Equals("Published"))
                .OrderBy(a => a.Date)
                .Include(a => a.Category)
                .Include(a => a.Town).ToList();
            adsOpt.ForEach(a =>
            {
                Console.WriteLine("{0} {1} {2}",
                    a.Title,
                    (a.CategoryId != null) ? a.Category.Name : "no category",
                    (a.TownId != null) ? a.Town.Name : "no town");
            });
        }

        private static void UnoptimizedToList(AdsEntities context)
        {
            var ads = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new 
                {
                    a.Title,
                    CategoryName= a.CategoryId != null ? a.Category.Name : "no category",
                    TownName =(a.TownId != null) ? a.Town.Name : "no town"
                }).ToList();
            foreach (var ad in ads)
            {
                Console.WriteLine("{0} {1} {2}",
                    ad.Title,
                    ad.CategoryName,
                    ad.TownName);
            }
            
        }
    }
}
