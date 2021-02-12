using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Display(Name = "Bruger")]
        public int UserId { get; set; }
        [Display(Name = "Oplæg")]
        public int LectureId { get; set; }
        public int WaitList { get; set; }


        //Navigation Properties
        [Display(Name="Bruger")]
        public User User { get; set; }
        [Display(Name = "Oplæg")]
        public Lecture Lecture { get; set; }

        //Constructor
        public Booking()
        {
            
        }

        public Booking(int userId, int lectureId)
        {
            UserId = userId;
            LectureId = lectureId;
        }
    }
}
