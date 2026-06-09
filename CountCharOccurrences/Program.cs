namespace Test;

using BenchmarkDotNet.Running;

internal class Program
{
    static void Main()
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var b = new Benchmark { Size = 32 };
        b.GlobalSetup();
        Console.WriteLine(b.GroupByWithOccurencesItem());
        Console.WriteLine(b.CountBy());
        Console.WriteLine(b.DictionaryLoop());
#endif
    }
}
