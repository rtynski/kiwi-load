using KiwiLoad.Application.Security;
using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Auth.ValueObjects;

namespace KiwiLoad.Application.Services.Auth;
public class AuthService(IAuthRepository authRepository ) : IAuthService
{
    const int TokenLength = 64;
    public async Task<Token?> Authenticate(Username username, Password password)
    {
        var hashValueDb = await authRepository.Authenticate(username);
        var hashValuePassword = (HashValue)PasswordHashGenerator.GenerateSHA256Hash(password);
        if(hashValueDb == hashValuePassword)
        {
            var token = (Token)TokenGenerator.GenerateToken(TokenLength);
            return token;
        }
        return null;
    }
}
