using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OldAlbums
{
    class Oldie
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../Catalog.xml");

            Console.WriteLine("XML Document loaded !");
            Console.WriteLine();

            int yearAfter5Years = DateTime.Now.Year - 5;

            string albumsQuery =
                "/catalog/album[year <= " + yearAfter5Years + "]";

            XmlNodeList albumsList = xmlDoc.SelectNodes(albumsQuery);

            foreach (XmlNode album in albumsList)
            {
                Console.WriteLine("Album: {0}, Price: {1}",
                    album["name"].InnerText, album["price"].InnerText);
            }
        }
    }
}
