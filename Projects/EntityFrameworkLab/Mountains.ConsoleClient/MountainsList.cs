
using System;
using System.Linq;
using Mountains.Data;

namespace Mountains.ConsoleClient
{
    class MountainsList
    {
        static void Main()
        { 
            var context = new MountainsContext();
            var countries = context.Countries
                .Select(c => new
                {
                     Countries =c.Name,
                     Mountains = c.Mountains
                        .Select(m=>new
                        {
                            m.Name,
                            m.Peaks
                        })
                });
            foreach (var country in countries)
            {
                Console.WriteLine("Country: " + country.Countries);
                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("Mountain: "+ mountain.Name);
                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("{0} ({1})", peak.Name, peak.Elevation);
                    }
                }


            }

        }
    }
}
