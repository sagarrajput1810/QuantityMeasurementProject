using System;

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
                // Validation: Category same honi chahiye (Length vs Length)
                if (this.Unit.Type != other.Unit.Type) return false;

                double v1 = this.Unit.ConvertToBase(this.Value);
                double v2 = other.Unit.ConvertToBase(other.Value);
                return Math.Abs(v1 - v2) < 0.001;
            }
            return false;
        }

        public Quantity Add(Quantity other)
        {
            // Security Check: Training mein ye bahut zaroori hai
            if (this.Unit.Type != other.Unit.Type)
            {
                throw new InvalidOperationException("Cannot add different dimensions (e.g. Length and Volume)");
            }

            double v1 = this.Unit.ConvertToBase(this.Value);
            double v2 = other.Unit.ConvertToBase(other.Value);
            
            // Result hamesha base unit mein return hota hai
            return new Quantity(v1 + v2, this.Unit.Type == Unit.UnitType.LENGTH ? Unit.INCH : Unit.LITER);
        }

        public override int GetHashCode() => HashCode.Combine(Value, Unit);
    }
}