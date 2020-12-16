using System;

namespace Reservation
{
    public class Customer : ICustomer
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }
        public int Age { get; init; }
        public int PhoneNumber { get; init; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public RoomPreference RoomPreference { get => _roomPreference; init => _roomPreference = value; }

        private RoomPreference _roomPreference;

        public Customer ()
        {
        }

        public Customer (string firstname,
                         string lastname,
                         int age,
                         int phoneNumber,
                         DateTime reservationStart,
                         DateTime reservationEnd,
                         RoomPreference roomPreference)
        {
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Age = age;
            PhoneNumber = phoneNumber;
            ReservationStart = reservationStart;
            ReservationEnd = reservationEnd;
            RoomPreference = roomPreference;
        }
    }

    public interface ICustomer
    {
        public string Firstname { get; }
        public string Lastname { get; }
        public int Age { get; }
        public int PhoneNumber { get; }
        public DateTime ReservationStart { get; }
        public DateTime ReservationEnd { get; }
        public RoomPreference RoomPreference { get; }
    }
}