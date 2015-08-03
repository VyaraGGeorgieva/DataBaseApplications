using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Phonebook.Models
{
    public class ChannelMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int ChannelId { get; set; }

        public int UserId { get; set; }

        public virtual Channel Channel{ get; set; }

        public virtual User User { get; set; }
    }
}
