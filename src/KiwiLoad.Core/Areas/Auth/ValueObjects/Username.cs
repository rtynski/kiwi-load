using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class Username : ValueObject
{
    public string Value { get; }

    public Username(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadAuthUsernameEmptyException();
        }

        Value = value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(Username userName)
    {
        return userName.Value;
    }

    public static implicit operator Username(string value)
    {
        return new Username(value);
    }
}
