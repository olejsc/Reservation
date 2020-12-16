using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation
{
    public abstract class ARoomProperty
    {
        private string _name;

        private float _seasonModifier;
        private float _holidayModifier;
        private float _optionalModifier;

        public float SeasonModifier
        {
            get { return _seasonModifier; }
            set { _seasonModifier = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private float _basePrice;

        public ARoomProperty (float seasonModifier, string name, float basePrice, float holidayModifier, float optionalModifier)
        {
            SeasonModifier = seasonModifier;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BasePrice = basePrice;
            HolidayModifier = holidayModifier;
            OptionalModifier = optionalModifier;
        }

        public virtual float BasePrice
        {
            get { return _basePrice; }
            set { _basePrice = value; }
        }

        public virtual float HolidayModifier { get => _holidayModifier; set => _holidayModifier = value; }
        public virtual float OptionalModifier { get => _optionalModifier; set => _optionalModifier = value; }

        public virtual float CalculateTotalPrice ()
        {
            return BasePrice * (1 + SeasonModifier + HolidayModifier + OptionalModifier);
        }

        public virtual new string ToString ()
        {
            return $"{Name} : {CalculateTotalPrice()}$";
        }
    }
}