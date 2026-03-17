using System.Collections.Generic;
using QuantityMeasurementSystem.Models;

namespace QuantityMeasurementSystem.Repository
{
    public interface IMeasurementRepository
    {
        IEnumerable<Unit> GetAllUnits();
        void SaveConversion(ConversionHistoryEntity entity);
        IEnumerable<ConversionHistoryEntity> GetConversionHistory();
    }
}