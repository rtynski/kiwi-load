using KiwiLoad.Core.Areas.Users.ValueObjects;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Core.Areas.Users.DTO;
public class AddUserDbDto
{
    public AddUserDbDto(Username username, Email email, HashValue passwordHash, UserId addUserId)
    {
        Username=username;
        Email=email;
        PasswordHash=passwordHash;
        AddUserId=addUserId;
    }
    public Username Username { get; }
    public Email Email { get; }
    public HashValue PasswordHash { get; }
    public UserId AddUserId { get; }
}
