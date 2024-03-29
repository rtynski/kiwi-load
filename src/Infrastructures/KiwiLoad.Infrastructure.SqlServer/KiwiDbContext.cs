using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KiwiLoad.Infrastructure.Databases;
public class KiwiDbContext : BaseKiwiDbContext
{
    public KiwiDbContext(DbContextOptions<KiwiDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating([NotNull] ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Constants.SchemaName);
    }
}
