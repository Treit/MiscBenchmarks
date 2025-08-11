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
        var tupA = b.TokenizeWithStringSplit();
        var tupB = b.TokenizeWithSubstring();
        var tupC = b.TokenizeWithRangeOperator();
        var tupD = b.TokenizeWithRegexGroupsDotValue();
        var tupE = b.TokenizeWithRegexMatchDotResult();
        var tupF = b.TokenizeWithCommunityToolkitTokenize();
        var tupG = b.TokenizeWithSpanSlicing();
        Console.WriteLine(tupA);
        Console.WriteLine(tupB);
        Console.WriteLine(tupC);
        Console.WriteLine(tupD);
        Console.WriteLine(tupE);
        Console.WriteLine(tupF);
        Console.WriteLine(tupG);
        Console.WriteLine($"Results equal: {tupA.Equals(tupB) && tupB.Equals(tupC) && tupC.Equals(tupD) && tupD.Equals(tupE) && tupE.Equals(tupF) && tupF.Equals(tupG)}");
#endif
    }
}
