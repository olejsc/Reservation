using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reservation
{
    public class ReservationManager : IEnumerable<Booking>
    {
        /// <summary>
        /// Earliest check in available at 14 by default.
        /// </summary>
        public static readonly TimeSpan _EarliestCheckinTime = TimeSpan.FromHours(14);

        /// <summary>
        /// Latest checkout possible from 12'o clock by default.
        /// </summary>
        public static readonly TimeSpan _endOfReservation = TimeSpan.FromHours(12);

        /// <summary>
        /// How far ahead in time the room manager takes reservations.
        /// </summary>
        private static DateTime _maxReservationCalendarLength = DateTime.UtcNow.AddMonths(6);

        /// <summary>
        /// A list collection of all the current reservations.
        /// </summary>
        private List<Booking> _reservations;

        public List<Booking> Reservations { get => _reservations; set => _reservations = value; }

        public void AddReservation (Booking res)
        {
            Reservations.Add(res);
        }

        public void RemoveReservation (Booking res)
        {
            Reservations.Remove(res);
        }

        public Booking[] AllAvailableRoomsAtDate (DateTime start, DateTime end)
        {
            Booking[] availableRooms = (from res in Reservations
                                        where start > res.ReservationEnd && res.ReservationStart < end
                                        orderby res.Price ascending
                                        select res).ToArray<Booking>();
            return availableRooms;
        }

        public IEnumerator<Booking> GetEnumerator ()
        {
            return new ReservationEnumerator(Reservations.ToArray());
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return Reservations.GetEnumerator();
        }

        /// <summary>
        /// A private helper class to help enumerate the reservations.
        /// </summary>
        private class ReservationEnumerator : IEnumerator<Booking>
        {
            private int _currentIndex = -1;
            private Booking[] _reservations;

            public ReservationEnumerator (Booking[] reservations)
            {
                _reservations = reservations ?? throw new ArgumentNullException(nameof(reservations));
            }

            public Booking Current
            {
                get
                {
                    try { return _reservations[_currentIndex]; }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose ()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext ()
            {
                _currentIndex++;
                return (_currentIndex < _reservations.Length);
            }

            public void Reset ()
            {
                _currentIndex = -1;
            }
        }
    }
}