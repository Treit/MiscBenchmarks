using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomElementsBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
#endif
        }
    }
}
