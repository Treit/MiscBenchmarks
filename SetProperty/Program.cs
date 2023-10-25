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
            b.GlobalSetup();
            Console.WriteLine(b.SetPropertyUsingReflection().Data.Message);
            Console.WriteLine(b.SetPropertyUsingDynamic().Data.Message);
            Console.WriteLine(b.SetPropertyNormally().Data.Message);
#endif

        }
    }
}
