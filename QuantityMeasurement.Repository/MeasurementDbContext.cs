using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Repository;

public class MeasurementDbContext : DbContext
{
    public MeasurementDbContext(DbContextOptions<MeasurementDbContext> options)
        : base(options) { }

    public DbSet<ConversionHistoryEntity> ConversionHistory => Set<ConversionHistoryEntity>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
