using QuantityMeasurementSystem.Enums;

namespace QuantityMeasurementSystem.Models
{
    public class Quantity
    {
        public double Value { get; }
        public Unit Unit { get; }

        public Quantity(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quantity other)
            {
                double value1 = GetValueInInches(this);
                double value2 = GetValueInInches(other);

                // IMPORTANT: == ki jagah ye use karo
                // Dono ke beech ka difference 0.001 se kam hona chahiye
                return Math.Abs(value1 - value2) < 0.001;
            }
            return false;
        }

        public double ConvertTo(Unit targetUnit)
        {
            // Step 1: Pehle apni value ko Inches (Base) mein le aao
            double valueInInches = GetValueInInches(this);

            // Step 2: Ab use target unit mein badlo
            switch (targetUnit)
            {
                case Unit.FEET: return valueInInches / 12.0;
                case Unit.YARD: return valueInInches / 36.0;
                case Unit.CM: return valueInInches * 2.54; // 1 Inch = 2.54 CM
                case Unit.INCH: return valueInInches;
                default: return valueInInches;
            }
        }

        private double GetValueInInches(Quantity q)
        {
            switch (q.Unit)
            {
                case Unit.FEET: return q.Value * 12.0;
                case Unit.YARD: return q.Value * 36.0;
                case Unit.CM: return q.Value / 2.54; // 1 Inch mein 2.54 CM hote hain
                default: return q.Value;
            }
        }

        public Quantity Add(Quantity other)
        {
            // Dono ko pehle Inches mein badlo
            double v1 = GetValueInInches(this);
            double v2 = GetValueInInches(other);

            // Add karo aur result Inches mein hi return karo
            return new Quantity(v1 + v2, Unit.INCH);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Unit);
        }
    }
}