namespace KiwiLoad.Core.Exceptions.Warehouses;
public class KiwiLoadWarehousesInvalidIdException : KiwiLoadWarehousesException
{
    public KiwiLoadWarehousesInvalidIdException(int? warehouseId)
        : base($"Invalid warehouse id: {warehouseId?.ToString() ?? "null"}.")
    {
    }
}
