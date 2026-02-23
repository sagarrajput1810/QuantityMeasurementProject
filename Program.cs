using QuantityMeasurementSystem.Models;

try 
{
    Console.WriteLine("=== QUANTITY MEASUREMENT SYSTEM: FINAL SHOWCASE ===\n");

    // Displaying Objects (UC 13)
    Quantity q1 = new Quantity(1.0, Unit.FEET);
    Quantity q2 = new Quantity(12.0, Unit.INCH);
    Console.WriteLine($"Comparing: {q1} and {q2}");
    Console.WriteLine($"Are they equal? {q1.Equals(q2)}");

    // Comparison (UC 12)
    Quantity heavy = new Quantity(1.0, Unit.TONNE);
    Quantity light = new Quantity(500.0, Unit.KG);
    Console.WriteLine($"\nIs {heavy} > {light}? {heavy.CompareTo(light) > 0}");

    // Temperature (UC 11)
    Quantity bodyTempF = new Quantity(98.6, Unit.FAHRENHEIT);
    Quantity bodyTempC = new Quantity(37.0, Unit.CELSIUS);
    Console.WriteLine($"\nBody Temp: {bodyTempF} is equal to {bodyTempC}: {bodyTempF.Equals(bodyTempC)}");

    // Addition (UC 10)
    Quantity milk = new Quantity(1.0, Unit.LITER);
    Quantity extraMilk = new Quantity(500.0, Unit.ML);
    Console.WriteLine($"\nTotal Milk: {milk.Add(extraMilk)}");

    Console.WriteLine("\n--- Project Status: COMPLETED (UC 1-13) ---");
}
catch (Exception ex)
{
    Console.WriteLine($"\nAlert: {ex.Message}");
}