using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace SIKONSystem.DisplayModel
{
    public class LectureDetailDM
    {
        public Lecture Lecture { get; set; }
        public List<Booking> Bookings { get; set; }
        public Booking Booking { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }
        private readonly MvcDbContext _context;

        public LectureDetailDM(MvcDbContext context)
        {
            _context = context;
        }
    }
}
