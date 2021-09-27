namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [MemoryDiagnoser]
    [ShortRunJob]
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
        public uint HashFileLocationsUsingFileStream()
        {
            uint crc1 = 0;
            uint crc2 = 0;
            uint crc3 = 0;

            using FileStream fs = new FileStream(FilePath, FileMode.Open);

            byte[] buffer = new byte[1024 * 1024 * 2];

            for (int i = 0; i < 10; i++)
            {
                fs.Read(buffer, 0, buffer.Length);
                crc1 = HashUtils.CRC32(buffer);

                fs.Seek(Count / 2, SeekOrigin.Begin);
                fs.Read(buffer, 0, buffer.Length);
                crc2 = HashUtils.CRC32(buffer);

                fs.Seek(1024 * 1024 * 2 * -1, SeekOrigin.End);
                crc3 = HashUtils.CRC32(buffer);
            }

            return crc1 ^ crc2 ^ crc3;
        }

        [Benchmark]
        public uint HashFileLocationsUsingRandomAccess()
        {
            SafeFileHandle handle = File.OpenHandle(FilePath, FileMode.Open);

            byte[] buffer = new byte[1024 * 1024 * 2];

            uint crc1 = 0;
            uint crc2 = 0;
            uint crc3 = 0;

            for (int i = 0; i < 10; i++)
            {
                RandomAccess.Read(handle, buffer, 0);
                crc1 = HashUtils.CRC32(buffer);

                RandomAccess.Read(handle, buffer, Count / 2);
                crc2 = HashUtils.CRC32(buffer);

                RandomAccess.Read(handle, buffer, Count - 1024 * 1024 * 2);
                crc3 = HashUtils.CRC32(buffer);
            }

            return crc1 ^ crc2 ^ crc3;
        }
    }
}
