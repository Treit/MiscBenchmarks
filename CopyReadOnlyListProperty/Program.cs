namespace ObjectCopyingBenchmark
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Count = 100;
            b.DataSize = 5;
            b.GlobalSetup();

            var result1 = b.CopyWithSelectToArray();
            var result2 = b.CopyWithDirectReference();
            var result3 = b.CopyWithToArray();
            var result4 = b.CopyWithToList();

            Console.WriteLine($"CopyWithSelectToArray: {result1.Length} objects copied");
            Console.WriteLine($"CopyWithDirectReference: {result2.Length} objects copied");
            Console.WriteLine($"CopyWithToArray: {result3.Length} objects copied");
            Console.WriteLine($"CopyWithToList: {result4.Length} objects copied");

#endif
        }
    }
}
