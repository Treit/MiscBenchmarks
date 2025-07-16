namespace Test;
using BenchmarkDotNet.Running;
using System.Threading.Tasks;

internal class Program
{
    static async Task Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.Count = 1000;
        b.GlobalSetup();
        await b.ReadMemoryStreamAsync();
#endif

    }
}
