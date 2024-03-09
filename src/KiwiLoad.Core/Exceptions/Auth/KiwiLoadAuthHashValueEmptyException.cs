namespace KiwiLoad.Core.Exceptions.Auth;
public class KiwiLoadAuthHashValueEmptyException : KiwiLoadAuthException
{
    public KiwiLoadAuthHashValueEmptyException() : base("Hash value cannot be null or empty")
    {
    }
}
