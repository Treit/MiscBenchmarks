using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;

namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<SmallBenchmark>();
        BenchmarkRunner.Run<BigBenchmark>();
    }
}
