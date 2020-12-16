using System.Collections.Generic;

namespace Reservation
{
    public struct RoomPreference
    {
        private List<ABed> _beds;

        private byte _floor;

        public byte Floor
        {
            get { return _floor; }
            set { _floor = value; }
        }

        public List<ABed> Beds
        {
            get
            {
                return _beds;
            }
            init { _beds = value; }
        }

        private float _price;

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Capacity
        {
            get
            {
                int counter = 0;
                foreach (ABed bed in Beds)
                {
                    switch (bed)
                    {
                        case Kingsize ks:
                            counter += ks.AdultCapacity;
                            break;

                        case Standard st:
                            counter += st.AdultCapacity;
                            break;

                        default:
                            break;
                    }
                }
                return counter;
            }
        }
    }
}