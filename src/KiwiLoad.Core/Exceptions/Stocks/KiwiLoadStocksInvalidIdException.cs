using KiwiLoad.Core.Exceptions.Warehouses;

namespace KiwiLoad.Core.Exceptions.Stocks;
public class KiwiLoadStocksInvalidIdException : KiwiLoadStocksException
{
    public KiwiLoadStocksInvalidIdException(int? stockId)
        : base($"Invalid stock id: {stockId?.ToString() ?? "null"}.")
    {
    }
}
