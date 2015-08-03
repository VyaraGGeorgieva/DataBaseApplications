
using System.ComponentModel.DataAnnotations;


namespace Models.News
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Content { get; set; }
    }
}
