namespace QuantityMeasurementSystem.Models
{
    public class Unit
    {
        public enum UnitType { LENGTH, VOLUME, WEIGHT, TEMPERATURE }

        // --- LENGTH (Base: INCH) ---
        public static readonly Unit INCH = new Unit(1.0, UnitType.LENGTH);
        public static readonly Unit FEET = new Unit(12.0, UnitType.LENGTH);
        public static readonly Unit YARD = new Unit(36.0, UnitType.LENGTH);
        public static readonly Unit CM = new Unit(1.0 / 2.54, UnitType.LENGTH);

        // --- VOLUME (Base: LITER) ---
        public static readonly Unit LITER = new Unit(1.0, UnitType.VOLUME);
        public static readonly Unit GALLON = new Unit(3.78541, UnitType.VOLUME);
        public static readonly Unit ML = new Unit(0.001, UnitType.VOLUME);

        // --- WEIGHT (Base: GRAM) ---
        public static readonly Unit GRAM = new Unit(1.0, UnitType.WEIGHT);
        public static readonly Unit KG = new Unit(1000.0, UnitType.WEIGHT);
        public static readonly Unit TONNE = new Unit(1000000.0, UnitType.WEIGHT);

        // --- TEMPERATURE (Base: CELSIUS) ---
        // Formula: (Value - Offset) * Factor
        // Fahrenheit ke liye: (F - 32) * 5/9 = Celsius
        public static readonly Unit CELSIUS = new Unit(1.0, UnitType.TEMPERATURE, 0);
        public static readonly Unit FAHRENHEIT = new Unit(5.0 / 9.0, UnitType.TEMPERATURE, 32);

        public double ConversionFactor { get; }
        public double Offset { get; }
        public UnitType Type { get; }

        private Unit(double factor, UnitType type, double offset = 0)
        {
            ConversionFactor = factor;
            Type = type;
            Offset = offset;
        }

        // Logic updated for Temperature formulas
        public double ConvertToBase(double value)
        {
            return (value - Offset) * ConversionFactor;
        }
    }
}