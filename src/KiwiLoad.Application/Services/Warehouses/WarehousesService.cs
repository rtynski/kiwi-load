using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Core.Areas.Warehouses.DTO;
using KiwiLoad.Core.Areas.Warehouses.ValueObjects;

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
        var newWarehouse = await warehouseRepository.Create(warehouse, 1);
        return newWarehouse;
    }

    public async Task<WarehouseListDto> GetAll()
    {
        var warehouses = await warehouseRepository.GetAll();
        return new WarehouseListDto(warehouses);
    }

    public async Task<WarehouseDto?> GetById(WarehouseId id)
    {
        if(id > 10)
        {
            return null;
        }
        var warehouse = await warehouseRepository.GetById(id);
        return warehouse;
    }
}
