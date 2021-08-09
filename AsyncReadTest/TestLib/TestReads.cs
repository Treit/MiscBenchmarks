namespace TestLib
{
    using System;
    using System.Buffers;
    using System.Buffers.Binary;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class TestReads
    {
        private MemoryStream ms;
        private byte[] bytes;
        int currpos = 0;

        byte[] fixedBuffer = new byte[sizeof(int)];

        public TestReads(int sizeInBytes)
        {
            ms = Populate(sizeInBytes);
            bytes = ms.ToArray();
        }

        public (bool hasNext, int value) ReadNext()
        {
            bool hasNext = false;
            int value = -1;

            var buffer = new byte[sizeof(int)];

            if (ms.Read(buffer, 0, buffer.Length) > 0)
            {
                hasNext = true;
                value = BitConverter.ToInt32(buffer, 0);
            }

            return (hasNext, value);
        }

        public (bool hasNext, int value) ReadNextWithArrayPool()
        {
            bool hasNext = false;
            int value = -1;

            var buffer = ArrayPool<byte>.Shared.Rent(sizeof(int));

            if (ms.Read(buffer, 0, sizeof(int)) > 0)
            {
                hasNext = true;
                value = BitConverter.ToInt32(buffer, 0);
            }

            ArrayPool<byte>.Shared.Return(buffer);

            return (hasNext, value);
        }

        public (bool hasNext, int value) ReadNextWithFixedBuffer()
        {
            bool hasNext = false;
            int value = -1;

            var buffer = this.fixedBuffer;

            if (ms.Read(buffer, 0, sizeof(int)) > 0)
            {
                hasNext = true;
                value = BitConverter.ToInt32(buffer, 0);
            }

            return (hasNext, value);
        }

        public async Task<(bool hasNext, int value)> ReadNextAsync(CancellationToken ct)
        {
            bool hasNext = false;
            int value = -1;

            var buffer = new byte[sizeof(int)];
            if (await ms.ReadAsync(buffer, 0, buffer.Length, ct) > 0)
            {
                hasNext = true;
                value = BitConverter.ToInt32(buffer, 0);
            }

            return (hasNext, value);
        }

        public (bool hasNext, int value) ReadNextWithSpan(int sizeInBytes)
        {
            bool hasNext = false;
            int value = BinaryPrimitives.ReadInt32LittleEndian(new Span<byte>(this.bytes, currpos, sizeof(int)));
            this.currpos += sizeof(int);

            if (currpos < this.bytes.Length)
            {
                hasNext = true;
            }

            return (hasNext, value);
        }

        private static MemoryStream Populate(int sizeInBytes)
        {
            Random r = new Random();

            byte[] buffer = new byte[sizeInBytes];
            r.NextBytes(buffer);

            return new MemoryStream(buffer);
        }
    }
}
