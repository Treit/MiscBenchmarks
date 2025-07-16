namespace Test;
using BenchmarkDotNet.Running;

internal class Program
{
    static void Main(string[] args)
    {
#if DEBUG
        Benchmark b = new Benchmark();
        b.GlobalSetup();
        b.Count = 100;
#else
        BenchmarkRunner.Run<Benchmark>();
#endif
    }
}
