using KiwiLoad.Application.Security;
using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace KiwiLoad.Application.Services.Auth;
public class AuthService : IAuthService
{
    const int TokenLength = 64;
    private readonly ILogger<AuthService> logger;
    private readonly IAuthRepository authRepository;
    private readonly IMemoryCache memoryCache;

    public AuthService(
        ILogger<AuthService> logger,
        IAuthRepository authRepository,
        IMemoryCache memoryCache
    )
    {
        this.logger=logger;
        this.authRepository=authRepository;
        this.memoryCache=memoryCache;
    }

    public async Task<Token?> Authenticate(Username username, Password password)
    {
        string hashValueDb;
        try
        {
            hashValueDb = await authRepository.Authenticate(username);
        }
        catch(KiwiLoadAuthHashValueEmptyException exp)
        {
            logger.LogWarning(exp, exp.Message);
            return null;
        }
        var hashValuePassword = (HashValue)PasswordHashGenerator.GenerateSHA256Hash(password);
        if(hashValueDb == hashValuePassword)
        {
            var tokenString = TokenGenerator.GenerateToken(TokenLength);
            var mc = memoryCache.Set(tokenString, (string)username, TimeSpan.FromMinutes(30));
            return (Token)tokenString;
        }
         
        return null;
    }
}
