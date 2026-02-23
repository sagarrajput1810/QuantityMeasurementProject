namespace QuantityMeasurementSystem.Models
{
    public class Unit
    {
        // Category define karne ke liye enum
        public enum UnitType { LENGTH, VOLUME, WEIGHT }

        // --- LENGTH UNITS (Base: INCH) ---
        public static readonly Unit INCH = new Unit(1.0, UnitType.LENGTH);
        public static readonly Unit FEET = new Unit(12.0, UnitType.LENGTH);
        public static readonly Unit YARD = new Unit(36.0, UnitType.LENGTH);
        public static readonly Unit CM = new Unit(1.0 / 2.54, UnitType.LENGTH);

        // --- VOLUME UNITS (Base: LITER) ---
        public static readonly Unit LITER = new Unit(1.0, UnitType.VOLUME);
        public static readonly Unit GALLON = new Unit(3.78541, UnitType.VOLUME);
        public static readonly Unit ML = new Unit(0.001, UnitType.VOLUME);

        public double ConversionFactor { get; }
        public UnitType Type { get; }

        private Unit(double factor, UnitType type)
        {
            ConversionFactor = factor;
            Type = type;
        }

        public double ConvertToBase(double value) => value * ConversionFactor;
    }
}