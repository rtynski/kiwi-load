namespace KiwiLoad.Core.Exceptions.Auth;
public abstract class KiwiLoadAuthException : KiwiLoadException
{
    public KiwiLoadAuthException(string message) : base(message)
    {
    }
}