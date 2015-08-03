using System;
using System.Linq;
using PhoneBook.Data;

namespace PhoneBook.ConsoleClient
{
    class AllChannels
    {
        static void  Main()
        {
            var context = new PhonebookEntity();
            var allChannels = context.ChannelMessages
                .Select(ch => new
                {
                    ch.Channel.Name,
                    ChannelMessages = ch.Channel.ChannelMessages
                    .Select(c=> new
                    {
                    c.Content,
                    c.DateTime,
                    c.User.Username
                    })
                    
                });
            foreach (var channel in allChannels)
            {
                Console.WriteLine(channel.Name);
                Console.WriteLine("--Messages:--");
                foreach (var cont in channel.ChannelMessages)
                {
                    Console.WriteLine("Content:{0}, DateTime: {1}, User:{2}",
                        cont.Content,
                        cont.DateTime,
                        cont.Username);
                }
                Console.WriteLine();
            }
        }
    }
}
