using QuantityMeasurementSystem.Models;

try 
{
    Console.WriteLine("=== QUANTITY MEASUREMENT SYSTEM (UC 1-11) ===");

    // UC 11: Temperature Test
    Quantity boilingF = new Quantity(212.0, Unit.FAHRENHEIT);
    Quantity boilingC = new Quantity(100.0, Unit.CELSIUS);
    Console.WriteLine($"[Temp] Is 212°F == 100°C? {boilingF.Equals(boilingC)}");

    Quantity freezingF = new Quantity(32.0, Unit.FAHRENHEIT);
    Quantity freezingC = new Quantity(0.0, Unit.CELSIUS);
    Console.WriteLine($"[Temp] Is 32°F == 0°C? {freezingF.Equals(freezingC)}");

    // UC 10: Weight Test
    Quantity kg = new Quantity(1.0, Unit.KG);
    Quantity grams = new Quantity(1000.0, Unit.GRAM);
    Console.WriteLine($"[Weight] Is 1 KG == 1000 Grams? {kg.Equals(grams)}");

    // Invalid Addition Test
    Console.WriteLine("\n[Security] Trying to add Celsius...");
    boilingC.Add(freezingC);
}
catch (Exception ex)
{
    Console.WriteLine($"Expected Restriction: {ex.Message}");
}