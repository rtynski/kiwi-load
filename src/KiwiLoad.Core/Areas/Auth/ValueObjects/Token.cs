using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.Models;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class Token : ValueObject
{
    public string Value { get; }

    public Token(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadAuthTokenEmptyException();
        }

        Value = value;
    }
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(Token userName)
    {
        return userName.Value;
    }

    public static implicit operator Token(string value)
    {
        return new Token(value);
    }
}
