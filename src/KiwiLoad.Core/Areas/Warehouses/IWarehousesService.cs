using KiwiLoad.Core.Areas.Warehouses.DTO;

namespace KiwiLoad.Core.Areas.Warehouses;
public interface IWarehousesService
{
    Task<WarehouseListDto> GetAll();
}
