namespace KiwiLoad.Core.Exceptions;
public abstract class KiwiLoadException : Exception
{
    protected KiwiLoadException(string message) : base(message)
    {
    }
}
