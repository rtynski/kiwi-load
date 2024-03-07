using KiwiLoad.Core.Areas.Warehouses.DTO;
using KiwiLoad.Core.Areas.Warehouses.ValueObjects;

namespace KiwiLoad.Core.Areas.Warehouses;
public interface IWarehousesService
{
    Task<WarehouseDto> Create(WarehouseCreateDto warehouse);
    Task<WarehouseListDto> GetAll();
    Task<WarehouseDto?> GetById(WarehouseId id);
}
