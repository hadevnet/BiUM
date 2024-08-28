using System.Security.Cryptography;
using System.Text;

namespace BiUM.Specialized.Common.Utils;

public static class GuidGenerator
{
    public static Guid NewGuid(string seed)
    {
        // Belirli bir namespace UUID'si
        var MY_NAMESPACE = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8");
        var namespaceBytes = MY_NAMESPACE.ToByteArray();
        var nameBytes = Encoding.UTF8.GetBytes(seed);

        // RFC 4122 namespace format correction (network byte order)
        SwapByteOrder(namespaceBytes);

        // Combine the namespace and name bytes
        var combinedBytes = new byte[namespaceBytes.Length + nameBytes.Length];
        Buffer.BlockCopy(namespaceBytes, 0, combinedBytes, 0, namespaceBytes.Length);
        Buffer.BlockCopy(nameBytes, 0, combinedBytes, namespaceBytes.Length, nameBytes.Length);

        using var sha1 = SHA1.Create();

        // Compute the hash of the combined bytes
        var hashBytes = sha1.ComputeHash(combinedBytes);

        // Set the version to 5 (0101 in binary)
        hashBytes[6] &= 0x0F;
        hashBytes[6] |= 0x50;

        // Set the variant to RFC 4122 (10xx in binary)
        hashBytes[8] &= 0x3F;
        hashBytes[8] |= 0x80;

        // Create a Guid from the first 16 bytes of the hash
        var guidBytes = new byte[16];
        Array.Copy(hashBytes, 0, guidBytes, 0, 16);

        // RFC 4122 variant format correction (network byte order)
        SwapByteOrder(guidBytes);

        return new Guid(guidBytes);
    }

    private static void SwapByteOrder(byte[] guid)
    {
        Swap(guid, 0, 3);
        Swap(guid, 1, 2);
        Swap(guid, 4, 5);
        Swap(guid, 6, 7);
    }

    private static void Swap(byte[] guid, int left, int right)
    {
        var temp = guid[left];
        guid[left] = guid[right];
        guid[right] = temp;
    }
}