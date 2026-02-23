using QuantityMeasurementSystem.Enums;

namespace QuantityMeasurementSystem.Models
{
    public class Quantity
    {
        public double Value { get; }
        public Unit Unit { get; } // Nayi property

        public Quantity(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Quantity other)
            {
                // Simple comparison ab kaam nahi karega
                // Hume dono ko ek common base (Inches) mein convert karna hoga
                double value1 = ConvertToBase(this);
                double value2 = ConvertToBase(other);

                return value1 == value2;
            }
            return false;
        }

        // Ye helper method hai jo units ko Inches mein badlega
        private double ConvertToBase(Quantity q)
        {
            if (q.Unit == Unit.FEET)
            {
                return q.Value * 12.0; // 1 Foot = 12 Inches
            }
            return q.Value; // Agar pehle se inch hai toh wahi rehne do
        }
    }
}