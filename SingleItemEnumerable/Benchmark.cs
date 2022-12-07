namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark(Baseline = true)]
        public long SingleItemIntEnumerableDotRepeat()
        {
            int total = 0;

            foreach (var item in SingleItem<int>.EnumerableRepeat(1024))
            {
                total += item;
            }

            return total;
        }

        [Benchmark]
        public long SingleItemIntEnumerableNewArray()
        {
            int total = 0;

            foreach (var item in SingleItem<int>.SingleItemArray(1024))
            {
                total += item;
            }

            return total;
        }

        [Benchmark]
        public long SingleItemIntEnumerableWrapperClass()
        {
            int total = 0;

            foreach (var item in new SingleItem<int>(1024))
            {
                total += item;
            }

            return total;
        }

        [Benchmark]
        public long SingleItemStringEnumerableDotRepeat()
        {
            int total = 0;

            foreach (var item in SingleItem<string>.EnumerableRepeat("ABCDEFGH"))
            {
                total += item.Length;
            }

            return total;
        }

        [Benchmark]
        public long SingleItemStringEnumerableNewArray()
        {
            int total = 0;

            foreach (var item in SingleItem<string>.SingleItemArray("ABCDEFGH"))
            {
                total += item.Length;
            }

            return total;
        }

        [Benchmark]
        public long SingleItemStringEnumerableWrapperClass()
        {
            int total = 0;

            foreach (var item in new SingleItem<string>("ABCDEFGH"))
            {
                total += item.Length;
            }

            return total;
        }
    }

    class SingleItem<T> : IEnumerable<T>, IEnumerator, IEnumerator<T>
    {
        private bool _disposed;
        private bool _consumed;
        private T _item;

        public SingleItem(T item)
        {
            _item = item;
        }

        public T Current => _item;

        object IEnumerator.Current => _item;

        public static IEnumerable<T> EnumerableRepeat(T item)
        {
            return Enumerable.Repeat(item, 1);
        }

        public static IEnumerable<T> SingleItemArray(T item)
        {
            return new T[] { item };
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (!_consumed)
            {
                _consumed = true;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _consumed = false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}
