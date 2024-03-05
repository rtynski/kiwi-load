using KiwiLoad.Core.Exceptions.Warehouses;

namespace KiwiLoad.Core.Areas.Warehouses.ValueObjects;
public class WarehouseId
{
    public int Value { get; }

    private WarehouseId()
    {
    }

    public WarehouseId(int value)
    {
        if (value < 0)
        {
            throw new KiwiLoadWarehousesInvalidIdException(value);
        }

        Value = value;
    }

    public static implicit operator int(WarehouseId licencePlate)
        => licencePlate.Value;

    public static implicit operator WarehouseId(int value)
        => new(value);
}
