
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(55)]
        public string Name { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
