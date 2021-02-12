using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIKONSystem.Controllers;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserPlaceOnWaitlist()
        {
            //Arrange
            var bookings = new List<Booking>() {new Booking(1, 1), new Booking(2, 1), new Booking(3, 1)};
            var room = new Room(3, "A1.01");
            var lecture = new Lecture();
            lecture.Bookings = bookings;
            lecture.Room = room;
            lecture.WaitList = new Queue<WaitList>();
            var user = new User();

            //Act
            user.Partake(lecture);

            //Assert
            Assert.AreEqual(1, lecture.WaitList.Count);
        }

        [TestMethod]
        public void MultipleUserBookings()
        {
            //Arrange
            var user1 = new User(1);
            var user2 = new User(2);
            var user3 = new User(3);
            var users = new List<User>() {user1, user2, user3};
            var room = new Room(3, "A2.02");
            var bookings = new List<Booking>();
            var lecture = new Lecture();
            lecture.Bookings = bookings;
            lecture.Room = room;

            //Act
            foreach (var user in users)
            {
                user.Partake(lecture);
            }

            //Assert
            Assert.AreEqual(3, lecture.Bookings.Count);
        }

        [TestMethod]
        public void WaitlistUserToBooking()
        {
            //Arrange
            var user1 = new User(1);
            var user2 = new User(2);
            var lecture = new Lecture(1);
            var userWL = new WaitList(user2.UserId, lecture.LectureId);
            var waitlist = new Queue<WaitList>();
            lecture.Bookings.Add(new Booking(1,1));
            lecture.WaitList.Enqueue(userWL);
            Booking bookingValue = new Booking();

            //Act
            bookingValue = user1.Cancel(lecture);

            //Assert
            Assert.AreEqual(bookingValue.UserId, 2);
        }
    }
}
