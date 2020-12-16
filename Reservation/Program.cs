using System;
using System.Collections.Generic;
using System.Linq;

namespace Reservation
{
    public class Program
    {
        private static void Main (string[] args)
        {
            List<ABed> _beds = new(){new Standard(1, false, 100f), new Standard(1, false, 100f)};
            TV tv = new TV(TV.channelsAvailable.local,true,0.2f,"Samsung 14000xY Ultimate Local Smart TV",100f,0.4f,0.1f);
            Fridge fridge = new Fridge(0.0f,"Fridge x3400",30f,0.02f,0.0f);
            HashSet<ARoomProperty> aRoomProperties = new HashSet<ARoomProperty>(){tv,fridge};
            SingleRoom single1 = new SingleRoom(aRoomProperties,_beds);

            SingleRoom single2 = new(){Beds = _beds,RoomProperties = aRoomProperties};
            ARoom[] rooms = {single1,single2};
            HotelFloor hf = new HotelFloor(rooms);
            Dictionary<int,HotelFloor> floors = new();
            floors.Add(1, hf);
            ICustomer customer = new Customer
            {
                Age = 43,
                Firstname = "Freddy",
                Lastname = "Dos Santos",
                PhoneNumber = 92340234,
                RoomPreference = new RoomPreference
                {
                    Beds = _beds,
                    Price = 33f
                }
            };
            ReservationManager rm = new ReservationManager();
            HotelManager hm = new HotelManager(floors,rm);

            Console.WriteLine("hello world!");
            Console.ReadKey();
        }
    }
}