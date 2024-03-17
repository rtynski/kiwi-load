using KiwiLoad.Core.Exceptions.Users;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Users.ValueObjects;
public class UserId : ValueObject
{
    public int Value { get; }

    public UserId(int? value)
    {
        if (value is null or <= 0)
        {
            throw new KiwiLoadUserInvalidIdException(value);
        }
        Value = value.Value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator int(UserId warehouse)
    {
        return warehouse.Value;
    }

    public static implicit operator UserId(int value)
    {
        return new UserId(value);
    }
}