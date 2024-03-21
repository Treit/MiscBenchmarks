namespace Test
{
    using BenchmarkDotNet.Running;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            Benchmark b = new Benchmark();
            b.Iterations = 1024;
            b.VectorLength = 1024;
            b.GlobalSetup();

            var first = b.ComputeDistanceLINQ();
            var second = b.ComputeDistanceVectorizedMTreit();
            var third = b.ComputeDistanceVectorizedAaron();
            var fourth = b.ComputeDistanceTensorPrimitives();
            Console.WriteLine($"ComputeDistanceLINQ: {first}");
            Console.WriteLine($"ComputeDistanceMTreit: {second}");
            Console.WriteLine($"ComputeDistanceAaron: {third}");
            Console.WriteLine($"ComputeDistanceTensorPrimitives: {fourth}");
#endif
        }
    }
}
