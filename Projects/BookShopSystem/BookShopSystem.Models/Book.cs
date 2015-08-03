
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShopSystem.Models
{
    public class Book
    {
        private ICollection<Category> categories;
        public Book()
        {
            this.categories = new HashSet<Category>();
        }
        [Key]
        public int BookId { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public AgeRestriction AgeRestriction { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public int CategoryId { get; set; }

       
        public int AuthorId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<Category> Categories
        {
            get {return this.categories;}
            set { this.categories = value; }
        }

        public virtual Author Author { get; set; }
    }
}
