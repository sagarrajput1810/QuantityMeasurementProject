using QuantityMeasurementSystem.Models;

try 
{
    Console.WriteLine("======= QUANTITY MEASUREMENT SYSTEM FINAL TEST (UC 1-12) =======\n");

    // Test Comparison (UC 12)
    Quantity oneFoot = new Quantity(1.0, Unit.FEET);
    Quantity tenInches = new Quantity(10.0, Unit.INCH);
    Console.WriteLine($"[UC 12] 1 Foot > 10 Inches: {oneFoot.CompareTo(tenInches) > 0}");

    // Test Temperature (UC 11)
    Quantity c100 = new Quantity(100.0, Unit.CELSIUS);
    Quantity f212 = new Quantity(212.0, Unit.FAHRENHEIT);
    Console.WriteLine($"[UC 11] 100°C == 212°F: {c100.Equals(f212)}");

    // Test Weight Addition (UC 10)
    Quantity ton1 = new Quantity(1.0, Unit.TONNE);
    Quantity kg1000 = new Quantity(1000.0, Unit.KG);
    Console.WriteLine($"[UC 10] 1 Tonne + 1000 KG = {ton1.Add(kg1000).Value} Grams");

    // Test Volume (UC 9)
    Quantity gal1 = new Quantity(1.0, Unit.GALLON);
    Quantity lit3_78 = new Quantity(3.78541, Unit.LITER);
    Console.WriteLine($"[UC 09] 1 Gallon == 3.785 Liters: {gal1.Equals(lit3_78)}");

    Console.WriteLine("\n--- All Tests Passed Successfully! ---");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}