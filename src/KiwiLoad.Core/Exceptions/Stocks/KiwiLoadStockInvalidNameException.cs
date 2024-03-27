using KiwiLoad.Core.Exceptions.Warehouses;

namespace KiwiLoad.Core.Exceptions.Stocks;
internal class KiwiLoadStockInvalidNameException : KiwiLoadWarehousesException
{
    public KiwiLoadStockInvalidNameException()
        : base("Invalid Stock name.")
    {
    }
}

