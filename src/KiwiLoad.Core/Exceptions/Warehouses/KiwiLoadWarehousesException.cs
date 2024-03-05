namespace KiwiLoad.Core.Exceptions.Warehouses;
public abstract class KiwiLoadWarehousesException : KiwiLoadException
{
    protected KiwiLoadWarehousesException(string message) : base(message)
    {
    }
}
