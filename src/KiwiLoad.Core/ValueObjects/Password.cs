using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.ValueObjects;
public class Password : ValueObject
{
    public string Value { get; }

    public Password(string? value)
    {
        if (value is null || string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadAuthPasswordEmptyException();
        }

        Value = value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(Password userName)
    {
        return userName.Value;
    }

    public static implicit operator Password(string value)
    {
        return new Password(value);
    }

}
