using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Reservation;

namespace ReservationTests
{
    [TestOf(typeof(Customer))]
    [TestFixture]
    internal class CustomerTest
    {
        private Customer _cust;

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
        }

        [Test]
        public void ReadProperties ()
        {
            Assert.IsNotNull(_cust.RoomPreference);
        }

        [Test]
        public void GettingRoomPreferenceDoNotThrow ()
        {
            Assert.DoesNotThrow(() =>
            {
                RoomPreference rp;
                rp = _cust.RoomPreference;
            });
            Assert.That(_cust.RoomPreference.Beds, Is.All.InstanceOf(typeof(ABed)));
            Assert.That(_cust.RoomPreference.Beds, Is.Not.Null);
            Assert.That(_cust.RoomPreference.Capacity, Is.Positive);
        }

        [Test]
        public void VerifyAgeIsSetCorrectly ()
        {
            Assert.That(_cust.Age, Is.Not.Negative);
            Assert.That(_cust.Age, Is.Not.Zero);
        }

        [Test]
        public void FirstNameSetsCorrect ()
        {
            Assert.That(_cust.Firstname == "Tom");
        }

        [Test]
        public void LastNameSetsCorrect ()
        {
            Assert.That(_cust.Lastname == "Æøå");
        }

        [Test]
        public void PhoneNumberIsCorrect ()
        {
            Assert.That(_cust.PhoneNumber == 23);
        }
    }
}