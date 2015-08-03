﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Resource> resources;
        private ICollection<Homework> homeworks; 
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Resources = new HashSet<Resource>();
            this.Homeworks = new HashSet<Homework>();
        }
            
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students 
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
