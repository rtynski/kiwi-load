using KiwiLoad.Core.Exceptions.Warehouses;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Warehouses.ValueObjects;
public class WarehouseId : ValueObject
{
    public int Value { get; }

    public WarehouseId(int? value)
    {
        if (value is null or <= 0)
        {
            throw new KiwiLoadWarehousesInvalidIdException(value);
        }
        Value = value.Value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator int(WarehouseId warehouse)
    {
        return warehouse.Value;
    }

    public static implicit operator WarehouseId(int value)
    {
        return new WarehouseId(value);
    }
}
