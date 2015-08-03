using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EFMapping;

namespace ManufacturersJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var manufacturers = context.Manufacturers
                .OrderBy(m=> m.Name)
                .Select(m => new
                {
                    manufacturer = m.Name,
                    cameras = m.Cameras
                        .OrderBy(c=>c.Model)
                        .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                });
            var jsSer = new JavaScriptSerializer();
            var manufacturersJson = jsSer.Serialize(manufacturers.ToList());
            File.WriteAllText(@"manufacturers-and-cameras.json", manufacturersJson);
        }
    }
}
