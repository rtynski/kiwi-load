using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class Password : IEquatable<Password>
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

    public bool Equals(Password? other)
    {
        if (other is null)
            return false;

        return String.Compare(Value, other.Value, false) == 0;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        return Equals(obj as Password);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
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
