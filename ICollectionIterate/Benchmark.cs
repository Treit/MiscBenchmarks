namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private string[] _stringArray;
        private List<string> _stringList;
        private HashSet<string> _stringSet;

        [Params(10, 100_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _stringArray = new string[Count];
            _stringList = new List<string>(Count);
            _stringSet = new HashSet<string>(Count);

            for (int i = 0; i < Count; i++)
            {
                var str = i.ToString();
                _stringArray[i] = str;
                _stringList.Add(str);
                _stringSet.Add(str);
            }
        }

        [Benchmark(Baseline = true)]
        public long ICollectionForLoopWithCastToArray()
        {
            return DoLoopOnICollection(_stringArray);
        }

        [Benchmark]
        public long ICollectionForEachLoopWithList()
        {
            return DoLoopOnICollection(_stringList);
        }

        [Benchmark]
        public long ICollectionForEachLoopWithCastToArray()
        {
            return DoForEachLoopOnICollection(_stringArray, false);
        }

        [Benchmark]
        public long ICollectionForEachLoopWithCastToList()
        {
            return DoForEachLoopOnICollection(_stringList, false);
        }

        [Benchmark]
        public long ICollectionForEachLoopWithCastToListAndSpan()
        {
            return DoForEachLoopOnICollection(_stringList, true);
        }

        [Benchmark]
        public long ICollectionForEachLoopWithCastToArrayAndSpan()
        {
            return DoForEachLoopOnICollection(_stringArray, true);
        }

        [Benchmark]
        public long ICollectionForEachLoopNoCastUnderlyingCollectionIsHashSet()
        {
            return DoForEachLoopOnICollection(_stringSet, false);
        }

        private long DoLoopOnICollection(ICollection<string> items)
        {
            var result = 0L;

            if (items is string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    result += arr[i].Length;
                }
            }
            else
            {
                foreach (var item in items)
                {
                    result += item.Length;
                }
            }

            return result;
        }

        private long DoForEachLoopOnICollection(ICollection<string> items, bool span)
        {
            if (items is string[] arr)
            {
                if (span)
                {
                    return CalcSpan(arr);
                }
                else
                {
                    return CalcNormal(arr);
                }
            }

            if (items is List<string> list)
            {
                if (span)
                {
                    return CalcSpan(CollectionsMarshal.AsSpan(list));
                }
                else
                {
                    return CalcNormal(list);
                }
            }

            return CalcNormal(items);

            static long CalcSpan(Span<string> items)
            {
                var result = 0L;

                foreach (var str in items)
                {
                    result += str.Length;
                }

                return result;
            }

            static long CalcArray(string[] items)
            {
                var result = 0L;

                foreach (var str in items)
                {
                    result += str.Length;
                }

                return result;
            }

            static long CalcNormal(ICollection<string> items)
            {
                var result = 0L;

                foreach (var str in items)
                {
                    result += str.Length;
                }

                return result;
            }
        }
    }
}
