using System;

namespace Reservation
{
    /// <summary>
    /// A Data class containing only data, not logic, about the reservation.
    /// </summary>
    public class Booking
    {
        private protected Guid _reservationId;
        private Guid _roomGuid;
        private ICustomer customer;

        private DateTime _bookingDate;

        private float _price;
        private bool isPaid = false;

        private DateTime _reservationEnd;

        private DateTime _reservationStart;

        public Booking (float price, DateTime reservationEnd, DateTime reservationStart, ICustomer customer, bool isPaid = false)
        {
            Price = price;
            ReservationEnd = reservationEnd;
            ReservationStart = reservationStart;
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            this.isPaid = isPaid;
        }

        public DateTime BookingDate
        {
            get { return _bookingDate; }
            set { _bookingDate = value; }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public DateTime ReservationEnd
        {
            get { return _reservationEnd; }
            set { _reservationEnd = value; }
        }

        public DateTime ReservationStart
        {
            get { return _reservationStart; }
            set { _reservationStart = value; }
        }

        private protected Guid ReservationId { get => _reservationId; init => _reservationId = value; }
        public ICustomer Customer { get => customer; set => customer = value; }
        public Guid RoomGuid { get => _roomGuid; set => _roomGuid = value; }
    }
}