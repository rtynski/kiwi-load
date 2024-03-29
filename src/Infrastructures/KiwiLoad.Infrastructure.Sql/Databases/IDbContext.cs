using Microsoft.EntityFrameworkCore;

namespace KiwiLoad.Infrastructure.Databases;
public interface IDbContext
{
    DbSet<Entries.User> Users { get; set; }
    DbSet<Entries.Warehouse> Warehouses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
