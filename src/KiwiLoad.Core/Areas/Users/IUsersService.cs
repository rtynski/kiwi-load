using KiwiLoad.Core.Areas.Users.ValueObjects;

namespace KiwiLoad.Core.Areas.Users;
public interface IUsersService
{
    Task<UserId?> AddUser(DTO.AddUserDto user);
}
