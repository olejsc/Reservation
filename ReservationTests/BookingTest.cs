using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservation;
using NUnit.Framework;

namespace ReservationTests
{
    [TestOf(typeof(Booking))]
    [TestFixture]
    internal class BookingTest
    {
        private Booking _booking;
        private ICustomer _cust;

        [OneTimeSetUp]
        protected void SetUp ()
        {
            RoomPreference rp = new RoomPreference()
            {
                Floor = 1,
                Price = 100f,
                Beds = new List<ABed>() {
                        new Standard(1,
                                     false,
                                     25f),
                        new Standard(1,false,25f)
                    }
            };
            _cust = new Customer("Tom",
                     "Æøå",
                     45,
                     23,
                     DateTime.Today,
                     DateTime.Today.AddDays(1),
                     rp);
            _booking = new Booking(100f,
                                   DateTime.Now.AddDays(1),
                                   DateTime.Now,
                                   _cust);
        }

        [Test]
        public void CustomerNotNull ()
        {
            Assert.IsNotNull(_booking.Customer);
        }

        [Test]
        public void BookingDateEqualOrBeforeReservationStart ()
        {
            Assert.That(_booking.BookingDate <= _booking.ReservationStart);
        }

        [Test]
        public void ReservationStartBeforeReservationEnd ()
        {
            Assert.That(_booking.ReservationStart < _booking.ReservationEnd);
        }

        [Test]
        public void PriceNotNegative ()
        {
            Assert.That(_booking.Price > 0);
        }
    }
}