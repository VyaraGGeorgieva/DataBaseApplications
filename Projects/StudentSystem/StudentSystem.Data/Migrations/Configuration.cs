using System.Collections.Generic;
using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            if (!context.Students.Any())
            {
                var studentOne = new Student()
                {
                    Name = "Ivan Ivanov",
                    PhoneNumber = "+359 888 888 888",
                    RegistrationDate = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "DBA course",
                            Description = "Cool course!",
                            StartDate = new DateTime(2015,1,1),
                            EndDate = new DateTime(2016,10,1),
                            Price = 1000m,
                            Homeworks = new List<Homework>()
                            {
                                new Homework()
                                {
                                    Content = "some cool shit",
                                    SubmissionDate = DateTime.Now,
                                    ContentType = ContentType.ApplicationZip
                                }
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource()
                                {
                                    Name = "book on cool stuff",
                                    ResourceType = ResourceType.Documentation,
                                    Url = "None"
                                }
                            }
                        }
                    }
                };

            var studentTwo = new Student()
                {
                    Name = "Peter Petrov",
                    PhoneNumber = "+359 555 888 888",
                    RegistrationDate = DateTime.Now,
                    Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "PHP cpurse",
                            Description = "Cool course!",
                            StartDate = new DateTime(2014,1,1),
                            EndDate = new DateTime(2015,10,1),
                            Price = 1000m,
                            Homeworks = new List<Homework>()
                            {
                                new Homework()
                                {
                                    Content = "First HW",
                                    SubmissionDate = DateTime.Now,
                                    ContentType = ContentType.ApplicationPdf
                                }
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource()
                                {
                                    Name = "Intro",
                                    ResourceType = ResourceType.Presentation,
                                    Url = "None"
                                }
                            }
                        }
                    }
                };
                context.Students.Add(studentOne);
                context.Students.Add(studentTwo);
                context.SaveChanges();
              
            }

            base.Seed(context);
            }
      
        }
    }
