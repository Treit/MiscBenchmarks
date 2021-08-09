namespace Benchmark
{
    using BenchmarkDotNet.Running;
    using TestLib;

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
