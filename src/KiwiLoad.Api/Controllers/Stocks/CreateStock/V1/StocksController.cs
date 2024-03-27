using KiwiLoad.Api.Controllers.Stocks.CreateStock.V1.Models;
using KiwiLoad.Api.Controllers.Stocks.Models;
using KiwiLoad.Core.Areas.Stocks;
using KiwiLoad.Core.Areas.Stocks.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Api.Controllers;

public partial class StocksController
{
    [HttpPost("v1")]
    [Authorize]
    public async Task<ActionResult<StockRes?>> CreateStocksV1(
        [FromServices]
        IStocksService stocksService,
        [FromBody]
        StockCreateReq stockReq
    )
    {
        logger.LogInformation("{HttpMethod} {ActionName}", "GET", nameof(GetStocksV1));
        var create = new StockCreate(stockReq.Name);
        var stock = await stocksService.Create(create);
        if (stock is null)
        {
            return NotFound();
        }
        var res = new StockRes(stock.Id, stock.Name);
        return Ok(res);
    }
}
