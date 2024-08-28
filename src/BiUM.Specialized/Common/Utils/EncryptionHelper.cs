using System.Security.Cryptography;
using System.Text;

namespace BiUM.Specialized.Common.Utils;

public static class EncryptionHelper
{
    private static string EncryptionKey = "bi-key-env-123456";

    private static Rfc2898DeriveBytes EncryptionBytes = new(EncryptionKey, [0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76]);

    public static string Encrypt(string clearText)
    {
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

        using (Aes encryptor = Aes.Create())
        {
            encryptor.Key = EncryptionBytes.GetBytes(32);
            encryptor.IV = EncryptionBytes.GetBytes(16);

            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
            }

            clearText = Convert.ToBase64String(ms.ToArray());
        }

        return clearText;
    }

    public static string Decrypt(string encryptedText)
    {
        encryptedText = encryptedText.Replace(" ", "+");
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

        using (Aes encryptor = Aes.Create())
        {
            encryptor.Key = EncryptionBytes.GetBytes(32);
            encryptor.IV = EncryptionBytes.GetBytes(16);

            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                cs.Close();
            }

            encryptedText = Encoding.Unicode.GetString(ms.ToArray());
        }

        return encryptedText;
    }
}