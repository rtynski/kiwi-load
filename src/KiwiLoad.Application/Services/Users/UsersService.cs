using KiwiLoad.Application.Security;
using KiwiLoad.Core.Areas.Users;
using KiwiLoad.Core.Areas.Users.DTO;
using KiwiLoad.Core.Areas.Users.ValueObjects;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Application.Services.Users;
internal class UsersService : IUsersService
{
    private readonly IUsersRepository usersRepository;
    private readonly IPasswordHashGeneratorProvider passwordHashGeneratorProvider;

    public UsersService(
        IUsersRepository usersRepository,
        IPasswordHashGeneratorProvider passwordHashGeneratorProvider
    )
    {
        this.usersRepository=usersRepository;
        this.passwordHashGeneratorProvider=passwordHashGeneratorProvider;
    }
    public async Task<UserId?> AddUser(AddUserDto user)
    {
        var hashValuePassword = (HashValue)passwordHashGeneratorProvider.GenerateSHA256Hash(user.Password);
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
