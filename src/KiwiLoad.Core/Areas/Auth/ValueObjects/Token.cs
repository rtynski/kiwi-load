using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class Token : IEquatable<Token>
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

    public bool Equals(Token? other)
    {
        if (other is null)
            return false;

        return string.Compare(Value, other.Value, false) == 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        return Equals(obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
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
