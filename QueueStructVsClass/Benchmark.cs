namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;

    struct DataStruct
    {
        public int Code;
        public byte[] Message;
        public IPAddress IPADDR;
        public IPEndPoint EndPoint;
    }

    class DataClass
    {
        public int Code;
        public byte[] Message;
        public IPAddress IPADDR;
        public IPEndPoint EndPoint;
    }

    [MemoryDiagnoser]
    [ShortRunJob]
    public class Benchmark
    {
        [Params(10, 100, 1000, 10_000, 100_000, 1_000_000)]
        public int Count { get; set; }

        private Queue<DataStruct> _structQueue;
        private Queue<DataClass> _classQueue;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _structQueue = new Queue<DataStruct>(Count);
            _classQueue = new Queue<DataClass>(Count);
        }

        [Benchmark]
        public long QueueUsingStruct()
        {
            _structQueue.Clear();

            PopulateQueueUsingStruct();

            long result = 0;

            while (_structQueue.Count > 0)
            {
                var item = _structQueue.Dequeue();
                result += item.Message.Length;
            }

            return result;
        }

        [Benchmark(Baseline = true)]
        public long QueueUsingClass()
        {
            _classQueue.Clear();

            PopulateQueueUsingClass();

            long result = 0;

            while (_classQueue.Count > 0)
            {
                var item = _classQueue.Dequeue();
                result += item.Message.Length;
            }

            return result;
        }

        private void PopulateQueueUsingStruct()
        {
            for (int i = 0; i < Count; i++)
            {
                DataStruct item = new DataStruct
                {
                    IPADDR = new IPAddress(0x2414111),
                    Code = i,
                    EndPoint = new IPEndPoint(0x2414111, 10052),
                    Message = new byte[4096]
                };

                _structQueue.Enqueue(item);
            }
        }

        private void PopulateQueueUsingClass()
        {
            for (int i = 0; i < Count; i++)
            {
                DataClass item = new DataClass
                {
                    IPADDR = new IPAddress(0x2414111),
                    Code = i,
                    EndPoint = new IPEndPoint(0x2414111, 10052),
                    Message = new byte[4096]
                };

                _classQueue.Enqueue(item);
            }
        }
    }
}
