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
                // Ab Unit khud apna conversion handle kar raha hai
                double v1 = this.Unit.ConvertToBase(this.Value);
                double v2 = other.Unit.ConvertToBase(other.Value);
                return Math.Abs(v1 - v2) < 0.001;
            }
            return false;
        }

        public Quantity Add(Quantity other)
        {
            double v1 = this.Unit.ConvertToBase(this.Value);
            double v2 = other.Unit.ConvertToBase(other.Value);
            return new Quantity(v1 + v2, Unit.INCH);
        }
        
        // ConvertTo bhi ab simple ho gaya
        public double ConvertTo(Unit targetUnit)
        {
             double valueInBase = this.Unit.ConvertToBase(this.Value);
             return valueInBase / targetUnit.ConversionFactor;
        }
    }
}