using Microsoft.EntityFrameworkCore;

namespace KiwiLoad.Infrastructure.Databases;
public class KiwiDbContext : BaseKiwiDbContext
{
    public KiwiDbContext(DbContextOptions<BaseKiwiDbContext> options) : base(options)
    {
    }
}
