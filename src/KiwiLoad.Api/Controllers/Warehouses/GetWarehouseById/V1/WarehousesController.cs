using KiwiLoad.Api.Controllers.Warehouses.Models;
using KiwiLoad.Core.Areas.Warehouses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class WarehousesController
{
    [HttpGet("v1/{id}")]
    [Authorize]
    public async Task<ActionResult<WarehouseRes>> GetWarehouseByIdV1(
        [FromServices]
        IWarehousesService warehousesService,
        [FromRoute]
        int id
    )
    {
        logger.LogInformation("{HttpMethod} {ActionName}","GET", nameof(GetWarehouseByIdV1));
        var warehouse = await warehousesService.GetById(id);
        if(warehouse is null)
        {
            return NotFound();
        }
        return Ok(new WarehouseRes(warehouse.Id));
    }
}
