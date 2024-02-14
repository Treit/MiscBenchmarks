namespace Test
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
            b.HexStringLength = 10;
            b.GlobalSetup();
            var resultA = b.HexStringToBytesUsingConvert();
            var resultB = b.HexStringToBytesUsingCustomImplementation();
            Console.WriteLine(resultA.SequenceEqual(resultB));
            Console.WriteLine(Convert.ToHexString(resultA));
#endif
        }
    }
}
