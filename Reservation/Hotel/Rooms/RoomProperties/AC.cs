namespace Reservation
{
    public class AC : ARoomProperty
    {
        public AC (
            float seasonModifier,
            string name,
            float basePrice,
            float holidayModifier,
            float optionalModifier) : base(seasonModifier, name, basePrice, holidayModifier, optionalModifier)
        {
        }
    }
}