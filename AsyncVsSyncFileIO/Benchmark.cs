namespace Test;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using System.IO;
using System.Threading.Tasks;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(10, 100, 100_000)]
    public int Count { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        using var sw = new StreamWriter("file.to.read");

        for (int i = 0; i < Count; i++)
        {
            sw.WriteLine(i.ToString());
        }
    }

    [GlobalCleanup]
    public void TestCleanup()
    {
        try
        {
            CleanupFile("file.out");
            CleanupFile("file2.out");
            CleanupFile("file.to.read");
        }
        catch
        {
        }

        void CleanupFile(string fname)
        {
            try
            {
                File.Delete(fname);
            }
            catch
            {
            }
        }
    }

    [Benchmark]
    public void WriteFileSync()
    {
        using var sw = new StreamWriter("file.out");

        for (int i = 0; i < Count; i++)
        {
            sw.WriteLine(i.ToString());
        }
    }

    [Benchmark]
    public async Task WriteFileAsync()
    {
        using var sw = new StreamWriter("file2.out");

        for (int i = 0; i < Count; i++)
        {
            await sw.WriteLineAsync(i.ToString());
        }
    }

    [Benchmark(Baseline = true)]
    public int ReadFileSync()
    {
        int count = 0;
        using var sr = new StreamReader("file.to.read");

        while (sr.ReadLine() is string line)
        {
            count += line.Length;
        }

        return count;
    }

    [Benchmark]
    public async Task<int> ReadFileAsync()
    {
        int count = 0;
        using var sr = new StreamReader("file.to.read");

        while (await sr.ReadLineAsync() is string line)
        {
            count += line.Length;
        }

        return count;
    }
}
