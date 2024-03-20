namespace KiwiLoad.Core.Exceptions.Warehouses;
public class KiwiLoadWarehousesInvalidNameException: KiwiLoadWarehousesException
{
    public KiwiLoadWarehousesInvalidNameException()
        : base("Invalid warehouse name.")
    {
    }
}
