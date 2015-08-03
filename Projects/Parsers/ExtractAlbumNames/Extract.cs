using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractAlbumNames
{
    class Extract
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            //root
            XmlElement root = doc.DocumentElement;

            foreach (XmlElement child in root.ChildNodes)
            {
                var album = child["name"];
                if (album != null)
                {
                    Console.WriteLine("Album Name: {0}",album.InnerText);
                }
            }
        }
    }
}
