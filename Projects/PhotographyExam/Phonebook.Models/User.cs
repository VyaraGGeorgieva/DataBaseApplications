using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class User
    {
        public ICollection<Channel> channels;
        public ICollection<UserMessage> sentUserMessages;
        public ICollection<UserMessage> recievedUserMessages; 

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.recievedUserMessages = new HashSet<UserMessage>();
            this.recievedUserMessages = new HashSet<UserMessage>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(60)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ICollection<UserMessage> SentUsersMessages  { get; set; }
        public virtual ICollection<UserMessage> RecievedUserMessages  { get; set; }
    }
}
