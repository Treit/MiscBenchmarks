namespace Test
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 1024;
            b.GlobalSetup();
            var x = b.DedupeUsingHashSet().OrderBy(x => x).ToArray();
            b.GlobalSetup();
            var y = b.DedupeUsingC5HashSet().OrderBy(x => x).ToArray();

            Console.WriteLine(x.AsSpan().SequenceEqual(y));
#endif

        }
    }
}
