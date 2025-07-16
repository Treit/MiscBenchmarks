namespace Test;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var b = new Benchmark();
        b.Count = 100;
        b.StringLength = 3;
        b.GlobalSetup();

#endif
    }
}
