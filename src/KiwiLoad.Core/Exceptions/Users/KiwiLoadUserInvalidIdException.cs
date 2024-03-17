namespace KiwiLoad.Core.Exceptions.Users;
public class KiwiLoadUserInvalidIdException : KiwiLoadUsersException
{
    public KiwiLoadUserInvalidIdException(int? userId)
        : base($"Invalid user id: {userId?.ToString() ?? "null"}.")
    {
    }
}
