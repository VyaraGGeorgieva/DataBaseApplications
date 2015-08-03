using System.Collections.Generic;

namespace Phonebook.Models
{
    public class Channel
    {
        
        public Channel()
        {
            this.Users = new HashSet<User>();
            this.ChannelMessages = new HashSet<ChannelMessage>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users  { get; set; }

        public virtual ICollection<ChannelMessage> ChannelMessages  { get; set; }
    }
}
