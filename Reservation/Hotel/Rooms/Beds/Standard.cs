using System;

namespace Reservation
{
    public class Standard : ABed
    {
        private string _name = "Standard";
        private int _adultCapacity;
        private bool _supportHandicap;
        private float _basePrice;

        public Standard (int adultCapacity, bool supportHandicap, float basePrice)
        {
            AdultCapacity = adultCapacity;
            SupportHandicap = supportHandicap;
            BasePrice = basePrice;
        }

        public override string Name { get => _name; }
        public override int AdultCapacity { get => _adultCapacity; init => _adultCapacity = value; }
        public override bool SupportHandicap { get => _supportHandicap; init => _supportHandicap = value; }
        public override float BasePrice { get => _basePrice; init => _basePrice = value; }

        public override bool CanMergeWithOtherBed ()
        {
            return true;
        }

        public override float CompositePrice (ABed otherBed)
        {
            return this.BasePrice + otherBed.BasePrice;
        }

        public override ABed Merge (ABed bedToMerge)
        {
            throw new System.NotImplementedException();
        }

        public override float TotalPrice (float[] modifiers)
        {
            throw new System.NotImplementedException();
        }
    }
}