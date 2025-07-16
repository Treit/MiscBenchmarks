namespace Test;
using BenchmarkDotNet.Running;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.GlobalSetup();
        b.ReverseStringUsingExplicitCopy();
#endif

    }
}
