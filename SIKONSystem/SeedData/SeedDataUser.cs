using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIKONSystem.Data;
using SIKONSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.SeedData
{
    public static class SeedDataUser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDbContext>>()))
            {
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        FirstName = "James",
                        LastName = "Hemingway",
                        Email = "lol@me.dk",
                        Address = "Hopsavej 2",
                        Telephone = "10101010",
                        Zipcode = "1010",
                        AddAutismInfo = true
                    },

                    new User
                    {
                        FirstName = "Billy",
                        LastName = "Brighton",
                        Email = "rofl@me.dk",
                        Address = "Wassupgade 7",
                        Telephone = "93057193",
                        Zipcode = "4362",
                        AddAutismInfo = false
                    },

                    new User
                    {
                        FirstName = "Mike",
                        LastName = "Scallywag",
                        Email = "wtf@me.dk",
                        Address = "Nejstræde 10",
                        Telephone = "49571383",
                        Zipcode = "8452",
                        AddAutismInfo = true
                    },

                    new User
                    {
                        FirstName = "Hans",
                        LastName = "Carlos Alexandros",
                        Email = "wat@me.dk",
                        Address = "Kanon Alle 5",
                        Telephone = "10859291",
                        Zipcode = "1846",
                        AddAutismInfo = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
