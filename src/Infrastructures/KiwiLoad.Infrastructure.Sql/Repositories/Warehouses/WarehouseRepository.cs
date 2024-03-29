using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Core.Areas.Warehouses.DTO;
using KiwiLoad.Core.Areas.Warehouses.ValueObjects;
using KiwiLoad.Infrastructure.Databases;
using KiwiLoad.Infrastructure.Databases.Entries;
using KiwiLoad.Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KiwiLoad.Infrastructure.Repositories.Warehouses;
internal class WarehouseRepository : IWarehouseRepository
{
    private readonly ILogger<UsersRepository> logger;
    private readonly IDbContext dbContext;

    public WarehouseRepository(ILogger<UsersRepository> logger, IDbContext dbContext)
    {
        this.logger=logger;
        this.dbContext=dbContext;
    }
    public async Task<WarehouseDto> Create(WarehouseCreateDto warehouse, int userId)
    {
        var dateAdd = DateTime.UtcNow;
        var record = new Warehouse()
        {
            Name = warehouse.Name,
            AddUserId = userId,
            AddDate = dateAdd,
            UpdateUserId = userId,
            UpdateDate = dateAdd
        };
        dbContext.Warehouses.Add(record);
        var recordAdded = await dbContext.SaveChangesAsync();
        logger.LogInformation("Warehouse added: {WarehouseName}. By {UserId}. Records {Records}", record.Name, userId, recordAdded);
        return new WarehouseDto(record.Id, record.Name);
    }

    public async Task<IEnumerable<WarehouseDto>> GetAll()
    {
        var results = await dbContext
                .Warehouses
                .Where(x => x.DisableUserId == null)
                .Select(x => new WarehouseDto(x.Id, x.Name))
                .ToListAsync();
        return results;
    }

    public async Task<WarehouseDto?> GetById(WarehouseId id)
    {
        int warehouseId = id;
        var results = await dbContext
                .Warehouses
                .Where(x => x.DisableUserId == null)
                .Where(x => x.Id == warehouseId)
                .Select(x => new WarehouseDto(x.Id, x.Name))
                .ToListAsync();
        return results.FirstOrDefault(x => x.Id == id);
    }
}
