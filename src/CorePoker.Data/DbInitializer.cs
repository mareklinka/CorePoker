using System;
using System.Linq;

namespace CorePoker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CorePokerContext context)
        {
            context.Database.EnsureCreated();

            var defaultTable = new Table
            {
                PublicId = Guid.Parse("12BF9278-74C6-4184-8DDE-F96CA20E33EF").ToString(),
                Id = 100
            };

            if (!context.Tables.Any())
            {
                context.Tables.Add(defaultTable);
                context.SaveChanges();
            }
        }
    }
}
