// QuantityMeasurement.Repository/MeasurementDbContext.cs
using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Repository
{
    public class MeasurementDbContext : DbContext
    {
        public MeasurementDbContext(DbContextOptions<MeasurementDbContext> options) 
            : base(options) { }

        public DbSet<ConversionHistoryEntity> ConversionHistory { get; set; }
    }
}