
using System;
using System.Linq;
using DbContext;

namespace DaoClass
{
    class Dao
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            Add(new Employee());
            FindByKey(10);
            Modify(new Employee());
            Delete(new Employee());
        }

        public static void Add(Employee employee)
        {
            var context = new SoftUniEntities();
            context.Employees.Add(employee);
            employee.FirstName = "Peter";
            employee.LastName = "Petrov";
            employee.JobTitle = "Senior JS";
            employee.DepartmentID = 2;
            employee.HireDate = DateTime.Now;
            employee.Salary = 60000;
            context.SaveChanges();
            Console.WriteLine("Employee added: First Name: {0}, Last Name {1}", employee.FirstName, employee.LastName);
        }

        public static Employee FindByKey(int key)
        {
            var context = new SoftUniEntities();
            var employee = context.Employees
                .FirstOrDefault(e=>e.EmployeeID == key);
            Console.WriteLine("The empployee's ID is {0}", employee.EmployeeID);
            return employee;
        }

        public static void Modify(Employee employee)
        {
            var context = new SoftUniEntities();
            var foundEmp = context.Employees.Find(3);
            foundEmp.FirstName = "Vyara";
            foundEmp.LastName = "Georgieva";
            context.SaveChanges();
            Console.WriteLine("The employee's with Id {0} name now is {1} {2}",foundEmp.EmployeeID, foundEmp.FirstName, foundEmp.LastName);
        }

        public static void Delete(Employee employee)
        {
            var context = new SoftUniEntities();
            var deletedEmp = context.Employees.Remove(employee);
            var name = deletedEmp.FirstName == "Guy";
            context.SaveChanges();
            Console.WriteLine("The deleted employee's name is {0}", name);
        }

    }
}
