using KiwiLoad.Core.Exceptions.Auth;

namespace KiwiLoad.Core.Areas.Auth.ValueObjects;
public class HashValue : IEquatable<HashValue>
{
    public string Value { get; }

    public HashValue(string value)
    {
        if (value is null || string.IsNullOrWhiteSpace(value))
        {
            throw new KiwiLoadAuthHashValueEmptyException();
        }

        Value = value;
    }

    public bool Equals(HashValue? other)
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

    public static implicit operator string(HashValue userName)
    {
        return userName.Value;
    }

    public static implicit operator HashValue(string value)
    {
        return new HashValue(value);
    }
}
