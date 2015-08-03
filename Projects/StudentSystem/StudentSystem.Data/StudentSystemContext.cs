using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemContext : DbContext
    {
        
        public StudentSystemContext()
            : base("name=StudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }
        
    }

    
}