using KiwiLoad.Core.Areas.Stocks.ValueObjects;

namespace KiwiLoad.Core.Areas.Stocks.DTO;
public class StockCreate
{
    public StockCreate(StockName name)
    {
        Name=name;
    }
    public StockName Name { get; }
}
