using System.Text;

namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Buffers.Binary;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private MemoryStream _mstream;

        [Params(1000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            var bytes = Convert.FromHexString("10C348B950C76A2120CC5C38517D6B27");
            _mstream = new MemoryStream(bytes);

        }

        [Benchmark]
        public Guid MemoryStreamToGuidUsingBitConverter()
        {
            _mstream.Position = 0;
            byte[] readBytes = new byte[_mstream.Length];
            _ = _mstream.Read(readBytes, 0, (int)_mstream.Length);
            string hexString = BitConverter.ToString(readBytes).Replace("-", "");
            return new Guid(hexString);
        }

        [Benchmark]
        public Guid MemoryStreamToGuidUsingToHexString()
        {
            _mstream.Position = 0;
            Span<byte> bytes = stackalloc byte[16];
            _mstream.ReadExactly(bytes);
            var str = Convert.ToHexString(bytes);
            return new Guid(str);
        }

        [Benchmark(Baseline = true)]
        public Guid MemoryStreamToGuidUsingSpanAndBigEndian()
        {
            _mstream.Position = 0;
            Span<byte> bytes = stackalloc byte[16];
            _mstream.ReadExactly(bytes);
            return new Guid(bytes, true);
        }

        [Benchmark]
        public Guid MemoryStreamToGuidUsingBinaryPrimitivesChatGPT()
        {
            _mstream.Position = 0;
            Span<byte> buffer = stackalloc byte[16];
            _mstream.ReadExactly(buffer);
            int a = BinaryPrimitives.ReadInt32BigEndian(buffer);
            short b = BinaryPrimitives.ReadInt16BigEndian(buffer.Slice(4, 2));
            short c = BinaryPrimitives.ReadInt16BigEndian(buffer.Slice(6, 2));
            Guid guid = new Guid(a, b, c, buffer[8], buffer[9], buffer[10], buffer[11], buffer[12], buffer[13], buffer[14], buffer[15]);
            return guid;
        }

        [Benchmark]
        public Guid MemoryStreamToGuidUsingReadByteOrThrowChatGPT()
        {
            _mstream.Position = 0;
            int ReadByteOrThrow()
            {
                int b = _mstream.ReadByte();
                if (b == -1)
                    throw new EndOfStreamException("Unexpected end of stream");
                return b;
            }
            int b0 = ReadByteOrThrow();
            int b1 = ReadByteOrThrow();
            int b2 = ReadByteOrThrow();
            int b3 = ReadByteOrThrow();

            int b4 = ReadByteOrThrow();
            int b5 = ReadByteOrThrow();

            int b6 = ReadByteOrThrow();
            int b7 = ReadByteOrThrow();

            int b8 = ReadByteOrThrow();
            int b9 = ReadByteOrThrow();
            int b10 = ReadByteOrThrow();
            int b11 = ReadByteOrThrow();
            int b12 = ReadByteOrThrow();
            int b13 = ReadByteOrThrow();
            int b14 = ReadByteOrThrow();
            int b15 = ReadByteOrThrow();

            int a = (b3) | (b2 << 8) | (b1 << 16) | (b0 << 24);
            short s_b = (short)((b5) | (b4 << 8));
            short c = (short)((b7) | (b6 << 8));

            byte d = (byte)b8;
            byte e = (byte)b9;
            byte f = (byte)b10;
            byte g = (byte)b11;
            byte h = (byte)b12;
            byte i = (byte)b13;
            byte j = (byte)b14;
            byte k = (byte)b15;

            Guid guid = new Guid(a, s_b, c, d, e, f, g, h, i, j, k);

            return guid;
        }
    }
}

