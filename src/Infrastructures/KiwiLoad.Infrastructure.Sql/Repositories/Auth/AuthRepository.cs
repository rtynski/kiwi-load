using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.ValueObjects;
using KiwiLoad.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace KiwiLoad.Infrastructure.Repositories.Auth;
internal class AuthRepository : IAuthRepository
{
    private readonly IDbContext dbContext;

    public AuthRepository(IDbContext dbContext)
    {
        this.dbContext=dbContext;
    }
    public async Task<HashValue> Authenticate(Username username)
    {
        var userNameDb = (string)username;
        var user = await dbContext
            .Users
            .Where(x => x.Username == userNameDb)
            .Select(x => new { x.PasswordHash })
            .ToListAsync();
        var passwordHash = user.FirstOrDefault()?.PasswordHash ?? string.Empty;
        return new HashValue(passwordHash);
    }
}
