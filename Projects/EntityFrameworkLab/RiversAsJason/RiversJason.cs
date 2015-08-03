
using System.Linq;
using System.Web.Script.Serialization;
using GeographyContext;
using System.IO;

//System.Web.Extensions -add(.dll)

namespace RiversAsJason
{
    class RiversJason
    {
      
        private static void Main()
        {
            var context = new GeographyEntities();
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)

                });
            var jsSerializer = new JavaScriptSerializer();
            var riversJason = jsSerializer.Serialize(rivers.ToList());
            File.WriteAllText(@"rivers.json", riversJason);


        }

    }
    }

