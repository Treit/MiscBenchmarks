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
            b.Count = 4;
            b.GlobalSetup();
            var first = b.MoveUsingRandomIndex();
            var second = b.MoveUsingLinqOrderByRandomWithUnecessaryToList();
            var third = b.MoveUsingCollectionsMarshal();
            var fourth = b.MoveUsingCollectionsMarshalAndSharedRandom();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
#endif
        }
    }
}
