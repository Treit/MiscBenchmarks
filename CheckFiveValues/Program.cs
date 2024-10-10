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
            b.valueToCheck = "FirstValue";
            b.GlobalSetup();
            var first = b.CheckWithSimpleIf();
            var second = b.CheckWithSwitchStatement();
            var third = b.CheckWithHashSet();
            var fourth = b.CheckWithDictionary();
            var fifth = b.CheckWithSwitchExpression();
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
            Console.WriteLine(fifth);
#endif
        }
    }
}
