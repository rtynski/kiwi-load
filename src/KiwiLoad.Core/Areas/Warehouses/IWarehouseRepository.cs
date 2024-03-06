using KiwiLoad.Core.Areas.Warehouses.DTO;

namespace KiwiLoad.Core.Areas.Warehouses;
public interface IWarehouseRepository
{
    Task<IEnumerable<WarehouseDto>> GetAll();
    Task<WarehouseDto> Create(WarehouseCreateDto warehouse);
}
