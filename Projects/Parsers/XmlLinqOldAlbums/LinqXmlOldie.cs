
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlLinqOldAlbums
{
    class LinqXmlOldie
    {
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load("../../../Catalog.xml");

            Console.WriteLine("XML Document loaded !");
            Console.WriteLine();

            var oldAlbums =
                (from album in xmlDoc.Descendants("album")
                 where Decimal.Parse(album.Element("year").Value) <= (DateTime.Now.Year - 5)
                 select new
                 {
                     Name = album.Element("name").Value,
                     Price = album.Element("price").Value
                 }
                ).ToList();

            foreach (var album in oldAlbums)
            {
                Console.WriteLine("Album: {0}, Price: {1}", album.Name, album.Price);
            }
        }
    }
}
