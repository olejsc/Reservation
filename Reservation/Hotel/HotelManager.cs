using System;
using System.Collections.Generic;
using System.Linq;

namespace Reservation
{
    public class HotelManager
    {
        private ReservationManager _reservationManager;

        private Dictionary<int, HotelFloor> _floors = new Dictionary<int, HotelFloor>();

        public HotelManager (Dictionary<int, HotelFloor> floors, ReservationManager reservationManager)
        {
            Floors = floors ?? throw new ArgumentNullException(nameof(floors));
            ReservationManager = reservationManager ?? throw new ArgumentNullException(nameof(reservationManager));
        }

        public ReservationManager ReservationManager { get => _reservationManager; init => _reservationManager = value; }
        public Dictionary<int, HotelFloor> Floors { get => _floors; set => _floors = value; }

        private void RegisterReservation (ICustomer customer, ARoom room)
        {
            ReservationManager.AddReservation(new Booking(100f, customer.ReservationEnd, customer.ReservationStart, customer, true));
        }

        public ARoom[] GetAvailableRoomsAtDateRange (DateTime start, DateTime end, int floor)
        {
            var result = (from res in ReservationManager
                          from room in Floors[floor]
                          where start > res.ReservationEnd && res.ReservationStart < end
                          where room.RoomGuid == res.RoomGuid
                          select room);
            return result.ToArray();
        }

        public ARoom[] RoomCandidates (RoomPreference rp)
        {
            ARoom[] rooms = null;
            HotelFloor temp = null;
            try
            {
                temp = Floors[rp.Floor];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
            if (temp != null)
            {
                rooms = (from room in temp
                         where room.Beds.Capacity == rp.Capacity
                         select room).ToArray<ARoom>();
            }
            return rooms;
        }
    }
}