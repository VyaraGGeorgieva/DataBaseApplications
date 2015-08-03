using System;
using System.Linq;
using System.Xml.Linq;
using GeographyContext;

namespace Export_Monasteries_as_XML
{
    class Program
    {
        static void Main()
        {
            var context = new GeographyEntities();

            var countries = context.Countries
                .Where(c=> c.Monasteries.Count>0)
                .OrderBy(c=> c.CountryName)
                .Select(c => new
                {
                    country = c.CountryName,
                    monastaries = c.Monasteries
                        .OrderBy(m=>m.Name)
                        .Select(m => m.Name)
                });
            //foreach (var country in countries)
            //{
            //    Console.WriteLine(country.country + ' ' + string.Join(", ",country.monastaries)
            //        );
            //}

            var xmlDoc = new XDocument();
            //1. Root
            var rootXml = new XElement("monasteries");
            xmlDoc.Add(rootXml);

            foreach (var country in countries)
            {
                var countryXml = new XElement("country", new XAttribute("name", country.country) );
             rootXml.Add(countryXml);
                foreach (var monastery in country.monastaries)
                {
                    var monasteryXml = new XElement("monastery", monastery);
                    countryXml.Add(monasteryXml);
                }
            }
            xmlDoc.Save("monasteries.xml");

           
        }
    }
}
