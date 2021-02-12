using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Lecture
    {
        public int LectureId { get; set; }
        [Display(Name="Lokale")]
        public int RoomId { get; set; }
        [Display(Name="Kategori")]
        public int CategoryId { get; set; }

        private string _title;
        
        [Required]
        [Display(Name= "Titel")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private DateTime _startTime;
        [Display(Name = "Starttidspunkt")]
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private string _speaker;
        [Display(Name = "Oplægsholder")]
        public string Speaker
        {
            get { return _speaker; }
            set { _speaker = value; }
        }

        //public LectureCategory Category { get; set; }

        private string _description;
        [Display(Name = "Beskrivelse")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int _timeFrame;

        [Display(Name="Tidsramme")]
        public int TimeFrame
        {
            get { return _timeFrame; }
            set { _timeFrame = value; }
        }

        private int _spaces;

        [Display(Name="Antal Pladser")]
        public int Spaces
        {
            get { return _spaces; }
            set { _spaces = value; }
        }

        

        //Navigation Properties
        private Room _room;

        [Display(Name="Lokale")]
        public Room Room
        {
            get { return _room; }
            set { _room = value; }
        }

        private Category _category;
        [Display(Name="Kategori")]
        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public ICollection<Booking> Bookings { get; set; }

        public Queue<WaitList> WaitList { get; set; }

        //Constructor
        public Lecture()
        {
            Bookings = new List<Booking>();
            //Bookings = context.Booking.ToList().FindAll(x => x.Lecture.LectureId.Equals(context.Lecture))
        }

        public Lecture(int id)
        {
            LectureId = id;
            Bookings = new List<Booking>();
            WaitList = new Queue<WaitList>();
        }

        public Lecture(string title, DateTime startTime, string speaker, string description, int timeFrame)
        {
            _title = title;
            _startTime = startTime;
            _speaker = speaker;
            _description = description;
            _timeFrame = timeFrame;
        }
    }
}
