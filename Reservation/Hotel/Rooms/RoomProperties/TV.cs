namespace Reservation
{
    public class TV : ARoomProperty
    {
        public enum channelsAvailable
        {
            local,
            national,
            international
        }

        private channelsAvailable _channels;
        private bool _hasWifi;

        public TV (channelsAvailable channels,
            bool hasWifi,
            float seasonModifier,
            string name,
            float basePrice,
            float holidayModifier,
            float optionalModifier) : base(seasonModifier, name, basePrice, holidayModifier, optionalModifier)
        {
            Channels = channels;
            HasWifi = hasWifi;
        }

        private channelsAvailable Channels { get => _channels; set => _channels = value; }
        public bool HasWifi { get => _hasWifi; set => _hasWifi = value; }

        private float ChannelsModifier => Channels switch
        {
            channelsAvailable.local => 0.1f,
            channelsAvailable.national => 0.25f,
            channelsAvailable.international => 0.5f,
            _ => 0f
        };

        private float WifiModifier => HasWifi switch
        {
            true => 0.5f,
            false => -0.5f
        };

        public override float CalculateTotalPrice ()
        {
            return BasePrice * (1 + SeasonModifier + HolidayModifier + OptionalModifier + WifiModifier + ChannelsModifier);
        }
    }
}