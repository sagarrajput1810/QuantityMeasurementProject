using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuantityMeasurementSystem.Models;

namespace QuantityMeasurementSystem.Repository
{
    public class MeasurementDatabaseRepository : IMeasurementRepository
    {
        // Update this connection string to match your local SQL Server instance
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=QuantityMeasurementDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public IEnumerable<Unit> GetAllUnits()
        {
            return new List<Unit> { Unit.INCH, Unit.FEET, Unit.KG, Unit.CELSIUS, Unit.LITER };
        }

        public void SaveConversion(ConversionHistoryEntity entity)
        {
            const string query = @"
                INSERT INTO ConversionHistory 
                (InputValue, FromUnit, ConvertedValue, ToUnit, CreatedAt) 
                VALUES (@InputVal, @FromU, @ConvertedVal, @ToU, @CreatedAt)";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InputVal", entity.InputValue);
                    command.Parameters.AddWithValue("@FromU", entity.FromUnit);
                    command.Parameters.AddWithValue("@ConvertedVal", entity.ConvertedValue);
                    command.Parameters.AddWithValue("@ToU", entity.ToUnit);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database Error (Save): {ex.Message}");
                throw; 
            }
        }

        public IEnumerable<ConversionHistoryEntity> GetConversionHistory()
        {
            var history = new List<ConversionHistoryEntity>();
            const string query = "SELECT * FROM ConversionHistory ORDER BY CreatedAt DESC";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            history.Add(new ConversionHistoryEntity
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                InputValue = Convert.ToDouble(reader["InputValue"]),
                                FromUnit = reader["FromUnit"].ToString(),
                                ConvertedValue = Convert.ToDouble(reader["ConvertedValue"]),
                                ToUnit = reader["ToUnit"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database Error (Read): {ex.Message}");
                throw;
            }

            return history;
        }
    }
}