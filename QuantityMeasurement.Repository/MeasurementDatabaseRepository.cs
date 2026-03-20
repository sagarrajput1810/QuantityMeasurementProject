// QuantityMeasurement.Repository/MeasurementDatabaseRepository.cs
using System.Collections.Generic;
using System.Linq;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Repository
{
    public class MeasurementDatabaseRepository : IMeasurementRepository
    {
        private readonly MeasurementDbContext _context;

        public MeasurementDatabaseRepository(MeasurementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return new List<Unit> { Unit.INCH, Unit.FEET, Unit.KG, Unit.CELSIUS, Unit.LITER };
        }

        public void SaveConversion(ConversionHistoryEntity entity)
        {
            _context.ConversionHistory.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<ConversionHistoryEntity> GetConversionHistory()
        {
            return _context.ConversionHistory
                           .OrderByDescending(h => h.CreatedAt)
                           .ToList();
        }
    }
}