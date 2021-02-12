using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SIKONSystem.Models
{
    /// <summary>
    /// SikonUser class
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Fornavn")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Email skal være gyldig.")]
        //[MinLength(6, ErrorMessage = "Email kan ikke være mindre end 6 karakterer.")]
        public string Email { get; set; }

        [Display(Name = "Adresse")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Telefon Nr")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Display(Name = "Post Nr")]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        public bool AddAutismInfo { get; set; }

        //Navigation Properties
        public ICollection<Booking> Booking { get; set; }
        public Queue<WaitList> WaitList { get; set; }

        //Constructor
        public User()
        {

        }

        //Methods
        public Booking Partake(Lecture L)
        {
            if (L.Bookings.Count < L.Room.Capacity)
            {
                return Attend(L, this.UserId);
            }
            else
            {
                L.WaitList.Enqueue(new WaitList(this.UserId, L.LectureId));
                return null;
            }
        }

        public Booking Attend(Lecture L, int userId)
        {
            Booking booking = new Booking(userId, L.LectureId);
            //booking.User = U;
            L.Bookings.Add(booking);
            return booking;
        }

        public Booking Cancel(Lecture L)
        {
            Booking returnVal = null;
            foreach (Booking booking in L.Bookings)
            {
                if (booking.UserId == UserId)
                {
                    L.Bookings.Remove(booking);
                    if (L.WaitList.Count != 0)
                    {
                        int id = L.WaitList.Peek().UserId;
                        L.WaitList.Dequeue();
                        returnVal = Attend(L, id);
                        return returnVal;
                    }
                    else return returnVal;
                }
                else
                {
                    throw new Exception("Fejl i afmelding: Du var ikke tilmeldt denne begivenhed");
                }
            }
            return returnVal;
        }

        public User(int id)
        {
            UserId = id;
        }
    }
}
