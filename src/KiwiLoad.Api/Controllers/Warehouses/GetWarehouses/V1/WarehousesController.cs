using KiwiLoad.Api.Controllers.Warehouses.Models;
using KiwiLoad.Core.Areas.Warehouses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class WarehousesController
{
    [HttpGet("v1")]
    [Authorize]
    public async Task<IEnumerable<WarehouseRes>> GetWarehousesV1([FromServices] IWarehousesService warehousesService)
    {
        logger.LogInformation("{HttpMethod} {ActionName}","GET", nameof(GetWarehousesV1));
        var warehouses = await warehousesService.GetAll();
        return warehouses.Items.Select(x => new WarehouseRes(x.Id));
    }
}
