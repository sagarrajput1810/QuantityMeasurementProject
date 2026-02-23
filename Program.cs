using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Enums;

// Test 1: 1 Yard == 3 Feet
Quantity yard = new Quantity(1.0, Unit.YARD);
Quantity feet = new Quantity(3.0, Unit.FEET);
Console.WriteLine($"Is 1 Yard == 3 Feet? {yard.Equals(feet)}"); // True

// Test 2: 1 Inch == 2.54 CM
Quantity inch = new Quantity(1.0, Unit.INCH);
Quantity cm = new Quantity(2.54, Unit.CM);
Console.WriteLine($"Is 1 Inch == 2.54 CM? {inch.Equals(cm)}");