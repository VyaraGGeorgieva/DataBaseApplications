

namespace ConcurrentChanges
{
    using System;
    using DbContext;

    public class ConcurrentChanges
    {
        public static void Main()
        {
            var context = new SoftUniEntities();

            var employee = context.Employees.Find(1);
            var newName = Console.ReadLine();
            employee.FirstName = newName;
            Console.ReadLine();

            context.SaveChanges();

            /* When concurrency mode is not fixed the second record is 
             * set in the database over the first change.
             * When it is fixed an exception is raised - DbUpdateConcurrencyException
             */
        }
    }
}