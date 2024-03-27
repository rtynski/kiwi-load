using KiwiLoad.Api.Controllers.Stocks.Models;
using KiwiLoad.Core.Areas.Stocks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLoad.Api.Controllers;

public partial class StocksController
{
    [HttpGet("v1")]
    [Authorize]
    public async Task<IEnumerable<StockRes>> GetStocksV1([FromServices] IStocksService stocksService)
    {
        logger.LogInformation("{HttpMethod} {ActionName}", "GET", nameof(GetStocksV1));
        var stocks = await stocksService.GetAll();
        return stocks.Select(x => new StockRes(x.Id, x.Name));
    }
}
