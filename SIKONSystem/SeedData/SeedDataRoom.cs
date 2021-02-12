using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace SIKONSystem.SeedData
{
    public class SeedDataRoom
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDbContext>>()))
            {
                if (context.Room.Any())
                {
                    return;   // DB has been seeded
                }

                context.Room.AddRange(
                    new Room
                    {
                        Name = "A2.10",
                        Capacity = 20
                    },

                    new Room
                    {
                        Name = "C1.07",
                        Capacity = 5
                    },

                    new Room
                    {
                        Name = "B3.04",
                        Capacity = 25
                    },

                    new Room
                    {
                        Name = "A1.05",
                        Capacity = 10
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
