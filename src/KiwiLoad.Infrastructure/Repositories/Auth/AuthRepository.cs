using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Auth.ValueObjects;

namespace KiwiLoad.Infrastructure.Repositories.Auth;
public class AuthRepository : IAuthRepository
{
    public Task<HashValue> Authenticate(Username username)
    {
        return new Task<HashValue>(() => new HashValue("hash"));
    }
}
