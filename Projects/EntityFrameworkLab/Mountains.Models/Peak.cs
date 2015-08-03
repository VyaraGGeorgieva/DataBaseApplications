using System.ComponentModel.DataAnnotations;

namespace Mountains.Models
{
    public class Peak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public float Elevation { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
