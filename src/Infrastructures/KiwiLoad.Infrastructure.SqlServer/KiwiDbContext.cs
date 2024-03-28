using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KiwiLoad.Infrastructure.Databases;
public class KiwiDbContext : DbContext
{
    public KiwiDbContext(DbContextOptions<KiwiDbContext> options) : base(options)
    {
    }

    public DbSet<Entries.User> Users { get; set; } = null!;
    public DbSet<Entries.Warehouse> Warehouses { get; set; } = null!;

    protected override void OnModelCreating([NotNull] ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var currentAssembly = GetType().Assembly;
        _ = modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

        modelBuilder.HasDefaultSchema(Constants.SchemaName);
    }
}
