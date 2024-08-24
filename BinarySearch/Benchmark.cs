namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static int[] s_data = [];

        [Params(1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random r = new Random();
            s_data = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                s_data[i] = r.Next();
            }

            Array.Sort(s_data);
        }

        [Benchmark]
        public int BinarySearchWithDivide()
        {
            var target = 1_000_000;
            return BinarySearch(s_data, target);
        }

        [Benchmark(Baseline = true)]
        public int BinarySearchWithShift()
        {
            var target = 1_000_000;
            return BinarySearch2(s_data, target);
        }

        [Benchmark]
        public int BinarySearchBCLImplementation()
        {
            var target = 1_000_000;
            return Array.BinarySearch(s_data, target);
        }


        private static int BinarySearch(int[] array, int numberToFind)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (array[mid] == numberToFind)
                {
                    return mid;
                }

                if (numberToFind < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        private static int BinarySearch2(int[] array, int numberToFind)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + ((high - low) >> 1);

                if (array[mid] == numberToFind)
                {
                    return mid;
                }

                if (numberToFind < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}
