using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class HashValue : ValueObject
{
    public string Value { get; }
    public HashValue(string? value)
    {
        if (value is null || string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadAuthHashValueEmptyException();
        }
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(HashValue userName)
    {
        return userName.Value;
    }

    public static implicit operator HashValue(string value)
    {
        return new HashValue(value);
    }
}
