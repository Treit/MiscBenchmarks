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
        private MemoryStream _ms;
        private byte[] _bytes;
        int _currpos = 0;

        byte[] _fixexdBuffer = new byte[sizeof(int)];

        public TestReads(int sizeInBytes)
        {
            _ms = Populate(sizeInBytes);
            _bytes = _ms.ToArray();
        }

        public void Reset()
        {
            _currpos = 0;
            _ms.Seek(0, SeekOrigin.Begin);
        }

        public (bool hasNext, int value) ReadNext()
        {
            bool hasNext = false;
            int value = -1;

            var buffer = new byte[sizeof(int)];

            if (_ms.Read(buffer, 0, buffer.Length) > 0)
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

            if (_ms.Read(buffer, 0, sizeof(int)) > 0)
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

            var buffer = _fixexdBuffer;

            if (_ms.Read(buffer, 0, sizeof(int)) > 0)
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
            if (await _ms.ReadAsync(buffer, 0, buffer.Length, ct) > 0)
            {
                hasNext = true;
                value = BitConverter.ToInt32(buffer, 0);
            }

            return (hasNext, value);
        }

        public (bool hasNext, int value) ReadNextWithSpan(int sizeInBytes)
        {
            bool hasNext = false;
            int value = BinaryPrimitives.ReadInt32LittleEndian(new Span<byte>(_bytes, _currpos, sizeof(int)));
            _currpos += sizeof(int);

            if (_currpos < _bytes.Length)
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
