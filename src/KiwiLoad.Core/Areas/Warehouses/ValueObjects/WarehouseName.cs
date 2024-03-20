using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Exceptions.Warehouses;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Warehouses.ValueObjects;
public class WarehouseName : ValueObject
{
    public string Value { get; }

    public WarehouseName(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadWarehousesInvalidNameException();
        }

        Value = value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(WarehouseName userName)
    {
        return userName.Value;
    }

    public static implicit operator WarehouseName(string value)
    {
        return new WarehouseName(value);
    }
}
