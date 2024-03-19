using KiwiLoad.Application.Security;
using KiwiLoad.Core.Areas.Auth;
using KiwiLoad.Core.Areas.Auth.ValueObjects;
using KiwiLoad.Core.Exceptions.Auth;
using KiwiLoad.Core.ValueObjects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace KiwiLoad.Application.Services.Auth;
internal class AuthService : IAuthService
{
    const int TokenLength = 64;
    private readonly ILogger<AuthService> logger;
    private readonly IAuthRepository authRepository;
    private readonly IMemoryCache memoryCache;
    private readonly ITokenGeneratorProvider tokenGeneratorProvider;
    private readonly IPasswordHashGeneratorProvider passwordHashGeneratorProvider;

    public AuthService(
        ILogger<AuthService> logger,
        IAuthRepository authRepository,
        IMemoryCache memoryCache,
        ITokenGeneratorProvider tokenGeneratorProvider,
        IPasswordHashGeneratorProvider passwordHashGeneratorProvider
    )
    {
        this.logger=logger;
        this.authRepository=authRepository;
        this.memoryCache=memoryCache;
        this.tokenGeneratorProvider=tokenGeneratorProvider;
        this.passwordHashGeneratorProvider=passwordHashGeneratorProvider;
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
        var hashValuePassword = (HashValue)passwordHashGeneratorProvider.GenerateSHA256Hash(password);
        if(hashValueDb == hashValuePassword)
        {
            var tokenString = tokenGeneratorProvider.GenerateToken(TokenLength);
            var vv = TimeSpan.FromMinutes(30);
            memoryCache.Set(
                tokenString,
                (string)username,
                vv
            );
            return (Token)tokenString;
        }
         
        return null;
    }
}
