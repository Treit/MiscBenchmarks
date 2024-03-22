namespace Test
{
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Buffers.Binary;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    [MemoryDiagnoser]
    public class Benchmark
    {
        static string s_fileName = "nums.bin";

        [Params(100, 1_000_000)]
        public int Count;

        [GlobalSetup]
        public void GlobalSetup()
        {
            using var fs = new FileStream(s_fileName, FileMode.Create, FileAccess.Write);
            var random = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var num = random.Next(1_000_000);
                fs.Write(BitConverter.GetBytes(num));
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            File.Delete(s_fileName);
        }

        [Benchmark]
        public long ReadDataUsingBitConverter()
        {
            using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
            var buffer = new byte[sizeof(int)];
            long sum = 0;

            for (int i = 0; i < Count; i++)
            {
                fs.Read(buffer, 0, sizeof(int));
                sum += BitConverter.ToInt32(buffer);
            }

            return sum;
        }

        [Benchmark]
        public long ReadDataUsingBinaryPrimitivesAndSpan()
        {
            var buffer = new byte[1024 * 4];
            using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
            var read = 0;
            var sum = 0L;

            while ((read = fs.Read(buffer)) > 0)
            {
                if (read < 4)
                {
                    break;
                }

                var span = buffer.AsSpan(0, read);
                while (span.Length >= 4)
                {
                    var num = BinaryPrimitives.ReadInt32LittleEndian(span);
                    span = span[4..];
                    sum += num;
                }
            }

            return sum;
        }

        [Benchmark(Baseline = true)]
        public long ReadDataUsingBinaryPrimitivesAndSpanWithReinterpretCast()
        {
            var buffer = new byte[1024 * 4];
            using var fs = new FileStream(s_fileName, FileMode.Open, FileAccess.Read);
            var read = 0;
            var sum = 0L;

            while ((read = fs.Read(buffer)) > 0)
            {
                if (read < 4)
                {
                    break;
                }

                var span = buffer.AsSpan(0, read);
                var integers = MemoryMarshal.Cast<byte, int>(span);
                foreach (var num in integers)
                {
                    sum += num;
                }
            }

            return sum;
        }
    }
}
