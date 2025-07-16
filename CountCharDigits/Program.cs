namespace Test;
using BenchmarkDotNet.Running;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}
