using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class WaitList
    {
        public int WaitListId { get; set; }
        [Display(Name = "Bruger")]
        public int UserId { get; set; }
        [Display(Name = "Oplæg")]
        public int LectureId { get; set; }

        //Navigation Properties
        [Display(Name = "Bruger")]
        public User User { get; set; }
        [Display(Name = "Oplæg")]
        public Lecture Lecture { get; set; }

        //Constructor
        public WaitList()
        {
            
        }

        public WaitList(int userId, int lectureId)
        {
            UserId = userId;
            LectureId = lectureId;
        }

        public WaitList(Booking b)
        {
            UserId = b.UserId;
            LectureId = b.LectureId;
        }
    }
}
