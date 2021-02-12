using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        private string _name;
        [Required]
        [Display(Name = "Lokale")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _capacity;
        [Required]
        [Display(Name="Kapacitet")]
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        //Navigation Properties

        public ICollection<Lecture> Lectures { get; set; }

        //Constructor
        public Room(int capacity, string name)
        {
            _capacity = capacity;
            _name = name;
        }

        public Room()
        {
            
        }
    }
}
