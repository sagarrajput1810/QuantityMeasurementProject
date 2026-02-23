using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Enums;

Console.WriteLine("--- UC 7: Cross-Unit Addition Test ---");

// Case 1: 1 Foot + 2 Inches = 14 Inches
Quantity foot = new Quantity(1.0, Unit.FEET);
Quantity inch2 = new Quantity(2.0, Unit.INCH);
Quantity result1 = foot.Add(inch2);
Console.WriteLine($"1 Foot + 2 Inches = {result1.Value} Inches (Expected: 14)");

// Case 2: 1 Foot + 1 Foot = 24 Inches
Quantity foot1 = new Quantity(1.0, Unit.FEET);
Quantity foot2 = new Quantity(1.0, Unit.FEET);
Quantity result2 = foot1.Add(foot2);
Console.WriteLine($"1 Foot + 1 Foot = {result2.Value} Inches (Expected: 24)");

// Case 3: 2 Inches + 2.54 CM = 3 Inches
Quantity inch = new Quantity(2.0, Unit.INCH);
Quantity cm = new Quantity(2.54, Unit.CM);
Quantity result3 = inch.Add(cm);
Console.WriteLine($"2 Inches + 2.54 CM = {result3.Value} Inches (Expected: 3)");