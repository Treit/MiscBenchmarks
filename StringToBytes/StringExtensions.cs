using System;

namespace Test;
internal static class StringExtensions
{
    public static byte[] GetBytes(this string str)
    {
        if (str is null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        byte[] bytes = new byte[str.Length * sizeof(char)];
        Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
}
