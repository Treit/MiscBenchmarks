namespace Test;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.Count = 1000;
        b.ItemsPerDictionary= 100;
        b.GlobalSetup();
        var n = b.CheckDictionaryEmptyUsingCount();
        var m = b.CheckDictionaryEmptyUsingAny();
        Debugger.Break();
#endif
    }
}
