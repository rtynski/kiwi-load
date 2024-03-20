using KiwiLoad.Core.Areas.Users;
using KiwiLoad.Core.Areas.Users.DTO;
using KiwiLoad.Core.Areas.Users.ValueObjects;
using KiwiLoad.Infrastructure.Databases;
using KiwiLoad.Infrastructure.Databases.Entries;
using Microsoft.Extensions.Logging;

namespace KiwiLoad.Infrastructure.Repositories.Users;
internal class UsersRepository : IUsersRepository
{
    private readonly KiwiDbContext dbContext;
    private readonly ILogger<UsersRepository> logger;
    public UsersRepository(ILogger<UsersRepository> logger, KiwiDbContext dbContext)
    {
        this.logger=logger;
        this.dbContext=dbContext;
    }

    public async Task<UserId> AddUser(AddUserDbDto user)
    {
        var addDate = DateTime.UtcNow;

        var userDb = new User()
        {
            Username=user.Username,
            Email=user.Email,
            PasswordHash=user.PasswordHash,
            AddUserId = user.AddUserId,
            AddDate = addDate,
            UpdateUserId = user.AddUserId,
            UpdateDate = addDate
        };
        dbContext.Users.Add(userDb);
        var recordAdded = await dbContext.SaveChangesAsync();
        logger.LogInformation("User added: {UserName}. By {UserId}. Records {Records}", userDb.Username, userDb.Id, recordAdded);
        return new UserId(userDb.Id);
    }
}
