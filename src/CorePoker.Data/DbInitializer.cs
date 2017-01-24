using System;
using System.Linq;

namespace CorePoker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CorePokerContext context)
        {
            context.Database.EnsureCreated();

            // first player
            var player = new Player {CreatedAt = DateTime.UtcNow, Nickname = "Harry Potter"};

            // first table
            var table = new Table
            {
                PublicId = Guid.Parse("12BF9278-74C6-4184-8DDE-F96CA20E33EF").ToString(),
                Name = "First Table Ever",
                CreatedAt = DateTime.UtcNow,
                Owner = player
            };

            // player is also a member of the table, not just owner
            player.MemberTables.Add(new TablePlayer {Table = table});

            if (!context.Tables.Any())
            {
                context.Tables.Add(table);
                context.SaveChanges();
            }
        }
    }
}
