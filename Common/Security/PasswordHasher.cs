using System.Security.Cryptography;
using System.Text;

namespace Common.Security;

public static class PasswordHasher
{
    public static string ComputeStringToSha256Hash(string plainText)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(plainText));
        StringBuilder sb = new();

        for (int i = 0; i < bytes.Length; i++)
            sb.Append(bytes[i].ToString("x2"));

        return sb.ToString();
    }
}