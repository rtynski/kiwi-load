using KiwiLoad.Api.Controllers.Warehouses.GetWarehouses.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

public partial class WarehousesController
{
    [HttpGet("v1")]
    public IEnumerable<WarehouseRes> GetWarehousesV1()
    {
        logger.LogInformation("{HttpMethod} {ActionName}","GET", nameof(GetWarehousesV1));
        return Enumerable.Range(1, 5).Select(index => new WarehouseRes(index)).ToArray();
    }
}
