using KiwiLoad.Core.Exceptions.Stocks;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Stocks.ValueObjects;
public class StockName : ValueObject
{
    public string Value { get; }

    public StockName(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadStockInvalidNameException();
        }

        Value = value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(StockName userName)
    {
        return userName.Value;
    }

    public static implicit operator StockName(string value)
    {
        return new StockName(value);
    }
}
