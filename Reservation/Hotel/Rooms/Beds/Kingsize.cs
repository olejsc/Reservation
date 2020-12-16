using System.Linq;

namespace Reservation
{
    public class Kingsize : ABed
    {
        private string _name;
        private int _adultCapacity;
        private bool _supportHandicap;
        private float _basePrice;

        public override string Name { get => _name; }
        public override int AdultCapacity { get => _adultCapacity; init => _adultCapacity = value; }
        public override bool SupportHandicap { get => _supportHandicap; init => _supportHandicap = value; }
        public override float BasePrice { get => _basePrice; init => _basePrice = value; }

        public override bool CanMergeWithOtherBed ()
        {
            return false;
        }

        public override float CompositePrice (ABed otherBed)
        {
            if (!CanMergeWithOtherBed())
            {
                return BasePrice;
            }
            else
            {
                return BasePrice + otherBed.BasePrice;
            }
        }

        public override ABed Merge (ABed bedToMerge)
        {
            throw new System.NotImplementedException();
        }

        public override float TotalPrice (float[] modifiers)
        {
            return BasePrice * (1 + modifiers.Sum());
        }
    }
}