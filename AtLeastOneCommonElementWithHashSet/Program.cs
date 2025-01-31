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
            var first = b.HashSetOverlapMethod();
            var second = b.ArrayWalkAndHashSetLookupAndHashSetContains();
            var third = b.ArrayWalkAndHashSetLookupAndIEnumerableContains();
            var fourth = b.ArrayWalkAndHashSetLookupAndIEnumerableContainsNoOverlap();
            var fifth = b.ArrayWalkAndHashSetLookupAndHashSetContainsNoOverlap();
            var sixth = b.HashSetOverlapMethodWithNoOverlap();
            Console.WriteLine($"First: {first}");
            Console.WriteLine($"Second: {second}");
            Console.WriteLine($"Third: {third}");
            Console.WriteLine($"Fourth: {fourth}");
            Console.WriteLine($"Fifth: {fifth}");
            Console.WriteLine($"Sixth: {sixth}");
#endif
        }
    }
}
