
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EFMapping;

namespace PhotographsXml
{
    class Photographs
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var photographs = context.Photographs
                .OrderBy(p=> p.Title)
                .Select(p => new
                {
                    title = p.Title,
                    category = p.Category.Name,
                    link = p.Link,
                    equipment = new
                    {
                        camera = new
                        {
                            name = p.Equipment.Camera.Manufacturer.Name + " " +
                                p.Equipment.Camera.Model,
                            megapixels = p.Equipment.Camera.Megapixels
                        },
                        lens = new
                        {
                              name = p.Equipment.Lens.Manufacturer.Name + " " +
                              p.Equipment.Lens.Model,
                              price = p.Equipment.Lens.Price
                        }
                    }
                });

            var xmlDoc = new XDocument();
            var rootElement = new XElement("photographs");
            xmlDoc.Add(rootElement);

            foreach (var photograph in photographs)
            {
                var photographXml = new XElement("photograph");
                photographXml.Add(new XAttribute("title", photograph.title));
                photographXml.Add(new XElement("category", photograph.category));
                photographXml.Add(new XElement("link", photograph.link));

                var equipmentXml = new XElement("equipment");
                
                equipmentXml.Add(new XElement("camera", photograph.equipment.camera.name, new XAttribute("megapixels", photograph.equipment.camera.megapixels)));

                if (photograph.equipment.lens.price.HasValue)
                {
                    equipmentXml.Add(new XElement("lens",
                        photograph.equipment.lens.name,
                        new XAttribute("price", string.Format("{0:F2}", photograph.equipment.lens.price))));
                }
                else
                {
                    equipmentXml.Add(new XElement("lens",
                        photograph.equipment.lens.name));
                }
                photographXml.Add(equipmentXml);
                rootElement.Add(photographXml);
            }
            rootElement.Save("photographs.xml");
        }
    }
}
