namespace Benchmark
{
    using BenchmarkDotNet.Attributes;
    using System.Threading;
    using System.Threading.Tasks;
    using TestLib;

    [MemoryDiagnoser]
    public class Benchmark
    {
        const int One_KB = 1024;
        const int One_MB = 1024 * 1024;
        const int Ten_MB = 10 * 1024 * 1024;
        const int Fifty_MB = 50 * 1024 * 1024;

        [Params(One_KB, One_MB, Ten_MB, Fifty_MB)]
        public int NumBytes;

        [Benchmark]
        public int NonAsync()
        {
            TestReads tr = new TestReads(this.NumBytes);
            bool finished = false;
            int final = -1;

            while (!finished)
            {
                var (more, val) = tr.ReadNext();
                finished = !more;
                final = val;
            }

            return final;
        }

        [Benchmark]
        public int NonAsyncWithArrayPool()
        {
            TestReads tr = new TestReads(this.NumBytes);
            bool finished = false;
            int final = -1;

            while (!finished)
            {
                var (more, val) = tr.ReadNextWithArrayPool();
                finished = !more;
                final = val;
            }

            return final;
        }

        [Benchmark]
        public int NonAsyncWithFixedBuffer()
        {
            TestReads tr = new TestReads(this.NumBytes);
            bool finished = false;
            int final = -1;

            while (!finished)
            {
                var (more, val) = tr.ReadNextWithFixedBuffer();
                finished = !more;
                final = val;
            }

            return final;
        }

        [Benchmark]
        public int Async()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            TestReads tr = new TestReads(this.NumBytes);
            bool finished = false;
            int final = -1;

            while (!finished)
            {
                var (more, val) = tr.ReadNextAsync(cts.Token).Result;
                finished = !more;
                final = val;
            }

            return final;
        }

        [Benchmark]
        public int AsyncWithAwait()
        {
            int final = -1;
            return DoItAsync().Result;

            async Task<int> DoItAsync()
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                TestReads tr = new TestReads(this.NumBytes);
                bool finished = false;

                while (!finished)
                {
                    var (more, val) = await tr.ReadNextAsync(cts.Token);
                    finished = !more;
                    final = val;
                }

                return final;
            }
        }

        [Benchmark]
        public int RawBytesAndSpan()
        {
            TestReads tr = new TestReads(this.NumBytes);
            bool finished = false;
            int final = -1;

            while (!finished)
            {
                var (more, val) = tr.ReadNextWithSpan(this.NumBytes);
                finished = !more;
                final = val;
            }

            return final;
        }
    }
}
