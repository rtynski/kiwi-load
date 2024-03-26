
namespace KiwiLoad.Core.Areas.Stocks;
public interface IStocksService
{
    Task<StockDto> GetAll();
}
