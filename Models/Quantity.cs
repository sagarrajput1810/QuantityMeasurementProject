using System;

namespace QuantityMeasurementSystem.Models
{
    public class Quantity : IComparable<Quantity>
    {
        public double Value { get; }
        public Unit Unit { get; }

        public Quantity(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }


        public override string ToString() => $"{Math.Round(Value, 2)} {Unit.Name}";

    
        public override bool Equals(object? obj)
        {
            if (obj is Quantity other)
            {
                if (this.Unit.Type != other.Unit.Type) return false;
                return Math.Abs(this.Unit.ConvertToBase(this.Value) - 
                                other.Unit.ConvertToBase(other.Value)) < 0.1;
            }
            return false;
        }

       
        public int CompareTo(Quantity? other)
        {
            if (other == null) return 1;
            if (this.Unit.Type != other.Unit.Type)
                throw new InvalidOperationException("Different dimensions cannot be compared.");

            double v1 = this.Unit.ConvertToBase(this.Value);
            double v2 = other.Unit.ConvertToBase(other.Value);

            if (Math.Abs(v1 - v2) < 0.001) return 0;
            return v1 > v2 ? 1 : -1;
        }

    
        public Quantity ConvertTo(Unit targetUnit)
        {
            if (this.Unit.Type != targetUnit.Type)
                throw new InvalidOperationException($"Cannot convert {this.Unit.Name} to {targetUnit.Name}");

            double baseValue = this.Unit.ConvertToBase(this.Value);
            double convertedValue = (baseValue / targetUnit.ConversionFactor) + targetUnit.Offset;

            return new Quantity(convertedValue, targetUnit);
        }

   
        public Quantity Add(Quantity other)
        {
            if (this.Unit.Type == Unit.UnitType.TEMPERATURE)
                throw new InvalidOperationException("Adding temperatures is physically incorrect.");

            if (this.Unit.Type != other.Unit.Type)
                throw new InvalidOperationException("Dimension mismatch.");

            double totalInBase = this.Unit.ConvertToBase(this.Value) + other.Unit.ConvertToBase(other.Value);

            Unit resultBase = this.Unit.Type switch {
                Unit.UnitType.LENGTH => Unit.INCH,
                Unit.UnitType.VOLUME => Unit.LITER,
                Unit.UnitType.WEIGHT => Unit.GRAM,
                _ => throw new InvalidOperationException()
            };

            return new Quantity(totalInBase, resultBase);
        }

        public override int GetHashCode() => HashCode.Combine(Value, Unit);
    }
}