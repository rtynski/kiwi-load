using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.ValueObjects;

namespace KiwiLoad.Core.Areas.Auth;
public interface IAuthService
{
    Task<Token?> Authenticate(Username username, Password password);
}
