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
        var b = new Benchmark
        {
            Count = 1_000,
            MatchPercent = 50,
        };

        b.GlobalSetup();
        var linq = b.LinqWhereThenForeach();
        var forLoop = b.ForLoopWithContinue();
        var inline = b.ForLoopWithInlineCondition();

        Console.WriteLine(linq);
        Console.WriteLine(forLoop);
        Console.WriteLine(inline);
#endif
    }
}
