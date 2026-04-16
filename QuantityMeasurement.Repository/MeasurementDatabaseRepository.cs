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

        public IEnumerable<ConversionHistoryEntity> GetConversionHistory(int userId)
        {
            return _context.ConversionHistory
                           .Where(h => h.UserId == userId)
                           .OrderByDescending(h => h.CreatedAt)
                           .ToList();
        }

        public void DeleteAllHistory(int userId)
        {
            var userHistory = _context.ConversionHistory.Where(h => h.UserId == userId);
            _context.ConversionHistory.RemoveRange(userHistory);
            _context.SaveChanges();
        }
    }
}