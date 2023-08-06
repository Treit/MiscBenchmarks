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
            try
            {
                Benchmark b = new Benchmark();
                b.Count = 50;
                b.GlobalSetup();
                var resultA = b.CountElementsWithXmlReader();
                Console.WriteLine(resultA);

                var resultB = b.CountElementsWithXDocument();
                Console.WriteLine(resultB);

                var resultC = b.CountElementsWithXmlDocument();
                Console.WriteLine(resultC);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
#endif

        }
    }
}
