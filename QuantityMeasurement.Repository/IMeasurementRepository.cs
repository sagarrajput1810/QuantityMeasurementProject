// File: IMeasurementRepository.cs
using QuantityMeasurementSystem.Models;

namespace QuantityMeasurementSystem.Repository
{
    public interface IMeasurementRepository
    {
        IEnumerable<Unit> GetAllUnits();
    }

    // File: MeasurementRepository.cs
    public class MeasurementRepository : IMeasurementRepository
    {
        public IEnumerable<Unit> GetAllUnits()
        {
            // In a real app, this would come from a Database (SQL)
            return new List<Unit> { Unit.INCH, Unit.FEET, Unit.KG, Unit.CELSIUS, Unit.LITER };
        }
    }
}