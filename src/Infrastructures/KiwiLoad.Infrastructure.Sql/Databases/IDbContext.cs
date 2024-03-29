using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KiwiLoad.Infrastructure.Databases;
public interface IDbContext
{
    DbSet<Entries.User> Users { get; }
    DbSet<Entries.Warehouse> Warehouses { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public DatabaseFacade   Database { get; }
}
