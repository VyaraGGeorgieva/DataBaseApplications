using System;
using System.ComponentModel.DataAnnotations;


namespace StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; } 

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }

    }
}
