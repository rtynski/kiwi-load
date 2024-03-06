using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Core.Areas.Warehouses.DTO;

namespace KiwiLoad.Application.Services.Warehouses;
internal class WarehousesService : IWarehousesService
{
    private readonly IWarehouseRepository warehouseRepository;

    public WarehousesService(IWarehouseRepository warehouseRepository)
    {
        this.warehouseRepository=warehouseRepository;
    }

    public async Task<WarehouseDto> Create(WarehouseCreateDto warehouse)
    {
        var newWarehouse = await warehouseRepository.Create(warehouse);
        return new WarehouseDto(newWarehouse.Id);
    }

    public async Task<WarehouseListDto> GetAll()
    {
        var warehouses = await warehouseRepository.GetAll();
        return new WarehouseListDto(warehouses);
    }
}
