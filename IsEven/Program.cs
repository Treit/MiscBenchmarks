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
            b.Count = 1000;
            b.GlobalSetup();
            var first = b.IsEvenUsingMod();
            var second = b.IsEvenlyxerexyl();
            var third = b.IsEvenMrCarrot();
            var fourth = b.IsEvenAaron();
            var fifth = b.IsEvenAaronUnsafeBitConverter();
            var sixth = b.IsEvenUsingINumberIsEvenInteger();
            var seventh = b.IsEvenCrabFuelCursedRecursiveVersion();
            var eighth = b.IsEvenNotWorthUsingJester();
            var ninth = b.IsEvenAkseli();
            var tenth = b.IsEvenAkseliV2();

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
            Console.WriteLine(fifth);
            Console.WriteLine(sixth);
            Console.WriteLine(seventh);
            Console.WriteLine(eighth);
            Console.WriteLine(ninth);
            Console.WriteLine(tenth);
#endif
        }
    }
}
