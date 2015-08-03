﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountains.Models
{
    public class Mountain
    {
        

        public Mountain()
        {
            this.Countries = new HashSet<Country>();
            this.Peaks = new HashSet<Peak>();
        }
            [Key]
        public int  Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries  { get; set; }
        public virtual ICollection<Peak> Peaks { get; set; }
    }
}
