using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ArtistsList
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            XmlElement root = doc.DocumentElement;
            
            SortedSet<string> artists = new SortedSet<string>();

            foreach (XmlElement child in root.ChildNodes)
            {
                var artistsNames = child["artist"];
                artists.Add(artistsNames.InnerText);
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist: {0}", artist);
            }
        }
    }
}
