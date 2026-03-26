using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly MeasurementDbContext _context;

    public AuthRepository(MeasurementDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
