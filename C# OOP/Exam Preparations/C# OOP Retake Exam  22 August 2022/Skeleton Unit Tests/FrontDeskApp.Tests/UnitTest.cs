using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new("Radison", 5);
        }

        [Test]
        public void ConstructorSetsFullNameAndCategoryCorrectly()
        {

            string expectedFullName = "Radison";
            int expectedCategory = 3;
            Hotel testHotel = new(expectedFullName, expectedCategory);

            Assert.AreEqual(expectedFullName, testHotel.FullName);
            Assert.AreEqual(expectedCategory, testHotel.Category);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void FullNameSetterThrowsExceptionWhenValueIsNullOrWhiteSpace(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 5));
        }

        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(6)]
        [TestCase(10)]
        public void FullNameSetterThrowsExceptionWhenValueOutOfRange(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Radison", category));
        }

        [Test]
        public void AddRoomAddsRoomCorrectly()
        {
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoomThrowsExceptionWhenThereAreNoAdoults(int adults)
        {
            Room room = new(3,100);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults,3,5,10));
        }

        [TestCase(-10)]
        [TestCase(-1)]
        public void BookRoomThrowsExceptionWhenThereAreNoAchildren(int children)
        {
            Room room = new(3, 100);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, children,5,100));
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoomThrowsExceptionWhenThereAreNoAresidenceDuration(int residenceDuration)
        {
            Room room = new(3, 100);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3,3, residenceDuration,100));
        }

        [Test]
        public void BookRoomNotTurnoverWhenNotEnoughtBeds()
        {
            Room room = new(3, 100);
            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 100);

            Assert.That(hotel.Turnover, Is.EqualTo(0));

        }

        [Test]
        public void BookRoomNoBookingWhenBudgetToLow()
        {
            Room room = new(5, 70);
            hotel.AddRoom(room);
            hotel.BookRoom(4, 0, 2, 100);

            double expectedTurnover = 0;
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(expectedTurnover, Is.EqualTo(0));
        }

        [Test]
        public void BookRoomBooksRoomCorrectly()
        {
            Room room = new(5, 70);
            hotel.AddRoom(room);
            hotel.BookRoom(4, 1, 2, 150);

            double expectedTurnover = 140;
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(expectedTurnover, Is.EqualTo(hotel.Turnover));

        }
    }
}