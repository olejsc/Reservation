namespace Reservation
{
    public class HairDryer : ARoomProperty
    {
        public HairDryer (
            float seasonModifier,
            string name,
            float basePrice,
            float holidayModifier,
            float optionalModifier) : base(seasonModifier, name, basePrice, holidayModifier, optionalModifier)
        {
        }
    }
}