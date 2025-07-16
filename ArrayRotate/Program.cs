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
        b.Amount = 26;
        b.GlobalSetup();
        var answer0 = b.RotateLeftWithReverse();
        var answer1 = b.RotateLeftWithCopy();
        var answer2 = b.RotateLeftWithJuggling();
        var answer3 = b.RotateLeftArrayCopyAaron();

        var correct = answer0.AsSpan().SequenceEqual(answer1);
        correct = answer1.AsSpan().SequenceEqual(answer2);
        correct = answer2.AsSpan().SequenceEqual(answer3);

        Console.WriteLine(correct);
#endif
    }
}
