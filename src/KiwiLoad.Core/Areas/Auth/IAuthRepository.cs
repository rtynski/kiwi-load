using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Core.Areas.Auth;
public interface IAuthRepository
{
    Task<HashValue> Authenticate(Username username);
}
