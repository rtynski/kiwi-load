using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KiwiLoad.Infrastructure.Databases;
public class BaseKiwiDbContext : DbContext, IDbContext
{
    public BaseKiwiDbContext(DbContextOptions options) : base(options)
    {
    }

    public required DbSet<Entries.User> Users { get; set; }
    public required DbSet<Entries.Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating([NotNull] ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var currentAssembly = GetType().Assembly;
        _ = modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
    }
}