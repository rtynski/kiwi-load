namespace KiwiLoad.Core.Exceptions.Auth;
public class KiwiLoadAuthUsernameEmptyException : KiwiLoadAuthException
{
    public KiwiLoadAuthUsernameEmptyException() : base("Username cannot be null or empty")
    {
    }
}
