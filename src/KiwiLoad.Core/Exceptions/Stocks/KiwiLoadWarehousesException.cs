namespace KiwiLoad.Core.Exceptions.Warehouses;
public abstract class KiwiLoadStocksException : KiwiLoadException
{
    protected KiwiLoadStocksException(string message) : base(message)
    {
    }
}
