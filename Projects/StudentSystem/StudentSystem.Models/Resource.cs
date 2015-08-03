
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace StudentSystem.Models
{
    public class Resource
    {
        private ICollection<License> licenses;

        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }
            
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public ICollection<License> Licenses {
            get { return this.licenses; } 
            set { this.licenses = value; }
        }
    }
}
