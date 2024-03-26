using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Appi.Controllers;

[ApiController]
[Route("api/warehouses")]
public partial class WarehousesController : ControllerBase
{
    private readonly ILogger<WarehousesController> logger;
    public WarehousesController(ILogger<WarehousesController> logger)
    {
        this.logger=logger;
    }
}