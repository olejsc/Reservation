namespace Reservation
{
    public class Fridge : ARoomProperty
    {
        public Fridge (
            float seasonModifier,
            string name,
            float basePrice,
            float holidayModifier,
            float optionalModifier) : base(seasonModifier, name, basePrice, holidayModifier, optionalModifier)
        {
        }
    }
}