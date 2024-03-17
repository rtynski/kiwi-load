using KiwiLoad.Core.Areas.Users.ValueObjects;

namespace KiwiLoad.Core.Areas.Users;
public interface IUsersRepository
{
    Task<UserId> AddUser(DTO.AddUserDbDto user);
}
