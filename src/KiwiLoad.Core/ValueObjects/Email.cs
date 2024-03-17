using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.ValueObjects;
public class Email : ValueObject
{
    public string Value { get; }
    public Email(string? value)
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

    public static implicit operator string(Email userName)
    {
        return userName.Value;
    }

    public static implicit operator Email(string value)
    {
        return new Email(value);
    }
}