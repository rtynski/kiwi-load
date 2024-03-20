using KiwiLoad.Core.Areas.Warehouses.DTO;
using KiwiLoad.Core.Areas.Warehouses.ValueObjects;

namespace KiwiLoad.Core.Areas.Warehouses;
public interface IWarehouseRepository
{
    Task<IEnumerable<WarehouseDto>> GetAll();
    Task<WarehouseDto> Create(WarehouseCreateDto warehouse, int userId);
    Task<WarehouseDto?> GetById(WarehouseId id);
}
