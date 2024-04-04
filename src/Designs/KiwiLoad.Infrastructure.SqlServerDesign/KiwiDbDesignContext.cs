using KiwiLoad.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KiwiLoad.Infrastructure.SqlServerDesign;

internal class KiwiDbDesignContext : KiwiDbContext
{
    public KiwiDbDesignContext() : base(
        new DbContextOptionsBuilder<KiwiDbContext>()
                .UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionStrings__KiwiLoad"),
                    x => x.MigrationsHistoryTable(Constants.MigrationsHistory, Constants.SchemaName)
                )
                .Options)
    {
    }
    protected override void OnModelCreating([NotNull] ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
