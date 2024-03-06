using KiwiLoad.Api.Controllers.Warehouses.Models;
using KiwiLoad.Core.Areas.Warehouses;
using KiwiLoad.Core.Areas.Warehouses.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class WarehousesController
{
    [HttpPost("v1")]
    [Authorize]
    public async Task<WarehouseRes> CreateWarehousesV1([FromServices] IWarehousesService warehousesService, [FromBody] WarehouseReq warehouse)
    {
        logger.LogInformation("{HttpMethod} {ActionName}","POST", nameof(CreateWarehousesV1));
        var warehouseResult = await warehousesService
            .Create(MapTo(warehouse));
        return new WarehouseRes(warehouseResult.Id);
    }

    private WarehouseCreateDto MapTo(WarehouseReq warehouse)
    {
        return new WarehouseCreateDto(warehouse.Name);
    }
}
