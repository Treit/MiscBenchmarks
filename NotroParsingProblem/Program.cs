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
            var w = b.ParseUsingRegex();
            var x = b.ParseUsingStateMachine();
            var y = b.ParseUsingTokensViaSplit();
            var z = b.ParseUsingSpan();

            if (w != x || x != y || y != z)
            {
                throw new InvalidOperationException("Expected everything to be equal");
            }
#endif

        }
    }
}
