using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Phonebook.Models
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int IdRecipient { get; set; }

        public int IdSender { get; set; }

        public virtual User Recipient { get; set; }

        public virtual User Sender { get; set; }
    }
}
