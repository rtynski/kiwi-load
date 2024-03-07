using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Core.Areas.Warehouses.DTO;
using KiwiLoad.Core.Areas.Warehouses.ValueObjects;

namespace KiwiLoad.Infrastructure.Repositories.Warehouses;
internal class WarehouseRepository : IWarehouseRepository
{
    public async Task<WarehouseDto> Create(WarehouseCreateDto warehouse)
    {
        await Task.Yield();
        return new WarehouseDto(6);
    }

    public async Task<IEnumerable<WarehouseDto>> GetAll()
    {
        await Task.Yield();
        return Enumerable.Range(1, 5).Select(index => new WarehouseDto(index)).ToArray();
    }

    public async Task<WarehouseDto?> GetById(WarehouseId id)
    {
        await Task.Yield();
        int idValue = id;
        return new WarehouseDto(idValue);
    }
}
