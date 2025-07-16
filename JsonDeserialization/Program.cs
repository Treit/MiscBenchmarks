namespace Test;
using BenchmarkDotNet.Running;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
#if RELEASE
        BenchmarkRunner.Run<Benchmark>();
#else
        Benchmark b = new Benchmark();
        b.Count = 1000;
        b.GlobalSetup();
        var first = b.DeserializeWithJsonDocument();
        var second = b.DeserializeWithJsonNode();
        var third = b.DeserializeWithJsonSerializer();
        var fourth = b.DeserializeWithSourceGen();

        // Verify all results contain the same data
        System.Console.WriteLine("Verifying results contain the same data...");
        System.Console.WriteLine($"First count: {first.Count}");

        bool equal = first.SequenceEqual(second) &&
                    first.SequenceEqual(third) &&
                    first.SequenceEqual(fourth);

        if (equal)
        {
            System.Console.WriteLine("All results match!");
        }
        else
        {
            System.Console.WriteLine("ERROR: Results do not match!");
        }
#endif

    }
}
