using System.Security.Cryptography;

namespace KiwiLoad.Application.Security;
internal class TokenGenerator
{
    public static string GenerateToken(int length)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] chars = new char[length];
        using var rg = RandomNumberGenerator.Create();
        byte[] data = new byte[length];
        rg.GetNonZeroBytes(data);
        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[data[i] % validChars.Length];
        }
        return new string(chars);
    }
}
