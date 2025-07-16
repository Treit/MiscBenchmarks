namespace Test;
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
        b.IterationSetup();
        var first = b.ListIntersectAnyAsArray();
        b.IterationSetup();
        var second = b.ListIntersectAnyLinq();
        b.IterationSetup();
        var third = b.ListIntersectAnyNestedLoopWithSpan();
        b.IterationSetup();
        var fourth = b.ArrayIntersectAnyAsArray();
        b.IterationSetup();
        var fifth = b.ArrayIntersectAnyLinq();
        b.IterationSetup();
        var sixth = b.ArrayIntersectAnyNestedLoopWithSpan();

        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(fourth);
        Console.WriteLine(fifth);
        Console.WriteLine(sixth);

#endif
    }
}
