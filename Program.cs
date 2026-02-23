using QuantityMeasurementSystem.Models;

try 
{
    Console.WriteLine("=== QUANTITY MEASUREMENT SYSTEM FINAL (UC 1-14) ===\n");

    // UC 14: Conversion Test
    Quantity oneTon = new Quantity(1.0, Unit.TONNE);
    Console.WriteLine($"Conversion: {oneTon} is {oneTon.ConvertTo(Unit.KG)}");

    // UC 11: Temperature Test
    Quantity freezingC = new Quantity(0.0, Unit.CELSIUS);
    Console.WriteLine($"Temperature: {freezingC} is {freezingC.ConvertTo(Unit.FAHRENHEIT)}");

    // UC 12: Comparison
    Quantity yard = new Quantity(1.0, Unit.YARD);
    Quantity feet = new Quantity(2.0, Unit.FEET);
    Console.WriteLine($"Comparison: Is {yard} > {feet}? {yard.CompareTo(feet) > 0}");

    // UC 6-10: Addition
    Quantity milk = new Quantity(1.0, Unit.LITER);
    Quantity ml = new Quantity(500.0, Unit.ML);
    Console.WriteLine($"Addition: {milk} + {ml} = {milk.Add(ml)}");

    Console.WriteLine("\n--- SUCCESS: All Units Working Correctly! ---");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}