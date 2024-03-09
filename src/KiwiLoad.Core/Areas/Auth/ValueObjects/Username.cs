using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class Username : IEquatable<Username>
{
    public string Value { get; }

    public Username(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadAuthUsernameEmptyException();
        }

        Value = value;
    }

    public bool Equals(Username? other)
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

    public static implicit operator string(Username userName)
    {
        return userName.Value;
    }

    public static implicit operator Username(string value)
    {
        return new Username(value);
    }
}
