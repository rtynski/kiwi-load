namespace KiwiLoad.Application.Security;
public interface ITokenGeneratorProvider
{
    string GenerateToken(int length);
}
