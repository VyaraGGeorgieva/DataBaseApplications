using System;
using System.Data.Entity;

namespace DataFromRelatedTables
{
    using AdsContext;
    class Test
    {
        
        static void Main(string[] args)
        {
            var context = new AdsEntities();
            
            //28 queries
            SqlStatementNoInclude(context);

            //1 query
            SqlStatementInclude(context);
        }

        private static void SqlStatementInclude(AdsEntities context)
        {
//statuses, categories, towns and users along with all ads. 
            
            var adsI = context.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);
            foreach (var ad in adsI)
            {
                Console.WriteLine("Status: {0} Category: {1} Town:{2} User: {3}",
                    ad.AdStatus.Status,
                    (ad.CategoryId != null) ? ad.Category.Name : "no data", (ad.TownId != null) ? ad.Town.Name : "no data",
                    ad.AspNetUser.Name);
            }
        }

        private static void SqlStatementNoInclude(AdsEntities context)
        {
//write a SQL query to select all ads from the database and later print their title, status, category, town and user. 

            
            var adsQ = context.Ads;
            foreach (var ad in adsQ)
            {
                Console.WriteLine("Title: {0} Status: {1} Category: {2} Town:{3} User: {4}",
                    ad.Title,
                    ad.AdStatus.Status,
                    (ad.CategoryId != null) ? ad.Category.Name : "no data",
                    (ad.TownId != null) ? ad.Town.Name : "no data",
                    ad.AspNetUser.Name);
            }
        }
    }
}
