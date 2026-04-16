using System.Collections.Generic;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Repository
{
    public interface IMeasurementRepository
    {
        IEnumerable<Unit> GetAllUnits();
        void SaveConversion(ConversionHistoryEntity entity);
        IEnumerable<ConversionHistoryEntity> GetConversionHistory(int userId);
        void DeleteAllHistory(int userId);
    }
}