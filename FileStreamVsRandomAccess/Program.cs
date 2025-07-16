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
        b.Count = 1024 * 1024 * 1024;
        b.GlobalSetup();
        b.HashFileLocationsUsingFileStreamCrc32();
#endif

    }
}
