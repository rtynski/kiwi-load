using KiwiLoad.Core.Areas.Stocks.DTO;

namespace KiwiLoad.Core.Areas.Stocks;
public interface IStocksService
{
    Task<StockDto?> Create(StockCreate create);
    Task<IEnumerable<StockDto>> GetAll();
}
