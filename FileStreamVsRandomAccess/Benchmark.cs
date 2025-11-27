namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(3 * 1024 * 1024, 1024 * 1024 * 1024)]
    public int Count { get; set; }

    public string FilePath { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        if (Count < 1024 * 1024 * 2)
        {
            throw new InvalidOperationException("File size must be at least 2KB");
        }

        FilePath = $"TestFile{Count}.bin";

        byte[] bytes = new byte[Count];
        Random r = new Random();
        r.NextBytes(bytes);

        File.WriteAllBytes(FilePath, bytes);
    }

    [Benchmark(Baseline = true)]
    public uint HashFileLocationsUsingFileStreamCrc32()
    {
        uint hash1 = 0;
        uint hash2 = 0;
        uint hash3 = 0;

        using FileStream fs = new FileStream(FilePath, FileMode.Open);

        byte[] buffer = new byte[1024 * 1024 * 2];

        for (int i = 0; i < 10; i++)
        {
            fs.Read(buffer, 0, buffer.Length);
            hash1 = HashUtils.CRC32(buffer);

            fs.Seek(Count / 2, SeekOrigin.Begin);
            fs.Read(buffer, 0, buffer.Length);
            hash2 = HashUtils.CRC32(buffer);

            fs.Seek(1024 * 1024 * 2 * -1, SeekOrigin.End);
            hash3 = HashUtils.CRC32(buffer);
        }

        return (uint)HashCode.Combine(hash1, hash2, hash3);
    }

    [Benchmark]
    public uint HashFileLocationsUsingRandomAccessCrc32()
    {
        SafeFileHandle handle = File.OpenHandle(FilePath, FileMode.Open);

        byte[] buffer = new byte[1024 * 1024 * 2];

        uint hash1 = 0;
        uint hash2 = 0;
        uint hash3 = 0;

        for (int i = 0; i < 10; i++)
        {
            RandomAccess.Read(handle, buffer, 0);
            hash1 = HashUtils.CRC32(buffer);

            RandomAccess.Read(handle, buffer, Count / 2);
            hash2 = HashUtils.CRC32(buffer);

            RandomAccess.Read(handle, buffer, Count - 1024 * 1024 * 2);
            hash3 = HashUtils.CRC32(buffer);
        }

        return (uint)HashCode.Combine(hash1, hash2, hash3);
    }

    [Benchmark]
    public uint HashFileLocationsUsingFileStreamMurmurHash()
    {
        uint hash1 = 0;
        uint hash2 = 0;
        uint hash3 = 0;

        using FileStream fs = new FileStream(FilePath, FileMode.Open);

        byte[] buffer = new byte[1024 * 1024 * 2];

        for (int i = 0; i < 10; i++)
        {
            fs.Read(buffer, 0, buffer.Length);
            hash1 = HashUtils.MurmurHash32(buffer);

            fs.Seek(Count / 2, SeekOrigin.Begin);
            fs.Read(buffer, 0, buffer.Length);
            hash2 = HashUtils.MurmurHash32(buffer);

            fs.Seek(1024 * 1024 * 2 * -1, SeekOrigin.End);
            hash3 = HashUtils.MurmurHash32(buffer);
        }

        return (uint)HashCode.Combine(hash1, hash2, hash3);
    }

    [Benchmark]
    public uint HashFileLocationsUsingRandomAccessMurmurHash()
    {
        SafeFileHandle handle = File.OpenHandle(FilePath, FileMode.Open);

        byte[] buffer = new byte[1024 * 1024 * 2];

        uint hash1 = 0;
        uint hash2 = 0;
        uint hash3 = 0;

        for (int i = 0; i < 10; i++)
        {
            RandomAccess.Read(handle, buffer, 0);
            hash1 = HashUtils.MurmurHash32(buffer);

            RandomAccess.Read(handle, buffer, Count / 2);
            hash2 = HashUtils.MurmurHash32(buffer);

            RandomAccess.Read(handle, buffer, Count - 1024 * 1024 * 2);
            hash3 = HashUtils.MurmurHash32(buffer);
        }

        return (uint)HashCode.Combine(hash1, hash2, hash3);
    }

    [Benchmark]
    public uint HashFileLocationsUsingFileStreamJenkinsHash()
    {
        uint hash1 = 0;
        uint hash2 = 0;
        uint hash3 = 0;

        using FileStream fs = new FileStream(FilePath, FileMode.Open);

        byte[] buffer = new byte[1024 * 1024 * 2];

        for (int i = 0; i < 10; i++)
        {
            fs.Read(buffer, 0, buffer.Length);
            hash1 = (uint)HashUtils.JenkinsHash(buffer);

            fs.Seek(Count / 2, SeekOrigin.Begin);
            fs.Read(buffer, 0, buffer.Length);
            hash2 = (uint)HashUtils.JenkinsHash(buffer);

            fs.Seek(1024 * 1024 * 2 * -1, SeekOrigin.End);
            hash3 = (uint)HashUtils.JenkinsHash(buffer);
        }

        return (uint)HashCode.Combine(hash1, hash2, hash3);
    }

    [Benchmark]
    public uint HashFileLocationsUsingRandomAccessJenkinsHash()
    {
        SafeFileHandle handle = File.OpenHandle(FilePath, FileMode.Open);

        byte[] buffer = new byte[1024 * 1024 * 2];

        uint hash1 = 0;
        uint hash2 = 0;
        uint hash3 = 0;

        for (int i = 0; i < 10; i++)
        {
            RandomAccess.Read(handle, buffer, 0);
            hash1 = (uint)HashUtils.JenkinsHash(buffer);

            RandomAccess.Read(handle, buffer, Count / 2);
            hash2 = (uint)HashUtils.JenkinsHash(buffer);

            RandomAccess.Read(handle, buffer, Count - 1024 * 1024 * 2);
            hash3 = (uint)HashUtils.JenkinsHash(buffer);
        }

        return (uint)HashCode.Combine(hash1, hash2, hash3);
    }
}
