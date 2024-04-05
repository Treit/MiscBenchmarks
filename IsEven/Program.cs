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
            b.Count = 100147;
            b.GlobalSetup();
            var first = b.IsEvenUsingMod();
            var second = b.IsEvenlyxerexyl();
            if (second != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenlyxerexyl)} gave result {second} instead of expected {first}.");
            }
            var third = b.IsEvenMrCarrot();
            if (third != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenMrCarrot)} gave result {third} instead of expected {first}.");
            }
            var fourth = b.IsEvenAaron();
            if (fourth != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenAaron)} gave result {fourth} instead of expected {first}.");
            }
            var fifth = b.IsEvenAaronUnsafeBitConverter();
            if (fifth != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenAaronUnsafeBitConverter)} gave result {fifth} instead of expected {first}.");
            }
            var sixth = b.IsEvenUsingINumberIsEvenInteger();
            if (sixth != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenUsingINumberIsEvenInteger)} gave result {sixth} instead of expected {first}.");
            }
            var seventh = b.IsEvenCrabFuelCursedRecursiveVersion();
            if (seventh != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenCrabFuelCursedRecursiveVersion)} gave result {seventh} instead of expected {first}.");
            }
            var eighth = b.IsEvenNotWorthUsingJester();
            if (eighth != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenNotWorthUsingJester)} gave result {eighth} instead of expected {first}.");
            }
            var ninth = b.IsEvenAkseli();
            if (ninth != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenAkseli)} gave result {ninth} instead of expected {first}.");
            }
            var tenth = b.IsEvenAkseliV2();
            if (tenth != first)
            {
                Console.WriteLine($"Incorrect algorithm detected: {nameof(b.IsEvenAkseliV2)} gave result {tenth} instead of expected {first}.");
            }

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
