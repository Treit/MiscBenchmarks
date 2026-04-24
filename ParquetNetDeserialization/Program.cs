namespace ParquetNetDeserialization;

using BenchmarkDotNet.Running;
using System;
using System.Threading.Tasks;

internal class Program
{
    static async Task Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        var b = new Benchmark();
        b.GlobalSetup();

        var r1 = await b.SerializerDeserialize();
        var r2 = await b.ColumnApiDeserialize();

        Console.WriteLine($"Serializer rows:  {r1}");
        Console.WriteLine($"Column API rows:  {r2}");
        Console.WriteLine($"Results match:    {r1 == r2}");
#endif
    }
}
