namespace Test;
using System;
using System.Text;

/// <summary>
/// MurmurHash3 was written by Austin Appleby, and is placed in the public 
/// domain. The author hereby disclaims copyright to this source code.
/// 
/// Note - The x86 and x64 versions do _not_ produce the same results, as the
/// algorithms are optimized for their respective platforms. You can still
/// compile and run any of them on any platform, but your performance with the
/// non-native version will be less than optimal. 
/// 
/// Below APIS are derived from native code.
/// </summary>
internal static class MurmurHash
{
    /// <summary>
    /// Gets the murmur3hash of the data.
    /// </summary>
    /// <param name="data">The data to hash.</param>
    /// <returns>The 32-bit hash of the data.</returns>
    internal static uint Get32BitHash(byte[] data)
    {
        return MurmurHash3_x86_32(data, 0);
    }

    /// <summary>
    /// Gets murmur3hash of the string
    /// </summary>
    /// <param name="toHash">The value to hash.</param>
    /// <returns>The 32-bit hash.</returns>
    internal static uint Get32BitHash(string toHash)
    {
        byte[] key;

        // Don't do any preprocessing to generate the raw Murmur hash
        key = Encoding.UTF8.GetBytes(toHash);

        return Get32BitHash(key);
    }

    /// <summary>
    /// Gets murmur3hash of the string
    /// </summary>
    /// <param name="toHash">The value to hash.</param>
    /// <returns>The hash value.</returns>
    internal static uint Get32BitHashNormalizedString(string toHash)
    {
        return Get32BitHash(toHash.Trim().ToLower());
    }

    /// <summary>
    /// Gets a 64-bit hash.
    /// </summary>
    /// <param name="data">The data to hash.</param>
    /// <param name="seed">The seed to use, if any.</param>
    /// <returns>The 64-bit hash of the data.</returns>
    internal static ulong Get64BitHash(byte[] data, uint seed = 0)
    {
        int length = data.Length;

        ulong m = 0xc6a4a7935bd1e995ul;
        int r = 47;

        ulong h = (ulong)(seed ^ length);

        for (int i = 0; i < length / 8; i++)
        {
            ulong k = BitConverter.ToUInt64(data, i * 8);

            k *= m;
            k ^= k >> r;
            k *= m;
            h ^= k;
            h *= m;
        }

        int processedLength = (length / 8) * 8;
        if ((length & 7) == 7) h ^= (ulong)(data[processedLength + 6]) << 48;
        if ((length & 7) >= 6) h ^= (ulong)(data[processedLength + 5]) << 40;
        if ((length & 7) >= 5) h ^= (ulong)(data[processedLength + 4]) << 32;
        if ((length & 7) >= 4) h ^= (ulong)(data[processedLength + 3]) << 24;
        if ((length & 7) >= 3) h ^= (ulong)(data[processedLength + 2]) << 16;
        if ((length & 7) >= 2) h ^= (ulong)(data[processedLength + 1]) << 8;
        if ((length & 7) >= 1)
        {
            h ^= data[processedLength];
            h *= m;
        }

        h ^= h >> r;
        h *= m;
        h ^= h >> r;

        return h;
    }

    /// <summary>
    /// Computes MurmurHash64A
    /// </summary>
    /// <param name="input">The input value.</param>
    /// <param name="seed">The seed value.</param>
    /// <returns>The hash value.</returns>
    internal static ulong Get64BitHash(string input, uint seed = 0)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        return Get64BitHash(data, seed);
    }

    private static uint Getblock(byte[] p, int i)
    {
        int index = (i * 4);

        return BitConverter.ToUInt32(p, index);
    }

    private static uint Rotl32(uint v, int bits)
    {
        return (v << bits) | (v >> (32 - bits));
    }

    /// <summary>
    /// Finalization mix - force all bits of a hash block to avalanche
    /// </summary>
    /// <param name="h">The value to process</param>
    /// <returns>The mixed value.</returns>
    private static uint FinalMix(uint h)
    {
        h ^= h >> 16;
        h *= 0x85ebca6b;
        h ^= h >> 13;
        h *= 0xc2b2ae35;
        h ^= h >> 16;

        return h;
    }

    private static uint MurmurHash3_x86_32(byte[] key, uint seed)
    {
        int nblocks = key.Length / 4;
        uint h1 = seed;
        uint c1 = 0xcc9e2d51;
        uint c2 = 0x1b873593;
        uint k1;

        for (int i = 0; i < nblocks; i++)
        {
            k1 = Getblock(key, i);
            k1 *= c1;
            k1 = Rotl32(k1, 15);
            k1 *= c2;
            h1 ^= k1;
            h1 = Rotl32(h1, 13);
            h1 = h1 * 5 + 0xe6546b64;
        }

        k1 = 0;
        int tail = nblocks * 4;

        switch (key.Length & 3)
        {
            case 3:
                k1 ^= (uint)key[tail + 2] << 16;
                goto case 2;
            case 2:
                k1 ^= (uint)key[tail + 1] << 8;
                goto case 1;
            case 1:
                k1 ^= (uint)key[tail];
                k1 *= c1; k1 = Rotl32(k1, 15); k1 *= c2;
                h1 ^= k1;
                break;
        };

        h1 ^= (uint)key.Length;
        h1 = FinalMix(h1);

        return h1;
    }
}
