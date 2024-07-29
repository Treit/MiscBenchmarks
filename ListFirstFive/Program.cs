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
            b.ListSize = 1000;
            b.GlobalSetup();
            var first = b.TakeDotSelectDotToList();
            var second = b.GetRangeDotSelectDotToList();
            var third = b.SelectDotTakeDotToList();
            var fourth = b.SelectDotToListDotGetRange();
            var fifth = b.NewListAndForLoop();
            Console.WriteLine(string.Join(',', first));
            Console.WriteLine(string.Join(',', second));
            Console.WriteLine(string.Join(',', third));
            Console.WriteLine(string.Join(',', fourth));
            Console.WriteLine(string.Join(',', fifth));
#endif

        }
    }
}
