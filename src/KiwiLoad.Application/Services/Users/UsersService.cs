using KiwiLoad.Application.Security;
using KiwiLoad.Core.Areas.Users;
using KiwiLoad.Core.Areas.Users.DTO;
using KiwiLoad.Core.Areas.Users.ValueObjects;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Application.Services.Users;
public class UsersService : IUsersService
{
    private readonly IUsersRepository usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        this.usersRepository=usersRepository;
    }
    public async Task<UserId?> AddUser(AddUserDto user)
    {
        var hashValuePassword = (HashValue)PasswordHashGenerator.GenerateSHA256Hash(user.Password);
        var userDb = new AddUserDbDto(
            user.Username,
            user.Email,
            hashValuePassword,
            new UserId(1)
        );
        var userId = await usersRepository.AddUser(userDb);
        return userId;
    }
}
