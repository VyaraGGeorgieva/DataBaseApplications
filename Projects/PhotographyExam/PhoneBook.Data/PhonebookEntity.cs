using System.Data.Entity;
using Phonebook.Models;
using PhoneBook.Data.Migrations;

namespace PhoneBook.Data
{
    public class PhonebookEntity : DbContext
    {
        
        public PhonebookEntity()
            : base("name=PhonebookEntity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookEntity,Configuration>());
        }

        public virtual DbSet<Channel> Channels  { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }
    }
}