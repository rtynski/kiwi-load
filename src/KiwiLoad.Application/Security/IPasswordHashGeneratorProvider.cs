namespace KiwiLoad.Application.Security;

internal interface IPasswordHashGeneratorProvider
{
    string GenerateSHA256Hash(string password);
}