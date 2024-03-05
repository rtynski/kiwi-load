using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Core.Areas.Warehouses.DTO;

namespace KiwiLoad.Infrastructure.Repositories.Warehouses;
internal class WarehouseRepository : IWarehouseRepository
{
    public async Task<IEnumerable<WarehouseDto>> GetAll()
    {
        await Task.Yield();
        return Enumerable.Range(1, 5).Select(index => new WarehouseDto(index)).ToArray();
    }
}
