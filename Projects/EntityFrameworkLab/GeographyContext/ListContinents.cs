
using System;
using System.Data.Entity;
using System.Linq;

namespace GeographyContext
{
    class ListContinents
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            var continets = context.Continents
                .Select(c=> c.ContinentName);
            foreach (var continent in continets)
            {
                Console.WriteLine("{0}", continent);
            }
        }
    }
}