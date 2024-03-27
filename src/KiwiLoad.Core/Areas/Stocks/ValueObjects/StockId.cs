using KiwiLoad.Core.Exceptions.Stocks;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Stocks.ValueObjects;
public class StockId : ValueObject
{
    public int Value { get; }

    public StockId(int? value)
    {
        if (value is null or <= 0)
        {
            throw new KiwiLoadStocksInvalidIdException(value);
        }
        Value = value.Value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator int(StockId warehouse)
    {
        return warehouse.Value;
    }

    public static implicit operator StockId(int value)
    {
        return new StockId(value);
    }
}
