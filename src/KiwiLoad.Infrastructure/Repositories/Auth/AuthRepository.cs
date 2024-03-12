using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Auth.ValueObjects;

namespace KiwiLoad.Infrastructure.Repositories.Auth;
public class AuthRepository : IAuthRepository
{
    public async Task<HashValue> Authenticate(Username username)
    {
        await Task.Yield();
        return new HashValue("e7cf3ef4f17c3999a94f2c6f612e8a888e5b1026878e4e19398b23bd38ec221a");
    }
}
