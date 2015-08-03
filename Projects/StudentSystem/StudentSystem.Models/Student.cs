

using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Student
    {
        public ICollection<Course> courses;

        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
            
        [Key]
        public int StudentId  { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
