using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMapping
{
    class Tester
    {
        static void Main()
        {
            var  context = new PhotographySystemEntities();
            var manModel = context.Cameras
                .OrderBy(c=> c.Manufacturer.Name)
                .ThenBy(c=>c.Model)
                .Select(c => new
                {
                    man = c.Manufacturer.Name,
                    model = c.Model
                }).ToList();
            foreach (var model in manModel)
            {
                Console.WriteLine("{0} {1}",
                    model.man,
                    model.model);
            }
        }
    }
}
