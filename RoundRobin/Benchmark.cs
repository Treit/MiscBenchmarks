namespace Test
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SuperLinq;

    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(10)]
        public int Count { get; set; }

        IEnumerable<IEnumerable<string>> _lists;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var tmp = new List<List<string>>();
            for (int i = 0; i < Count; i++)
            {
                var list = new List<string>();
                for (int j = 0; j < 5; j++)
                {
                    list.Add($"{i}-{j}");
                }

                tmp.Add(list);
            }

            _lists = tmp;
        }

        [Benchmark(Baseline = true)]
        public IList<string> RoundRobinUsingListAndEnumerators()
        {
            return DoRoundRobinMergeUsingEnumerators(_lists).ToList();
        }

        [Benchmark]
        public IList<string> RoundRobinUsingListAndEnumerators2()
        {
            return DoRoundRobinMergeUsingEnumerators2(_lists).ToList();
        }

        [Benchmark]
        public IList<string> RoundRobinUsingQueue()
        {
            return DoRoundRobinMergeUsingQueue(_lists).ToList();
        }

        [Benchmark]
        public IList<string> RoundRobinUsingQueueAndEnumerators()
        {
            return DoRoundRobinUsingQueueAndEnumerators(_lists).ToList();
        }

        [Benchmark]
        public IList<string> RoundRobinUsingSuperLinqInterleave()
        {
            return DoRoundRobinUsingSuperLinqInterleave(_lists).ToList();
        }

        public static IEnumerable<T> DoRoundRobinUsingSuperLinqInterleave<T>(IEnumerable<IEnumerable<T>> source)
        {
            return source.Reverse().Interleave();
        }

        public static IEnumerable<T> DoRoundRobinMergeUsingEnumerators<T>(IEnumerable<IEnumerable<T>> source)
        {
            if (source == null || !source.Any())
            {
                yield break;
            }

            // ToList is necessary to avoid deferred execution
            var enumerators = source.Where(seq => seq != null).Select(seq => seq.GetEnumerator()).ToList();

            try
            {
                while (true)
                {
                    for (int i = enumerators.Count - 1; i >= 0; i--)
                    {
                        var e = enumerators[i];
                        bool b = e.MoveNext();
                        if (b)
                        {
                            yield return e.Current;
                        }
                        else
                        {
                            e.Dispose();
                            enumerators.RemoveAt(i);
                            if (enumerators.Count < 1)
                            {
                                yield break;
                            }
                        }
                    }

                    if (enumerators.Count < 1)
                    {
                        yield break;
                    }
                }
            }
            finally
            {
                foreach (var e in enumerators)
                {
                    e.Dispose();
                }
            }
        }

        public static IEnumerable<T> DoRoundRobinMergeUsingEnumerators2<T>(IEnumerable<IEnumerable<T>> source)
        {
            if (source == null || !source.Any())
            {
                yield break;
            }

            var enumerators = new List<IEnumerator<T>>(source.Select(x => x.GetEnumerator()));

            while (true)
            {
                for (int i = enumerators.Count - 1; i >= 0; i--)
                {
                    if (enumerators[i].MoveNext())
                    {
                        yield return enumerators[i].Current;
                    }
                    else
                    {
                        enumerators[i].Dispose();
                        enumerators.RemoveAt(i);
                    }
                }

                if (enumerators.Count == 0)
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<T> DoRoundRobinMergeUsingQueue<T>(IEnumerable<IEnumerable<T>> source)
        {
            var queue = new Queue<IEnumerable<T>>();

            foreach (var list in source.Reverse())
            {
                queue.Enqueue(list);
            }

            while (true)
            {
                if (queue.Count == 0)
                {
                    yield break;
                }

                var list = queue.Dequeue();
                if (list.Any())
                {
                    yield return list.First();
                    queue.Enqueue(list.Skip(1));
                }
            }
        }

        public static IEnumerable<T> DoRoundRobinUsingQueueAndEnumerators<T>(IEnumerable<IEnumerable<T>> source)
        {
            var queue = new Queue<IEnumerator<T>>();

            foreach (var list in source.Reverse())
            {
                queue.Enqueue(list.GetEnumerator());
            }

            while (true)
            {
                if (queue.Count == 0)
                {
                    yield break;
                }

                var enumerator = queue.Dequeue();
                if (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                    queue.Enqueue(enumerator);
                }
                else
                {
                    enumerator.Dispose();
                }
            }
        }
    }
}
