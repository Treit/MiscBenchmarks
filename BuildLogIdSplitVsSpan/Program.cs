namespace Test;
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
        b.GlobalSetup();
        var first = b.GetLogIdWithIndexOfAndSpan();
        var second = b.GetLogIdWithIndexOfAndSubstringChatGPT();
        var third = b.GetLogIdWithSplit();
        var fourth = b.GetLogIdWithCustomSpanSplit();
        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
        Console.WriteLine(fourth);
#endif
    }
}
