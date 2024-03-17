using KiwiLoad.Core.Areas.Users.ValueObjects;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Core.Areas.Users.DTO;
public class AddUserDto
{
    public AddUserDto(Username username, Email email, Password password)
    {
        Username=username;
        Email=email;
        Password=password;
    }
    public Username Username { get; }
    public Email Email { get; }
    public Password Password { get; }
}
