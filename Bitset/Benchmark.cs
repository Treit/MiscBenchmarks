namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(64, 1024, 1000000)]
        public int Count { get; set; }

        private BitSet _bitSet;

        private BitArray _bitArray;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _bitSet = new BitSet(Count);
            _bitArray = new BitArray(Count);

            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var v = r.Next(2) switch
                {
                    0 => false,
                    _ => true
                };
                ;
                _bitSet[i] = v;
                _bitArray[i] = v;
            }
        }

        [Benchmark(Baseline = true)]
        public int ReadCustomBitSet()
        {
            int trueBits = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_bitSet[i])
                {
                    trueBits++;
                }
            }

            return trueBits;
        }

        [Benchmark]
        public int ReadBitArray()
        {
            int trueBits = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_bitArray[i])
                {
                    trueBits++;
                }
            }

            return trueBits;
        }

        [Benchmark]
        public void WriteCustomBitSet()
        {
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var v = r.Next(2) switch
                {
                    0 => false,
                    _ => true
                };
                ;

                _bitSet[i] = v;
            }
        }

        [Benchmark]
        public void WriteBitArray()
        {
            var r = new Random(Count);

            for (int i = 0; i < Count; i++)
            {
                var v = r.Next(2) switch
                {
                    0 => false,
                    _ => true
                };
                ;

                _bitArray[i] = v;
            }
        }
    }
}


