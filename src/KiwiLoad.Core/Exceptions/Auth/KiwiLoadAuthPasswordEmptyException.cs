namespace KiwiLoad.Core.Exceptions.Auth;
public class KiwiLoadAuthPasswordEmptyException : KiwiLoadAuthException
{
    public KiwiLoadAuthPasswordEmptyException() : base("Password cannot be null or empty")
    {
    }
}
