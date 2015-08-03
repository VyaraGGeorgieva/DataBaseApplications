using System.Xml.Linq;
using EFMapping;

namespace ImportManufactrsXml
{
    class XmlParser
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var xmlDoc = XDocument.Load(@"../../manufacturers-and-lenses.xml");
            var manufacturerElements = xmlDoc.Root.Elements();
            foreach (var element in manufacturerElements)
            {
                var manufacturerEntity = new Manufacturer();
                manufacturerEntity.Name = element.Element("manufacturer-name").Value;
            }
        }
    }
}
