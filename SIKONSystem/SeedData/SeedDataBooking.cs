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
    public class SeedDataBooking
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcDbContext>>()))
            {
                if (context.Booking.Any())
                {
                    return;   // DB has been seeded
                }

                context.Booking.AddRange(
                    new Booking
                    {
                        UserId = 1,
                        LectureId = 1
                    },

                    new Booking
                    {
                        UserId = 2,
                        LectureId = 1
                    },

                    new Booking
                    {
                        UserId = 1,
                        LectureId = 3
                    },

                    new Booking
                    {
                        UserId = 4,
                        LectureId = 4
                    },

                    new Booking
                    {
                        UserId = 1,
                        LectureId = 2
                    },

                    new Booking
                    {
                        UserId = 2,
                        LectureId = 2
                    },

                    new Booking
                    {
                        UserId = 2,
                        LectureId = 4
                    },

                    new Booking
                    {
                        UserId = 3,
                        LectureId = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
