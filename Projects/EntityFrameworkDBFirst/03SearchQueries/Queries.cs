using System;
using System.Linq;
using DbContext;

namespace SearchQueries
{
    internal class Queries
    {
        //1.	Find all employees who have projects started in the time period 2001 - 2003 (inclusive). Select the proe=ject's name, start date, end date and manager name.
        private static void Main()
        {
            var context = new SoftUniEntities();
            var employeesByProject = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate >= new DateTime(2001, 1, 1) &&
                              p.EndDate <= new DateTime(2003, 12, 31)))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Projects = e.Projects.Select(p => new
                    {
                        ProjectName = p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                }).ToList();
            //NO IDEA HOW TO PRINT THEM
            foreach (var project in employeesByProject)
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    project.FirstName,
                    project.LastName
                    );
            }

            

            //2.	Find all addresses, ordered by the number of employees who live there (descending), then by town name (ascending). Take only the first 10 addresses and select their address text, town name and employee count. 
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .Select(a => new
                {
                    addresstext = a.AddressText,
                    townName = a.Town.Name,
                    employeeCount = a.Employees.Count()
                })
                .Take(10)
                .ToList();
            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                    address.addresstext,
                    address.townName,
                    address.employeeCount);
            }

            //3.	Get an employee by id (e.g. 147). Select only his/her first name, last name, job title and projects (only their names). The projects should be ordered by name (ascending).

            var employee = context.Employees.Find(147);
            var empProjects = context.Projects
                .OrderBy(p => p.Name)
                .Select(p => p.Name);
            Console.WriteLine("{0} {1} {2} - {3} {4}",
                employee.EmployeeID,
                employee.FirstName,
                employee.LastName,
                employee.JobTitle,
                string.Join(", ", empProjects));

            //4.	Find all departments with more than 5 employees. Order them by employee count (ascending). Select the department name, manager name and first name, last name, hire date and job title of every employee.
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Employee.FirstName + " " + d.Employee.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    }).ToList()
                }).ToList();

            departments.ForEach(d =>
            {
                Console.WriteLine("Deprtment Name - {0}, Manager Name - {1}, Employees' Count: {2}", d.DepartmentName, d.ManagerName, d.Employees.Count);

            });
        }
    }
}
