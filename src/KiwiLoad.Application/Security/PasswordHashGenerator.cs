using System.Security.Cryptography;
using System.Text;

namespace KiwiLoad.Application.Security;
internal class PasswordHashGenerator
{
    public static string GenerateSHA256Hash(string password)
    {
        using var sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
