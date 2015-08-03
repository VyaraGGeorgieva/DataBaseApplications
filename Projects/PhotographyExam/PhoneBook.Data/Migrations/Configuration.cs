using Phonebook.Models;

namespace PhoneBook.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhoneBook.Data.PhonebookEntity>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhoneBook.Data.PhonebookEntity context)
        {
            if (!context.Users.Any())
            {
                User vladi = new User
                {
                    Username = "VGeorgiev",
                    FullName = "Vladimir Georgiev",
                    PhoneNumber = "0894545454"
                };
                context.Users.Add(vladi);

                User nakov = new User
                {
                    Username = "Nakov",
                    FullName = "Svetlin Nakov",
                    PhoneNumber = "0897878787"
                };
                context.Users.Add(nakov);

                User angel = new User
                {
                    Username = "Ache",
                    FullName = "Angel Georgiev",
                    PhoneNumber = "08976252525"
                };
                context.Users.Add(angel);

                User alex = new User
                {
                    Username = "Alex",
                    FullName = "Alexandra Svilarova",
                    PhoneNumber = "0899847464"
                };
                context.Users.Add(alex);

                User petya = new User
                {
                    Username = "Petya",
                    FullName = "Petya Grozdarska",
                    PhoneNumber = "08976252098"
                };
                context.Users.Add(petya);

                Channel one = new Channel
                {
                    Name = "Malinki"
                };
                context.Channels.Add(one);

                Channel two = new Channel
                {
                    Name = "SoftUni"
                };
                context.Channels.Add(two);

                Channel three = new Channel
                {
                    Name = "Programmers"
                };
                context.Channels.Add(three);

                Channel four = new Channel
                {
                    Name = "Admins"
                };
                context.Channels.Add(four);

                Channel five = new Channel
                {
                    Name = "Geeks"
                };
                context.Channels.Add(five);

                ChannelMessage first = new ChannelMessage
                {
                    Channel = one,
                    Content = "Hey dudes, are you ready for tonight?",
                    DateTime = DateTime.Now,
                    User = petya
                };
                context.ChannelMessages.Add(first);

                ChannelMessage second = new ChannelMessage
                {
                    Channel = one,
                    Content = "Hey Petya, this is the SoftUni chat.",
                    DateTime = DateTime.Now,
                    User = vladi
                };
                context.ChannelMessages.Add(second);

                ChannelMessage third = new ChannelMessage
                {
                    Channel = one,
                    Content = "Hahaha, we are ready!",
                    DateTime = DateTime.Now,
                    User = vladi
                };
                context.ChannelMessages.Add(third);

                ChannelMessage forth = new ChannelMessage
                {
                    Channel = one,
                    Content = "Oh my god. I mean for drinking beers!",
                    DateTime = DateTime.Now,
                    User = petya
                };
                context.ChannelMessages.Add(forth);

                ChannelMessage fifth = new ChannelMessage
                {
                    Channel = one,
                    Content = "We're sure",
                    DateTime = DateTime.Now,
                    User = vladi
                };
                context.ChannelMessages.Add(fifth);
                context.SaveChanges();
            }
            {
                
            }
        }
    }
}
