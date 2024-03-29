using Microsoft.EntityFrameworkCore;

namespace KiwiLoad.Infrastructure.Databases;
public class KiwiDbContext : BaseKiwiDbContext
{
    public KiwiDbContext(DbContextOptions<KiwiDbContext> options) : base(options)
    {
    }
}
