
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public class Category
    {
        private ICollection<Book> books;
        private ICollection<Author> authors; 
        public Category()
        {
            this.books = new HashSet<Book>();
            this.authors = new HashSet<Author>();
        }
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public int BookId { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        

    }
}
