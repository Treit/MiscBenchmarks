using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class Benchmark
    {
        [Params(100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public int WriteArray()
        {
            var bytes = new byte[Count / 2];

            var written = 0;

            while (written < Count)
            {
                bytes[written++] = 0xFF;

                if (written >= bytes.Length)
                {
                    Array.Resize(ref bytes, Count);
                }
            }

            return bytes.Length;
        }

        [Benchmark]
        public int WriteArrayInChunks()
        {
            var block = new byte[Count / 4];
            Array.Fill(block, (byte)0xFF);

            var bytes = new byte[Count / 2];

            var written = 0;

            while (written < Count)
            {
                Array.Copy(block, 0, bytes, written, block.Length);

                written += block.Length;

                if (written >= bytes.Length)
                {
                    Array.Resize(ref bytes, Count);
                }
            }

            return bytes.Length;
        }

        [Benchmark]
        public int WriteMemoryStream()
        {
            var bytes = new MemoryStream(Count / 2);

            var written = 0;

            while (written < Count)
            {
                bytes.WriteByte(0xFF);
                written++;
            }

            return (int)bytes.Length;
        }

        [Benchmark]
        public int WriteMemoryStreamInChunks()
        {
            var block = new byte[Count / 4];
            Array.Fill(block, (byte)0xFF);

            var bytes = new MemoryStream(Count / 2);

            var written = 0;

            while (written < Count)
            {
                bytes.Write(block);
                written += block.Length;
            }

            return (int)bytes.Length;
        }
    }
}