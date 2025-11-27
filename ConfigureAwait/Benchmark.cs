namespace Test;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.IO;
using System.Threading.Tasks;

[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0)]

public class Benchmark
{
    [Params(1000, 100_000, 1_000_000)]
    public int Count { get; set; }

    private string _testFile = "./benchmark_test_data";

    [GlobalSetup]
    public void GlobalSetup()
    {
        using var sw = new StreamWriter(_testFile);
        for (int i = 0; i < Count; i++)
        {
            sw.WriteLine(i);
        }
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        File.Delete(_testFile);
    }

    [Benchmark(Baseline = true)]
    public long ReadSynchronous()
    {
        long result = 0;

        using var sr = new StreamReader(_testFile);

        string line;

        while ((line = sr.ReadLine()) != null)
        {
            result += int.Parse(line);
        }

        return result;
    }

    [Benchmark]
    public async Task<long> ReadAsyncAwait()
    {
        long result = 0;

        using var sr = new StreamReader(_testFile);

        string line;

        while ((line = await sr.ReadLineAsync()) != null)
        {
            result += int.Parse(line);
        }

        return result;
    }

    [Benchmark]
    public async Task<long> ReadAsyncAwaitConfigureAwaitFalse()
    {
        long result = 0;

        using var sr = new StreamReader(_testFile);

        string line;

        while ((line = await sr.ReadLineAsync().ConfigureAwait(false)) != null)
        {
            result += int.Parse(line);
        }

        return result;
    }

    [Benchmark]
    public async Task<long> ReadAsyncAwaitConfigureAwaitTrue()
    {
        long result = 0;

        using var sr = new StreamReader(_testFile);

        string line;

        while ((line = await sr.ReadLineAsync().ConfigureAwait(true)) != null)
        {
            result += int.Parse(line);
        }

        return result;
    }
}
