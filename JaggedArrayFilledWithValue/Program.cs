using BenchmarkDotNet.Running;
using System;

namespace Test;
internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.IterationCount = 10000;
        b.GlobalSetup();
        var answerA = b.IndexOfMaxForLoop();
        var answerB = b.IndexOfMaxForLoopWithCancelCheck();
        Console.WriteLine(answerA);
        Console.WriteLine(answerB);
#endif
    }
}