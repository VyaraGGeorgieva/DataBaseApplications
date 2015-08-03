
using System;
using System.Linq;

namespace StoredProcedure
{
    using DbContext;
    class StoredProc
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            var employees = context.usp_get_full_names().Take(10);
            Console.WriteLine(string.Join(", ", employees));

        }
    }
}
