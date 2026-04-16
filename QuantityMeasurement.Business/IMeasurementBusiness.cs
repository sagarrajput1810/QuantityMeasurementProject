using System.Collections.Generic;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Business
{
    public interface IMeasurementBusiness
    {
        Quantity Convert(double value, Unit fromUnit, Unit toUnit, int userId);
        IEnumerable<ConversionHistoryEntity> GetHistory(int userId);
        bool Compare(double val1, Unit unit1, double val2, Unit unit2, int userId);
        Quantity PerformOperation(double val1, Unit unit1, double val2, Unit? unit2, string operation, int userId);
        void DeleteHistory(int userId);
    }
}