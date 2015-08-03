
using System;
using System.Diagnostics;
using System.Linq;
using AdsContext;

namespace Select
{
    class SelectMain
    {
        static void Main()
        {
            var context = new AdsEntities();

            context.Ads.Count();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            NonOptimised(context);
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            Optimized(context);
            Console.WriteLine(stopWatch.Elapsed);
        }

        private static void Optimized(AdsEntities context)
        {
            var titlesOpt = context.Ads
                .Select(t => new
                {
                    t.Title
                });

            foreach (var title in titlesOpt)
            {
                Console.WriteLine("Optimized: {0}",
                    title.Title);
            }
        }

        private static void NonOptimised(AdsEntities context)
        {
            var titles = context.Ads;
            foreach (var title in titles)
            {
                Console.WriteLine("Non-optimized: {0}", title.Title);
            }
        }
    }
}
