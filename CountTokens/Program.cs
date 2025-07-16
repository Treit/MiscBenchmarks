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
        b.Count = 1_000_000;
        b.GlobalSetup();
        var first = b.CountTokensUsingLinqCount();
        var second = b.CountTokensUsingSpanCount();
        var third = b.CountTokensUsingSplitToListAndCount();
        var fourth = b.CountTokensUsingSplitAndLength();
        var fifth = b.CountTokensUsingHandWrittenForEachLoopWithShortCircuit();
        var sixth = b.CountTokensUsingHandWrittenForEachLoopWithIndexOf();
        var seventh = b.CountTokensUsingHandWrittenForEachLoopWithIndexOfAaron();
        var eight = b.CountTokensUsingHandWrittenForEachLoopWithRegex();
        var nine = b.CountTokensUsingHandWrittenForEachLoopWithSourceGenRegex();
        Console.WriteLine($"First: {first}, Second: {second}, Third: {third}, Fourth: {fourth}");
        Console.WriteLine($"Fifth: {fifth}, Sixth: {sixth}, Seventh: {seventh}");
        Console.WriteLine($"Eight: {eight}");
        Console.WriteLine($"Nine: {nine}");
#endif
    }
}
