namespace KiwiLoad.Core.Exceptions.Auth;
public class KiwiLoadAuthTokenEmptyException : KiwiLoadAuthException
{
    public KiwiLoadAuthTokenEmptyException() : base("Token cannot be null or empty")
    {
    }
}
