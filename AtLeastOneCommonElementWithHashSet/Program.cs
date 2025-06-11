namespace Test
{
    using BenchmarkDotNet.Running;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 1000;
            b.GlobalSetup();
            Console.WriteLine($"ListAnyListContains: {b.ListAnyListContains()}");
            Console.WriteLine($"ListAnyHashSetContains: {b.ListAnyHashSetContains()}");
            Console.WriteLine($"ListAnyFrozenSetContains: {b.ListAnyFrozenSetContains()}");
            Console.WriteLine($"LinqIntersectListThenAny: {b.LinqIntersectListThenAny()}");
            Console.WriteLine($"PrebuiltHashSetOverlapsMethod: {b.PrebuiltHashSetOverlapsMethod()}");
            Console.WriteLine($"PrebuiltFrozenSetOverlapsMethod: {b.PrebuiltFrozenSetOverlapsMethod()}");
#endif
        }
    }
}
