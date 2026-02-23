using QuantityMeasurementSystem.Models;

try 
{
    Console.WriteLine("=== QUANTITY MEASUREMENT SYSTEM (UC 1-10) ===\n");

    // UC 1-8: Length Test
    Quantity yard = new Quantity(1.0, Unit.YARD);
    Quantity feet = new Quantity(3.0, Unit.FEET);
    Console.WriteLine($"[Length] 1 Yard == 3 Feet: {yard.Equals(feet)}");

    // UC 9: Volume Test
    Quantity gallon = new Quantity(1.0, Unit.GALLON);
    Quantity liters = new Quantity(3.78541, Unit.LITER);
    Console.WriteLine($"[Volume] 1 Gallon == 3.785 Liters: {gallon.Equals(liters)}");

    // UC 10: Weight Test
    Quantity kg = new Quantity(1.0, Unit.KG);
    Quantity grams = new Quantity(1000.0, Unit.GRAM);
    Quantity totalWeight = kg.Add(grams);
    Console.WriteLine($"[Weight] 1 KG + 1000 Grams = {totalWeight.Value} {totalWeight.Unit.Type} Base Units (Grams)");

    Console.WriteLine("\n--- Security Test ---");
    // This should fail gracefully
    kg.Add(yard);
}
catch (Exception ex)
{
    Console.WriteLine($"Blocked Invalid Operation: {ex.Message}");
}