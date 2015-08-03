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

            XmlNode rootNode = doc.DocumentElement;

            Dictionary<string, int> artistsWithNumberOfAlbums =
                new Dictionary<string, int>();

            foreach (XmlNode albumNode in rootNode.ChildNodes)
            {
                var currArtist = albumNode["artist"].InnerText;

                int numberOfalbumsForThisArtist = rootNode.ChildNodes.Cast<XmlNode>()
                    .Count(
                        otherAlbumNode =>
                            otherAlbumNode["artist"].InnerText == currArtist);

                if (!artistsWithNumberOfAlbums.ContainsKey(currArtist))
                {
                    artistsWithNumberOfAlbums.Add(currArtist, numberOfalbumsForThisArtist);

                }
            }

            foreach (var artist in artistsWithNumberOfAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
            }

        }
    }
}
