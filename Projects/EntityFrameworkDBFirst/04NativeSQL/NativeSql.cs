//Find all employees who have projects with start date in the year 2002. Select only their first name. Solve this task by using both LINQ query and native SQL query through the context. Measure the difference in performance in both cases with a Stopwatch. Comment out any printing so the measurements can be most accurate.

using System;
using System.Diagnostics;
using System.Linq;

namespace NativeSQL
{
    using DbContext;
    class NativeSql
    {
        
        static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            PrintNamesNativeQuery(new SoftUniEntities());
            Console.WriteLine("Native {0}", stopWatch.Elapsed);

            stopWatch.Restart();
            PrintNamesWithLinqQuery(new SoftUniEntities());
            Console.WriteLine("LINQ {0}", stopWatch.Elapsed);

            stopWatch.Stop();
        }
        private static void PrintNamesNativeQuery(SoftUniEntities context)
        {
            var employees = context.Employees.SqlQuery(@"
                SELECT *
                FROM Employees e
                JOIN EmployeesProjects ep
                ON e.EmployeeID = ep.EmployeeID
                JOIN Projects p
                ON p.ProjectID = ep.ProjectID
                WHERE p.StartDate >= '2002-1-1' AND p.StartDate <= '2002-12-31'
            ").ToList();
            var employeesCount = employees.Count;
            Console.WriteLine(employeesCount);
        }

        private static void PrintNamesWithLinqQuery(SoftUniEntities context)
        {
            var emplyeesByProject = context.Employees
           .Where(e => e.Projects
               .Any(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                         p.StartDate <= new DateTime(2002, 12, 31)))
           .OrderBy(e => e.FirstName)
           .Select(e => new
           {
               EmpName = e.FirstName + " " + e.LastName
           })
           .ToList();
            Console.WriteLine(emplyeesByProject.Count);
        }
    }
}
