//Write a program that extracts all different artists, which are found in the catalog.xml. For each artist print the number of albums in the catalogue. Use the DOM parser and a Dictionary<string, int> (use the artist name as key and the number of albums as value in the dictionary).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ArtistsAlbums
{
    class Tester
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            XmlElement rootNode = doc.DocumentElement;

            Dictionary<string, int> artistsAlbumsCount = new Dictionary<string, int>();

            foreach (XmlElement child in rootNode.ChildNodes)
            {
                var currArtist = child["artist"].InnerText;
                int numberAlbumsEachArt = rootNode.ChildNodes.Cast<XmlElement>()
                    .Count(a => a["artist"].InnerText == currArtist);

                //check if they are unique
                if (!artistsAlbumsCount.ContainsKey(currArtist))
                {
                    artistsAlbumsCount.Add(currArtist, numberAlbumsEachArt);

                }
            }
            foreach (var artist in artistsAlbumsCount)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
            }
        }
    }
}
