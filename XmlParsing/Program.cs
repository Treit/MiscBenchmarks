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
                b.Count = 5000;
                b.GlobalSetup();
                var sw = Stopwatch.StartNew();
                var resultA = b.CountElementsWithXmlReader();
                Console.WriteLine($"XmlReader: {sw.ElapsedMilliseconds} ms.");

                var resultB = b.CountElementsWithXDocument();
                Console.WriteLine($"XDocument (LINQ to XML): {sw.ElapsedMilliseconds} ms.");

                var resultC = b.CountElementsWithXmlDocument();
                Console.WriteLine($"XmlDocument (XPath): {sw.ElapsedMilliseconds} ms.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
#endif

        }
    }
}
