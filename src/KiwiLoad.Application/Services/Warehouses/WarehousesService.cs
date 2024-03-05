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

    public async Task<WarehouseListDto> GetAll()
    {
        var warehouses = await warehouseRepository.GetAll();
        return new WarehouseListDto(warehouses);
    }
}
