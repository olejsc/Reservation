using System;
using System.Collections.Generic;
using System.Linq;

namespace Reservation
{
    public abstract class ARoom
    {
        private Guid _roomGuid;

        public Guid RoomGuid
        {
            get { return _roomGuid; }
            init { _roomGuid = value; }
        }

        public ARoom (HashSet<ARoomProperty> roomProperties = null)
        {
            RoomGuid = new Guid();
            RoomProperties = roomProperties;
        }

        private float _basePrice = 100f;

        public float BasePrice
        {
            get { return _basePrice; }
            init { _basePrice = value; }
        }

        public abstract HashSet<ARoomProperty> RoomProperties { get; set; }
        public abstract List<ABed> Beds { get; set; }

        public abstract float TotalPrice ();
    }

    public class SingleRoom : ARoom
    {
        private HashSet<ARoomProperty> _roomProperties;
        private List<ABed> _beds;

        public SingleRoom (HashSet<ARoomProperty> roomProperties, List<ABed> beds)
        {
            RoomProperties = roomProperties ?? throw new ArgumentNullException(nameof(roomProperties));
            Beds = beds ?? throw new ArgumentNullException(nameof(beds));
        }

        public SingleRoom ()
        {
        }

        /// <summary>
        /// A Hashset which represents the various properties (tv, hairdryer etc. ) a room might have.
        /// </summary>
        public override HashSet<ARoomProperty> RoomProperties { get => _roomProperties; set => _roomProperties = value; }

        public override List<ABed> Beds { get => _beds; set => _beds = value; }

        public override float TotalPrice ()
        {
            float sum = 0f;
            foreach (var item in RoomProperties)
            {
                sum += item.CalculateTotalPrice();
            }
            return BasePrice * (1 + sum);
        }
    }

    [Obsolete("Use the Abstract class ARoom instead")]
    public class Room
    {
        private Guid _roomGuid;

        public Guid RoomGuid
        {
            get { return _roomGuid; }
            init { _roomGuid = value; }
        }

        private protected List<Bedtype> _beds;

        public List<Bedtype> Beds
        {
            get { return _beds; }
            init { _beds = value; }
        }

        public int Capacity
        {
            get
            {
                int counter = 0;
                foreach (Bedtype bed in Beds)
                {
                    switch (bed)
                    {
                        case Bedtype.None:
                            break;

                        case Bedtype.Single:
                            counter++;
                            break;

                        case Bedtype.Double:
                            counter += 2;
                            break;

                        case Bedtype.Kingsize:
                            counter += 3;
                            break;

                        default:
                            break;
                    }
                }
                return counter;
            }
        }

        private byte _floor;

        public Room ()
        {
            RoomGuid = new Guid();
        }

        public Room (List<Bedtype> beds, byte floor)
        {
            RoomGuid = new Guid();
            Beds = beds ?? throw new ArgumentNullException(nameof(beds));
            Floor = floor;
        }

        public byte Floor
        {
            get { return _floor; }
            init
            {
                try
                {
                    _floor = value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // do logging here.
                    throw;
                }
            }
        }
    }

    [Obsolete("Use the Abstract class Abed instead")]
    public enum Bedtype
    {
        None,
        Single,
        Double,
        Kingsize
    }
}