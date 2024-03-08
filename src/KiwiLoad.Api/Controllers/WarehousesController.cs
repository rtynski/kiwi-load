using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

[ApiController]
[Route("api/warehouses")]
public partial class WarehousesController(ILogger<WarehousesController> logger) : ControllerBase
{
}