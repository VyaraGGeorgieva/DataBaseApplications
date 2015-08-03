
using System;
using System.Collections.Generic;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Models;

namespace ConsoleClient
{
    class StudentSystemMain
    {
        private static void Main()
        {
            var context = new StudentSystemContext();

            //1.	Lists all students and their homework submissions. Select only their names and for each homework - content and content-type.
            var studentsHw = context.Students
                .Select(s => new
                {
                    Name = s.Name,
                    HWContent = s.Courses.Select(c => c.Homeworks
                        .Select(h => new
                        {
                            Content = h.Content,
                            ContentType = h.ContentType
                        }))
                })
                .ToList();

            studentsHw.ForEach(s =>
            {
                Console.WriteLine("{0}", s.Name);
                var homeworks = s.HWContent.ToList();
                homeworks.ForEach(c =>
                {
                    c.ToList().ForEach(h => Console.WriteLine("*{0} - {1}",
                        h.Content,
                        h.ContentType));
                });
            });

            //2.	List all courses with their corresponding resources. Select the course name and description and everything for each resource. Order the courses by start date (ascending), then by end date (descending).

            var courses = context.Courses
               .OrderBy(c => c.StartDate)
               .ThenByDescending(c => c.EndDate)
               .Select(c => new
               {
                   c.Name,
                   c.Description,
                   c.Resources
               })
               .ToList();

            courses.ForEach(c =>
            {
                Console.WriteLine("{0} - {1}", c.Name, c.Description);
                c.Resources.ToList().ForEach(r =>
                {
                    Console.WriteLine("{0}, {1} - {2}", r.Name, r.ResourceType, r.Url);
                });
            });

            //3.	List all courses with more than 5 resources. Order them by resources count (descending), then by start date (descending). Select only the course name and the resource count.
            var coursesLimit = context.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    CourseCount = c.Resources.Count
                }).ToList();

            //No Such data in the Base :))
            coursesLimit.ForEach(Console.WriteLine);
            
            //4.	List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results), and for each course count the number of students enrolled. Select the course name, start and end date, course duration (difference between end and start date) and number of students enrolled. Order the results by the number of students enrolled (in descending order), then by duration (descending).

            var date = DateTime.Now;
            var activeCourses = context.Courses
                .Where(c => c.StartDate < date && c.EndDate >= date)
                .ToList()
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => (c.EndDate - c.StartDate).TotalDays)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    StudentCount = c.Students.Count,
                    CourseDuration = (c.EndDate - c.StartDate).TotalDays
                }).ToList();

            foreach (var activeCourse in activeCourses)
            {
                Console.WriteLine("{0}, [{1:dd-MM-yyyy} - {2:dd-MM-yyyy}]:, {3} student, {4} days continues the course",
                    activeCourse.Name,
                    activeCourse.StartDate,
                    activeCourse.EndDate,
                    activeCourse.StudentCount,
                    activeCourse.CourseDuration);
            }

            //5.	For each student, calculate the number of courses he/she has enrolled in, the total price of these courses and the average price per course for the student. Select the student name, number of courses, total price and average price. Order the results by total price (descending), then by number of courses (descending) and then by the student's name (ascending).

            var studentsInfo = context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s=>s.Courses.Count)
                .Select(s => new
                {
                    CoursesCount = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AvgPrice = s.Courses.Sum(c => c.Price)/s.Courses.Count,
                    s.Name
                }).ToList();
            foreach (var studentInfo in studentsInfo)
            {
                Console.WriteLine("{0} {1:F} {2:F} {3}",
                    studentInfo.CoursesCount,
                    studentInfo.TotalPrice,
                    studentInfo.AvgPrice,
                    studentInfo.Name);
            }


        }
    }
}
