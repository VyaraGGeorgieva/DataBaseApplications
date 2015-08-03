using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mountains.Models
{
   
    public class Country
    {
        private ICollection<Mountain> mountains;
        
        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }

        [Key]
        [MinLength(2)]
        [MaxLength(2)]
        [Column(TypeName = "char")]
        public string CountryCode { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Mountain> Mountains { get; set; }
    }
}
