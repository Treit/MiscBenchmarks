namespace Test
{
    using BenchmarkDotNet.Running;
    using System;
    using System.Diagnostics;

    internal class Program
    {
        static void Main(string[] args)
        {
#if RELEASE
            BenchmarkRunner.Run<Benchmark>();
#else
            try
            {
                Benchmark b = new Benchmark();
                b.GlobalSetup();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
#endif

        }
    }
}
